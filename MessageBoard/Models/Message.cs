namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Title { get; set; }
    public string To { get; set; }
    public string From { get; set; }
    public int Pages { get; set; }
  }
}