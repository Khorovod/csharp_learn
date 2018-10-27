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
        public class GroupRemovalTests : AuthTestBase
        {

            [Test]
            public void GroupModificationTest()
            {
                GroupData NewGroupData = new GroupData("изменить имя")
                {
                    Header = null,
                    Footer = null
                };

                app.Groups.Modify(1, NewGroupData);

            }

        }
    }
}
