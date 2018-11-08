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
        public void PageAndEditorContactInfoTest()
        {
            ContactData fromPage = app.Contacts.GetContactInfoFromPage(0); 
            ContactData fromEditor = app.Contacts.GetContactInfoFromEditor(0);

            Assert.AreEqual(fromPage, fromEditor);
            Assert.AreEqual(fromPage.Adress, fromEditor.Adress);
            Assert.AreEqual(fromPage.Allphones, fromEditor.Allphones);
            Assert.AreEqual(fromPage.Allemails, fromEditor.Allemails);


        }

        [Test]
        public void DetailsAndEditorContactInfoTest()
        {
            ContactData fromDetails = app.Contacts.GetContactInfoFromDetails();
            //ContactData fromEditor = app.Contacts.GetContactInfoFromEditor(0);
            System.Console.Write(fromDetails);
            //Assert.AreEqual(fromDetails, fromEditor);

        }


    }
}
