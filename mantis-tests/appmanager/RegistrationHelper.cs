using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationPage();
            FillRegistrationForm(account);
            SubmitRegistration();

        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.18.0/login_page.php";
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);

        }

        private void OpenRegistrationPage()
        {
            driver.FindElement(By.LinkText("Зарегистрировать новую учетную запись")).Click();
        }
    }
}
