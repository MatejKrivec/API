using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data.Entity;
using System.Text.Json;
using webAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();*/

ApplicationDbContext db = new ApplicationDbContext();

/*var osebe = new List<Uporabnik>
{
    new Uporabnik { id = 1, ime = "Janez Novak", email = "janez.novak@example.com", Role = "Admin" },
    new Uporabnik { id = 2, ime = "Ana Kovaè", email = "ana.kovac@example.com", Role = "User" },
    new Uporabnik { id = 3, ime = "Marko Horvat", email = "marko.horvat@example.com", Role = "User" },
    new Uporabnik { id = 4, ime = "Petra Vidmar", email = "petra.vidmar@example.com", Role = "User" },
    new Uporabnik { id = 5, ime = "Andrej Kralj", email = "andrej.kralj@example.com", Role = "User" }
};*/

app.MapGet("/Uporabnik", (ApplicationDbContext db) =>
{
    var uporabniki = db.Uporabnik.ToList();
    return uporabniki;
});

app.MapPost("/Uporabnik/post", (string ime, string email, string role) =>
{
    int id = db.Uporabnik.ToList().Count +1;
    Uporabnik newUser = new Uporabnik 
    { 
        id = id, 
        ime = ime, 
        email = email, 
        Role = role 
    };
    db.Uporabnik.Add(newUser);
    db.SaveChanges();
    return newUser;

});

app.MapPut("/Uporabnik/put", (int id , string ime, string email, string role) =>
{
    var existingUporabnik = db.Uporabnik.FirstOrDefault(u => u.id == id);

    if (existingUporabnik != null)
    {
        existingUporabnik.ime = ime;
        existingUporabnik.email = email;
        existingUporabnik.Role = role;

        db.SaveChanges();
        return existingUporabnik;
    }
    else
    {
        return null;
    }

});

app.MapDelete("/Uporabnik/delete", (int id) => 
{
    var uporabnikToRemove = db.Uporabnik.FirstOrDefault(u => u.id == id);

    if (uporabnikToRemove != null)
    {
        db.Remove(uporabnikToRemove);
        db.SaveChanges();
        return uporabnikToRemove;
    }
    else
    {
        return null;
    }

});

/*var projekti = new List<Projekt>
{
    new Projekt { Id = 1, ImeProjekta = "Project 1", UporabnikId = 1 },
    new Projekt { Id = 2, ImeProjekta = "Project 2", UporabnikId = 2 },
    new Projekt { Id = 3, ImeProjekta = "Project 3", UporabnikId = 3 },
    new Projekt { Id = 4, ImeProjekta = "Project 4", UporabnikId = 4 },
    new Projekt { Id = 5, ImeProjekta = "Project 5", UporabnikId = 5 }
};*/

app.MapGet("/Projekt", () =>
{
    return db.Projekt.ToList();
});

app.MapPost("/Projekt/post", (string imeProjekta, int uporabnikId) =>
{
    int id = db.Projekt.ToList().Count + 1;
    var newProjekt = new Projekt
    {
        Id = id,
        ImeProjekta = imeProjekta,
        UporabnikId = uporabnikId
    };

    db.Projekt.Add(newProjekt);
    db.SaveChanges(); 

    return newProjekt;
});

app.MapPut("/Projekt/put", (int id, string imeProjekta, int uporabnikId) =>
{
    var existingProjekt = db.Projekt.FirstOrDefault(p => p.Id == id);

    if (existingProjekt != null)
    {
        existingProjekt.ImeProjekta = imeProjekta;
        existingProjekt.UporabnikId = uporabnikId;

        db.SaveChanges();

        return existingProjekt;
    }
    else
    {
        return null;
    }
});

app.MapDelete("/Projekt/delete", (int id) =>
{
    var projektToRemove = db.Projekt.FirstOrDefault(p => p.Id == id);

    if (projektToRemove != null)
    {
        db.Projekt.Remove(projektToRemove);
        db.SaveChanges(); 

        return projektToRemove;
    }
    else
    {
        return null;
    }
});


/*var logs = new List<Log>
{
    new Log { Id = 1, CasovnaZnacka = DateTime.Now, StopnjaResnosti = "aaaaa", Vsebina = "Log Entry 1", ProjektId = 1, UporabnikId = 1 },
    new Log { Id = 2, CasovnaZnacka = DateTime.Now, StopnjaResnosti = "aaaaa", Vsebina = "Log Entry 2", ProjektId = 2, UporabnikId = 2 },
    new Log { Id = 3, CasovnaZnacka = DateTime.Now, StopnjaResnosti = "aaaaa", Vsebina = "Log Entry 3", ProjektId = 3, UporabnikId = 3 },
    new Log { Id = 4, CasovnaZnacka = DateTime.Now, StopnjaResnosti = "aaaaa", Vsebina = "Log Entry 4", ProjektId = 4, UporabnikId = 4 },
    new Log { Id = 5, CasovnaZnacka = DateTime.Now, StopnjaResnosti = "aaaaa", Vsebina = "Log Entry 5", ProjektId = 5, UporabnikId = 5 }
};*/

app.MapGet("/Log", () =>
{
    return db.Log.ToList();
});

app.MapPost("/Log/post", (string stopnjaResnosti, string vsebina, string izvor, int projektId, int uporabnikId) =>
{
    int id = db.Log.ToList().Count + 1;

    var newLog = new Log
    {
        Id = id,
        CasovnaZnacka = DateTime.Now,
        StopnjaResnosti = stopnjaResnosti,
        Vsebina = vsebina,
        Izvor = izvor,
        ProjektId = projektId,
        UporabnikId = uporabnikId
    };

    db.Log.Add(newLog);
    db.SaveChanges(); 

    return newLog;
});

app.MapPut("/Log/put", (int id, string stopnjaResnosti, string vsebina, string izvor, int projektId, int uporabnikId) =>
{
    var existingLog = db.Log.FirstOrDefault(l => l.Id == id);

    if (existingLog != null)
    {
        existingLog.CasovnaZnacka = DateTime.Now;
        existingLog.StopnjaResnosti = stopnjaResnosti;
        existingLog.Izvor = izvor;
        existingLog.Vsebina = vsebina;
        existingLog.ProjektId = projektId;
        existingLog.UporabnikId = uporabnikId;

        db.SaveChanges(); 

        return existingLog;
    }
    else
    {
        return null;
    }
});

app.MapDelete("/Log/delete", (int id) =>
{
    var logToRemove = db.Log.FirstOrDefault(l => l.Id == id);

    if (logToRemove != null)
    {
        db.Log.Remove(logToRemove);
        db.SaveChanges(); 

        return logToRemove;
    }
    else
    {
        return null;
    }
});





app.Run();

/*internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/




