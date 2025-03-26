using TauschbarAPI.Data;
using TauschbarAPI.Models;

public static class Seed
{
    public static void Init(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (!db.Users.Any())
        {
            var user = new User { Username = "torsten", Email = "torsten@example.com" };
            db.Users.Add(user);

            db.Offers.AddRange(
                new Offer
                {
                    Title = "Hilfe beim Umzug",
                    Description = "Ich kann anpacken und hab ein Auto.",
                    Type = OfferType.Help,
                    User = user
                },
                new Offer
                {
                    Title = "Kaffeemaschine zu verschenken",
                    Description = "Fast neu, funktioniert einwandfrei.",
                    Type = OfferType.Item,
                    User = user
                }
            );

            db.SaveChanges();
        }
    }
}