using Microsoft.EntityFrameworkCore;
using TauschbarAPI.Data;
using TauschbarAPI.Models;
using TauschbarAPI.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tauschbar.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// activate logging in console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// seed test data
Seed.Init(app); // <- hier einfügen

app.MapGet("/", () => "TauschBar API läuft!");

// get all offers
app.MapGet("/api/offers", async (AppDbContext db) =>
    await db.Offers
        .Select(o => new {
            o.Id,
            o.UserId,
            o.Title,
            o.Description,
            o.Type,
            o.CreatedAt,
            User = new {
                o.User!.Username,
                o.User.Email
            }
        })
        .ToListAsync()
);

// get offer by id
app.MapGet("/api/offers/{id}", async (Guid id, AppDbContext db) =>
    await db.Offers
        .Select(o => new {
            o.Id,
            o.UserId,
            o.Title,
            o.Description,
            o.Type,
            o.CreatedAt,
            User = new {
                o.User!.Username,
                o.User.Email
            }
        }).FirstOrDefaultAsync(o => o.Id == id)
);

// post new offer
app.MapPost("/api/offers", async (OfferCreateDto dto, AppDbContext db, ILogger<Program> logger) =>
{
    try
    {
        var user = await db.Users.FindAsync(dto.UserId);
        if (user == null)
        {
            return Results.NotFound($"User mit ID {dto.UserId} nicht gefunden.");
        }

        var offer = new Offer
        {
            Title = dto.Title,
            Description = dto.Description,
            Type = dto.Type,
            User = user
        };

        db.Offers.Add(offer);
        await db.SaveChangesAsync();

        return Results.Created($"/api/offers/{offer.Id}", offer);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Fehler beim Erstellen des Angebots.");
        return Results.Problem("Interner Fehler beim Anlegen des Angebots.");
    }
});



// run app
app.Run();

