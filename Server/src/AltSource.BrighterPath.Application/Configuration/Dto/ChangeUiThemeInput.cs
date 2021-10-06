using System.ComponentModel.DataAnnotations;

namespace AltSource.BrighterPath.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}

