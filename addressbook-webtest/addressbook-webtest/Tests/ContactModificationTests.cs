using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("нИмя", "нФамилия", "нОтчество", null);

            app.Contacts.Modify(newContactData);
        }
    }
}