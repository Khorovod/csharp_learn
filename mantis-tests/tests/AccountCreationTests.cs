using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]

        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");

            using (Stream localfile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.UploadFile("/config_inc.php", localfile);
            }

        }

        [Test]
        public void AccountRegistrationTests()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registrator.Register(account);

        }

        [TestFixtureTearDown]

        public void RestoreConfig()
        {
            app.Ftp.RestoreBackUpFile("/config_inc.php");
        }
    }
}
