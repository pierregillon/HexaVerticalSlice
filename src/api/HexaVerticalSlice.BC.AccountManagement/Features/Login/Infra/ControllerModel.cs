using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Infra;

public class ControllerModel
{
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}
