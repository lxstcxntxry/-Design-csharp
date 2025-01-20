using bookshop;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles(); 
app.UseRouting();

app.MapControllers();

app.Run();