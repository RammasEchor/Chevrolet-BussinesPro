using System.Text.Json.Serialization;

public record class ChevroletUser
{
    [property: JsonPropertyName("id")]
    public required int Id { get; set; }
    [property: JsonPropertyName("name")]
    public string? Name { get; set; }
    [property: JsonPropertyName("isComplete")]
    public required bool IsComplete { get; set; }
}