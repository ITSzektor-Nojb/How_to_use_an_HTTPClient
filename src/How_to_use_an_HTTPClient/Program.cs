using How_to_use_an_HTTPClient.Clients;

namespace How_to_use_an_HTTPClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddTransient<IWeatherClient, OpenWeatherClient>();
            builder.Services.AddHttpClient("weatherApi", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
