using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = GroupData.GettAllGroups()[0];
            List<ContactData> oldList = group.GetContactsFromGroup();

            ContactData contact = ContactData.GettAllContacts().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact , group);

            List<ContactData> newList = group.GetContactsFromGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
