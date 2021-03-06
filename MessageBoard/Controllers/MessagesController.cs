using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using Microsoft.AspNetCore.Http;


namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    // GET api/messages
    [HttpGet]
    // Get route needs to return an ActionResult of type IEnumerable<message>>. In our web applications, we didn't need to specify a type because we were always returning a view.
    // public async Task<ActionResult<IEnumerable<Message>>> Get()
    // {
    //   return await _db.Messages.ToListAsync();
    // }
    public async Task<ActionResult<Pagination>> Get(string title, string to, string from, int page, int perPage, int pages)
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();
      if (title != null)
      {
        query = query.Where(entry => entry.Title == title);
      }
      if (to != null)
      {
        query = query.Where(entry => entry.To == to);
      }
      if (from != null)
      {
        query = query.Where(entry => entry.From == from);
      }
      if (pages != 0)
      {
        query = query.Where(entry => entry.Pages == pages);
      }      

      List<Message> messages = await query.ToListAsync();

      if (perPage == 0) perPage = 2;

      int total = messages.Count;
      List<Message> messagesPage = new List<Message>();

      if (page < (total / perPage))
      {
        messagesPage = messages.GetRange(page * perPage, perPage);
      }

      if (page == (total / perPage))
      {
        messagesPage = messages.GetRange(page * perPage, total - (page * perPage));
      }

      return new Pagination()
      {
        MessageData = messagesPage,
        Total = total,
        PerPage = perPage,
        Page = page,
        PreviousPage = page == 0 ? $"/api/Messages?page={page}" : $"/api/Messages?page={page - 1}",
        NextPage = $"/api/Messages?page={page + 1}",
      };
    }







    // POST api/messages
    [HttpPost]
    // Post route utilizes CreatedAtAction function so that it can end up returning the message object to the user as well as update the status code to 201 for "Created" rather than the default 200 OK
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
    }

    // GET: api/Messages/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);

      if (message == null)
      {
        return NotFound();
      }

      return message;
    }

    // PUT: api/Messages/5
    // We use an [HttpPut] annotation. This specifies that we'll determine which message will be updated based on the id parameter in the URL.
    // PUT is like POST in that it makes a change to the server. However, PUT changes existing information while POST creates new information. 

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPut] annotation specifies that we'll determine which message will be updated based on the id parameter in the URL.    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      _db.Entry(message).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/Messages/5

    // new [HttpDelete] annotation takes an id as a URL parameter just like our equivalent GET and PUT methods. Entity doesn't care whether it gets information from an API or a web application when manipulating the database.
    // Remember that forms in HTML5 don't allow for PUT, PATCH or DELETE verbs. For that reason, we had to use HttpPost along with an ActionName like this: [HttpPost, ActionName("Delete")]. However, we aren't using HTML anymore and there are no such limitations with an API
    // For that reason, we can use HttpPut and HttpDelete.
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // created a private method, MessageExists, for use within the controller, to DRY up our code.
    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }    
  }
}