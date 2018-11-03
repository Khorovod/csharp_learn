using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInfoTests : AuthTestBase
    {
        [Test]
        public void TestContactInfo()
        {
            ContactData fromPage = app.Contacts.GetContactInfoFromPage(0); 
            ContactData fromEditor = app.Contacts.GetContactInfoFromEditor(0);

            Assert.AreEqual(fromPage, fromEditor);
            Assert.AreEqual(fromPage.Adress, fromEditor.Adress);
            Assert.AreEqual(fromPage.Allphones, fromEditor.Allphones);


        }

    }
}
