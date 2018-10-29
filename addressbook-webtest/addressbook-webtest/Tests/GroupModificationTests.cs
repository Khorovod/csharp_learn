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
                GroupData groupData = new GroupData("Группа подхвата");

                if (!app.Groups.IsGroupPresent())
                {
                    app.Groups.Create(groupData);
                }

                GroupData NewGroupData = new GroupData("изменилгруппу")
                {
                    Header = null,
                    Footer = null
                };

                List<GroupData> oldGroups = app.Groups.GetGroupsList();

                app.Groups.Modify(0, NewGroupData);

                List<GroupData> newGroups = app.Groups.GetGroupsList();
                oldGroups[0].Name = NewGroupData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);

            }

        }
    }
}
