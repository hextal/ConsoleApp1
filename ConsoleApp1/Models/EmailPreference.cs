using System;
using System.Collections.Generic;
using System.Text;

namespace UserEmailPreferencesFunction.Models
{
    public class EmailPreference
    {
        //UserID|IsUnsubscribed|AllowMarketingEmails|AllowMarketingSMS
        public Guid UserID { get; set; } //GUID
        public bool IsUnsubscribed { get; set; }
        public bool AllowMarketingEmails { get; set; }
        public bool AllowMarketingSMS { get; set; }


    }
}
