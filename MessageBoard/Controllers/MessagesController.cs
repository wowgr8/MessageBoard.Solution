using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

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
    public async Task<ActionResult<IEnumerable<Message>>> Get()
    {
      return await _db.Messages.ToListAsync();
    }

    // POST api/messages
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
    // [HttpPut] annotation specifies that we'll determine which animal will be updated based on the id parameter in the URL.    
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

    // created a private method, MessageExists, for use within the controller, to DRY up our code.
    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }    
  }
}