using NUnit.Framework;
using UserEmailPreferencesFunction.Models;
using System.Collections.Generic;
using ConsoleApp1;


namespace NUnitTestProject1
{
    public class MailPreferenceTest
    {

        [Test]
        public void createMailingListTest()
        {
            //Arrange 
            string[] lines = new string[2];
            lines[0] = "5bc49355-94e3-4dc7-a79f-0da4306760f3|true|true|true";
            lines[1] = "482b077d-a8c4-4385-9e6a-3e8fe0c88b8b|true|false|false";

            //Act 
            List<EmailPreference> mailingList = MailPreferenceHelper.createMailingList(lines);

            //Assert
            Assert.IsNotEmpty(mailingList);

        }

        [Test]
        public void sortMailingListTest()
        {
            //Arrange 
            string[] lines = new string[2];
            lines[0] = "5bc49355-94e3-4dc7-a79f-0da4306760f3|true|true|true";
            lines[1] = "482b077d-a8c4-4385-9e6a-3e8fe0c88b8b|true|false|false";

            EmailPreference myPreference = new EmailPreference();
            myPreference.UserID = System.Guid.Parse("5bc49355-94e3-4dc7-a79f-0da4306760f3");
            myPreference.IsUnsubscribed = true;
            myPreference.AllowMarketingEmails = true;
            myPreference.AllowMarketingSMS = true;

            EmailPreference mySecondPreference = new EmailPreference();
            mySecondPreference.UserID = System.Guid.Parse("482b077d-a8c4-4385-9e6a-3e8fe0c88b8b");
            mySecondPreference.IsUnsubscribed = true;
            mySecondPreference.AllowMarketingEmails = false;
            mySecondPreference.AllowMarketingSMS = false;

            List<EmailPreference> mailingList = new List<EmailPreference>();
            mailingList.Add(myPreference);
            mailingList.Add(mySecondPreference);

            //Act 
            List<EmailPreference> sortedList = MailPreferenceHelper.sortMailingList(mailingList);

            //Assert
            Assert.That(sortedList.IndexOf(mySecondPreference).Equals(0));

        }

    }
}
