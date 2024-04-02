using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;
using ConsoleAppBase64String.Models;

Console.WriteLine("***** Testes com .NET 8 | Base64StringAttribute *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var items = new Item[]
{
    new Item() { PlainText = "Primeiro valor", Encoded = "UHJpbWVpcm8gaXRlbQ==" },
    new Item() { PlainText = "Segundo item", Encoded = "Segundo item" },
    new Item() { PlainText = "Terceiro item", Encoded = "VGVyY2Vpcm8gaXRlbQ==" },
    new Item() { PlainText = "Quarto item", Encoded = "4o item" }
};

foreach (var item in items)
{
    Console.WriteLine();
    Console.WriteLine(JsonSerializer.Serialize(item));
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(item, new ValidationContext(item),
        validationResults, validateAllProperties: true))
    {
        Console.WriteLine("Dados invalidos para essa instancia...");
        foreach (var validationResult in validationResults)
            Console.WriteLine($"ErrorMessage = {validationResult.ErrorMessage}");
    }
}