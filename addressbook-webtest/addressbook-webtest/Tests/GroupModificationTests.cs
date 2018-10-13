using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupModificationTests
    {
        [TestFixture]
        public class GroupRemovalTests : TestBase
        {

            [Test]
            public void GroupModificationTest()
            {
                GroupData NewGroupData = new GroupData("изменить имя")
                {
                    Header = "изменить заголовок",
                    Footer = "изменить футер"
                };

                app.Groups.Modify(1, NewGroupData);

            }

        }
    }
}
