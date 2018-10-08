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
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactAddition();
            ContactData contact = new ContactData("Имя","Фамилия");
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactAddition();
            loginHelper.Logout();
        }
    }
}
