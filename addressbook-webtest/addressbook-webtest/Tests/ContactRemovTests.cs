using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Контакт на подхвате");
            if (! app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveFirstContact(0);
            app.Contacts.ApproveContactDeletion();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

        }
        [Test]
        public void DeclineContactRemovalTest()
        {
            ContactData contact = new ContactData("Контакт на подхвате");
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveFirstContact(0);
            app.Contacts.DeclineContactDeletion();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts, newContacts);

        }


    }
}