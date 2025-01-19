using DependencyInjectionTest.UseCase.Scoped;
using DependencyInjectionTest.UseCase.Singleton;
using DependencyInjectionTest.UseCase.Transient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência
builder.Services.AddSingleton<SingletonUseCase>();
builder.Services.AddTransient<TransientUseCase>();
builder.Services.AddScoped<ScopedUseCase>();
builder.Services.AddScoped<UseCaseA>();
builder.Services.AddScoped<UseCaseB>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
