using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Контакт на подхвате");
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contact);
            }

            ContactData newContactData = new ContactData("нИмя", "нФамилия", "нОтчество", null);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newContactData);

            Assert.AreEqual(oldContacts.Count , app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContacts, newContact);
        }
    }
}