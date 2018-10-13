using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            InitContactAddition();
            FillContactForm(contact);
            SubmitContactAddition();

            return this;
        }

        public ContactHelper Modify(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            InitContactModification();
            FillContactForm(contact);
            SubmitContactModification();

            return this;
        }

        public ContactHelper RemoveFirstContact(int f)
        {
            manager.Navigator.GoToContactPage();
            SelectContact(f);
            DeleteContact();

            return this;
        }
   
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper InitContactAddition()
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {

            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);

            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);

            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);

            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys("123");

            driver.FindElement(By.Name("photo")).SendKeys(contact.Photo);

            /*driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("123");

            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("123");

            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys("123");

            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys("123");

            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys("123");

            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys("123");

            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("123");

            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("123");

            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys("123");

            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys("123");

            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys("123");

            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");

            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");

            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys("1234");

            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("1");

            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("January");

            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("1234");

            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys("12");

            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys("12");

            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys("12");*/
            return this;
        }

        public ContactHelper SubmitContactAddition()
        {
            // driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper SelectContact (int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ApproveContactDeletion()
        {
            acceptNextAlert = true;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper DeclineContactDeletion()
        {
            acceptNextAlert = false;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }



        public bool acceptNextAlert;

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
