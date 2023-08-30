using Google.Cloud.Firestore;
using NewsletterAPI.Services;

namespace NewsletterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"Authentication/newsletter-72691-firebase-adminsdk-s7k7r-92670aff09.json");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add AWS Lambda support.
            builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

            builder.Services.AddSingleton<IFirestoreService>(s => new FirestoreService(FirestoreDb.Create("newsletter-72691")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}