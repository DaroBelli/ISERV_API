using ISERV_API.Controllers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/search", (string? country, string? name) => 
{
    return EducationalInstitutionConroller.GetByCountryAndName(country, name);
});

app.MapGet("/", () => "Hello");

app.Run();
