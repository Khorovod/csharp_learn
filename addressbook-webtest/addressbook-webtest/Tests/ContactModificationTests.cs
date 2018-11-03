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
            ContactData contactData = new ContactData("Контакт на подхвате");
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contactData);
            }

            ContactData newContactData = new ContactData("нИмя", "нФамилия", "нОтчество", null);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toModify = oldContacts[0];

            app.Contacts.Modify(0, newContactData);

            Assert.AreEqual(oldContacts.Count , app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;

            oldContacts.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContacts, newContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == toModify.Id)
                {
                    Assert.AreEqual(newContactData.Firstname , contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
            }

        }
    }
}