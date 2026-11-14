using Microsoft.EntityFrameworkCore;
using SPR521_t2.BLL.Validators.SushiType;
using SPR521_t2.DAL;
using SPR521_t2.DAL.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISushiSetRepository, SushiSetRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateSushiTypeValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    Seeder.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();