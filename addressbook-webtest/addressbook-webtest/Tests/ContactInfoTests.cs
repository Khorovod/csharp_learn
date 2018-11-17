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
            //нужно вытащить все из деталей    и склеить такое же из едитора  
            string  fromDetails = app.Contacts.GetContactInfoFromDetails();
            ContactData fromEditor = app.Contacts.GetContactInfoFromEditor(0);
            System.Console.Write(fromDetails);
            System.Console.Write(fromEditor);
            System.Console.Write(fromEditor.AllData);

            Assert.AreEqual(fromDetails, fromEditor.AllData);


        }


    }
}
