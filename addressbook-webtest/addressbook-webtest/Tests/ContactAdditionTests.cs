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
    public class ContactAdditionTests : TestBase
    {

        [Test]
        public void ContactAdditionTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitContactAddition();
            ContactData contact = new ContactData("Имя","Фамилия");
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactAddition();
            app.Auth.Logout();
        }
    }
}
