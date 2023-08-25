
using NDDTraining.Domain.Enums;

namespace NDDTraining.Domain.Models
{
    public  class Email
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public IDictionary<string , string> Parameters { get; set; } ///key, value
        public EmailType type { get; set; }


    }
}