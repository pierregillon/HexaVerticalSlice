using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Adapters;

public class ControllerModel
{
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}