using System.Text.Json.Serialization;

namespace NewWebApp.Models
{
    public class TextModel
    {
        [JsonPropertyName("text")]
        public string text { get; set; }
    }
}