using System.Text.Json;
using CloudNative.CloudEvents;
using Newtonsoft.Json.Linq;
using CloudTest;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/game", async(HttpContext context, CloudEvent cloudEvent) => {
     if (cloudEvent == null)
        {
            return Results.BadRequest("CloudEvent was not provided or could not be deserialized.");
        }
            
        if (cloudEvent.Data is JsonElement dataElement)
        {
            string jsonString = dataElement.GetRawText();
            JObject dataAsJObject = JObject.Parse(jsonString);
            var result = dataAsJObject.ToObject<GameUpdateEvent>();
            Console.WriteLine($"Game Id: {result?.GameId}");
        }

        return Results.Ok(); 
});



app.Run();
