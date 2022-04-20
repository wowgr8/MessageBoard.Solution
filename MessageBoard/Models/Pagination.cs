using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Pagination
  {
    public List<Message> MessageData { get; set; }
    public int Total { get; set; }
    public int PerPage { get; set; }
    public int Page { get; set; }
    public string PreviousPage { get; set; }
    public string NextPage { get; set; }
  }
}