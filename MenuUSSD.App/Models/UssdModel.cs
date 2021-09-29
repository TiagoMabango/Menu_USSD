using System;
using System.ComponentModel.DataAnnotations;

namespace MenuUssd.App.Models
{
    public class UssdModel
    {
        [Required]
        public string SessionId { get; set; }
        public string ShortCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Text { get; set; }

        public bool Validate()
        {
            string shortCodePattern = "4050";

            var result = !string.IsNullOrEmpty(SessionId) && ShortCode.StartsWith(shortCodePattern);

            return result;

        }
    }
}
