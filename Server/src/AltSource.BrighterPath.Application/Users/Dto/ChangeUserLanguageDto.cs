using System.ComponentModel.DataAnnotations;

namespace AltSource.BrighterPath.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
