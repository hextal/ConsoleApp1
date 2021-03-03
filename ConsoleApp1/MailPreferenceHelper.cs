using System;
using UserEmailPreferencesFunction.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class MailPreferenceHelper
    {
        /// <summary>
        /// Allows for the creation of a mailing list 
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static List<EmailPreference> createMailingList(string[] lines)
        {
            var mailingList = new List<EmailPreference>();

            for (int j = 1; j < lines.Length; j++)
            {

                var col = lines[j].Split('|');
                for (int i = 0; i < col.Length; i += 4)
                {
                    var record = new EmailPreference
                    {
                        UserID = System.Guid.Parse(col[i]),
                        IsUnsubscribed = bool.Parse(col[i + 1]),
                        AllowMarketingEmails = bool.Parse(col[i + 2]),
                        AllowMarketingSMS = bool.Parse(col[i + 3])
                    };
                    mailingList.Add(record);
                }
            }

            return mailingList;

        }

        /// <summary>
        /// Sorts a mailling list 
        /// </summary>
        /// <param name="mailingList"></param>
        /// <returns></returns>
        public static List<EmailPreference> sortMailingList(List<EmailPreference> mailingList)
        {
            var sortedList = mailingList
               .OrderBy(user => user.UserID)
               .OrderBy(user => !user.IsUnsubscribed)
               .OrderBy(user => user.AllowMarketingEmails)
               .OrderBy(user => user.AllowMarketingSMS)
               .ToList();

            return sortedList;

        }

        /// <summary>
        /// prints a mailing list in a pipe delimited format
        /// </summary>
        /// <param name="mailingList"></param>
        public static void printMailingList(List<EmailPreference> mailingList)
        {
            foreach (EmailPreference user in mailingList)
            {
                Console.WriteLine(user.UserID + " | " + user.IsUnsubscribed + " | " + user.AllowMarketingEmails + " | " + user.AllowMarketingSMS);
            }
        }
    }
}
