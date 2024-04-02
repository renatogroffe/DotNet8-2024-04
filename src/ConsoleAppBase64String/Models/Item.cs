using System.ComponentModel.DataAnnotations;

namespace ConsoleAppBase64String.Models;

public class Item
{
    [Required]
    public string? PlainText { get; set; }

    [Base64String(ErrorMessage = "String base64 invalida")]
    public string? Encoded { get; set; }
}