using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("нИмя", "нФамилия", "нОтчество", "E:\\!PROJECT\\Photo2.txt");

            app.Contacts.Modify(newContactData);
        }
    }
}