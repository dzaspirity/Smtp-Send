using System.ComponentModel.DataAnnotations;

namespace SmtpSend.Models
{
    public class SendMessageModel
    {
        [Required]
        [Display(Name = "SMTP Host")]
        public string SmtpHost { get; set; }

        [Required]
        [Display(Name = "SMTP Port")]
        public int SmtpPort { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email From")]
        public string EmailFrom { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email To")]
        public string EmailTo { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}