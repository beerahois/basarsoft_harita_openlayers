var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
    await Task.CompletedTask;
});


app.MapFallback(async context =>
{
    context.Response.Redirect("/");
    await Task.CompletedTask;
});

app.UseStatusCodePagesWithRedirects("/");


// --- 2. KÖK DİZİN (ROOT) İÇİN İSTEĞİ INDEX.HTML'E YÖNLENDİR (İsteğe bağlı) ---
app.MapGet("/map", async context =>
{
    context.Response.Redirect("/map.html");
    await Task.CompletedTask;
});

app.Run();
