﻿using System;
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
            ContactData contactData = new ContactData("Контакт на подхвате");
            if (! app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contactData);
            }

            List<ContactData> oldContacts = ContactData.GettAllContacts();
            ContactData toRemove = oldContacts[0];

            app.Contacts.RemoveFirstContact(toRemove);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GettAllContacts();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            foreach (  ContactData contact in newContacts)
            {
                //ожидаемый результат,фактический результат
                //
                Assert.AreNotEqual(contact.Id , toRemove.Id);
            }

        }

    }
}