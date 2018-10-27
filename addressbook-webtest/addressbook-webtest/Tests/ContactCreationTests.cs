using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Имя")
            {
                Lastname = "Фамилия",
                Middlename = "Отчество",
                Photo = "E:\\!PROJECT\\Photo.txt"
            };
            app.Contacts.Create(contact);
        }

        /*[Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "", "", null);

            app.Contacts.Create(contact);
        }*/
    }
}
