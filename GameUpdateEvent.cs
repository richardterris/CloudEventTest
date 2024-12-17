using System;
using Newtonsoft.Json;

namespace CloudTest;

public class GameUpdateEvent
{
    [JsonProperty("gameId")]
    public string GameId { get; set;}
}