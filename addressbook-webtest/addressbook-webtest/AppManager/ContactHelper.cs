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
            GoToContactPage();

            return this;
        }

        public ContactHelper Modify(int d , ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            SelectContact(d);
            InitContactModification(0);
            FillContactForm(contact);
            SubmitContactModification();
            GoToContactPage();

            return this;
        }

        public ContactHelper RemoveFirstContact(int f)
        {
            manager.Navigator.GoToContactPage();
            SelectContact(f);
            DeleteContact();
            ApproveContactDeletion();
            GoToContactPage();
            return this;
        }

        public ContactHelper GoToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
   
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper ShowContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactAddition()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("photo"), contact.Photo);
            Type(By.Name("adress"), contact.Adress);
            Type(By.Name("home"), contact.Homephone);
            Type(By.Name("mobile"), contact.Mobilephone);
            Type(By.Name("work"), contact.Workphone);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);


            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys("123");

            /*driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("123");

            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("123");

            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("123");

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
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact (int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        //хм
        public ContactHelper ApproveContactDeletion()
        {
            acceptNextAlert = true;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            //driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper DeclineContactDeletion()
        {
            //driver.SwitchTo().Alert().Dismiss();
            acceptNextAlert = false;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCache = null;
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

        public List<ContactData> contactCache = null;

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.CssSelector("td"));

                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public bool IsContactPresent()
        {
            manager.Navigator.GoToContactPage();
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])"));
        }

        public ContactData GetContactInfoFromPage(int index)
        {
            manager.Navigator.GoToContactPage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string adress = cells[3].Text;
            string allemails = cells[4].Text;
            string allphones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Adress = adress,
                Allphones = allphones,
                Allemails = allemails
            };
        }

        public ContactData GetContactInfoFromEditor(int index)
        {
            manager.Navigator.GoToContactPage();
            InitContactModification(0);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string adress = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homephone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilephone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workphone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Adress = adress,
                Homephone = homephone,
                Mobilephone = mobilephone,
                Workphone = workphone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

        }

        public ContactData GetContactInfoFromDetails()
        {
            manager.Navigator.GoToContactPage();
            ShowContactDetails(0);
            IList<IWebElement> block = driver.FindElements(By.Id("content"));
            /*подумой
            string lastname = .Text;
            string firstname = .Text;
            string adress = .Text;
            string allemails = .Text;
            string allphones = .Text;*/
            return null;
        }


        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToContactPage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

    }
}
