using Microsoft.EntityFrameworkCore;
using TauschbarAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tauschbar.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


app.MapGet("/api/offers", async (AppDbContext db) =>
    await db.Offers
        .Select(o => new {
            o.Id,
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

app.MapGet("/api/offers/{id}", async (Guid id, AppDbContext db) =>
    await db.Offers
        .Select(o => new {
            o.Id,
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

// run app
app.Run();

