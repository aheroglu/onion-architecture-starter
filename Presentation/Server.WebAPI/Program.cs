using Newtonsoft.Json;
using Server.Application;
using Server.Persistence;
using Server.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddCors(action =>
    {
        action
            .AddPolicy("DefaultCorsPolicy", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
            });
    });

builder
    .Services
    .AddApplication();

builder
    .Services
    .AddPersistence(builder.Configuration);

builder
    .Services
    .AddControllers()
    .AddNewtonsoftJson(action =>
    {
        action.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder
    .Services
    .AddEndpointsApiExplorer();

builder
    .Services
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DefaultCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Helper.MigrateMigrations(app);

Helper.CreateData(app).Wait();

app.Run();
