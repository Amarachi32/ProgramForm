using Microsoft.AspNetCore.Hosting;
using ProgramForm.Helper;
using ProgramFormInfrastructure.Extensions;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddSwaggerGen();
        builder.Services.RegisterService();
        builder.Services.ConfigureUpload(builder.Configuration);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
       // app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
