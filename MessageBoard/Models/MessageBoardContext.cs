using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
      : base(options)
    {
    }


    // SEEDING DATA: To efficiently test our API without having to manually add data in MySQLWorkbench or via POST requests, we will automate the process of seeding the database. Seeding a database is simply populating a database with data. The data can range from important and necessary authorization user roles to just dummy data.
    // In the case of the Cretaceous Park API, we'll seed the database with a handful of Message entries so that we can test our code to make sure we can properly filter Animals by search parameters.
    // In order to add the data, let's override the OnModelCreating method that belongs to Entity Framework's DbContext class by adding the following to our CretaceousParkContext class:
    // We declare the method as protected override since we only want this method to be accessible to the class itself and we want to override the default method. Since the method doesn't return anything, we also specify void as the return value.
    // The method accepts an argument of type ModelBuilder that we will call builder.
    protected override void OnModelCreating(ModelBuilder builder)
    {
      // We then call the builder's Entity<Type>() method which returns an EntityTypeBuilder object that allows us to configure the type we specify in the method call.
      builder.Entity<Message>()
        // We can then call the HasData() method of the returned EntityTypeBuilder and pass the method any manner of entries we'd like to use to seed the database. We'll add five initial Message entries to our database.
        .HasData(
          new Message { MessageId = 1, Title = "Weekend Trip", To = "Woolly Mammoth", Pages = 7, From = "Filipe" },
          new Message { MessageId = 2, Title = "Airbnb", To = "You", Pages = 10, From = "Dan" },
          new Message { MessageId = 3, Title = "Class Schedule", To = "Shteve", Pages = 2, From = "Kimi" },
          new Message { MessageId = 4, Title = "Pipes", To = "Shark", Pages = 4, From = "Stan" },
          new Message { MessageId = 5, Title = "Binge Drinking 101", To = "Dinosaur", Pages = 22, From = "Foolio" }
        );
    }

    public DbSet<Message> Messages { get; set; }

    

  }
}