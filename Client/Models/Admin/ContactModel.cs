using System.ComponentModel.DataAnnotations;

namespace JMSWAResume.Models.Admin
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(128, ErrorMessage = "Name must be at least 8 characters long.", MinimumLength = 8)]
        public string Name
        {
            get; set;
        }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email
        {
            get; set;
        }

        [Required(ErrorMessage = "Please enter a subject.")]
        [StringLength(128, ErrorMessage = "Subject must be at least 8 characters long.", MinimumLength = 8)]
        public string Subject
        {
            get; set;
        }

        [Required(ErrorMessage = "Please enter a message.")]
        [StringLength(512, ErrorMessage = "Message must be at least 8 characters long.", MinimumLength = 8)]
        public string Message
        {
            get; set;
        }
    }
}
