using UserEmailPreferencesFunction.Models;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class MailPreferenceCreator
    {
        static void Main(string[] args)
        {
            //read file 
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Hassan\source\repos\Challangesolution\ConsoleApp1\user-preferences.txt");

            //create mailing list
            List<EmailPreference> mailingList = MailPreferenceHelper.createMailingList(lines);

            //sort mailing list 
            List<EmailPreference> sortedList = MailPreferenceHelper.sortMailingList(mailingList);

            //print mailing list
            MailPreferenceHelper.printMailingList(sortedList);

        }
        
    }
}

