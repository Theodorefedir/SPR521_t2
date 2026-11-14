using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SPR521_t2.BLL.Profiles;
using SPR521_t2.BLL.Validators.SushiType;
using SPR521_t2.DAL;
using SPR521_t2.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssemblyContaining<CreateSushiTypeValidator>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<SushiTypeProfile>();
});
builder.Services.AddScoped<ISushiTypeRepository, SushiTypeRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    Seeder.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
