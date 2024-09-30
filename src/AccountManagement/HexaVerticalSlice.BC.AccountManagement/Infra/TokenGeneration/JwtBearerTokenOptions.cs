using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;

public class JwtBearerTokenOptions
{
    public const string SectionName = "JWT";

    [Required]
    public string ValidAudience { get; set; } = string.Empty;
    
    [Required]
    public string ValidIssuer { get; set; } = string.Empty;
    
    [Required]
    public string Secret { get; set; } = string.Empty;
    
    [Required]
    public TimeSpan Validity { get; set; } = TimeSpan.FromDays(1);
}
