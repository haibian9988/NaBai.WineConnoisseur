using System.ComponentModel.DataAnnotations;

namespace NABAI.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}