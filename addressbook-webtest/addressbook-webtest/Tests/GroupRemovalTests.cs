using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {

            GroupData groupData = new GroupData("Группа подхвата");

            if (! app.Groups.IsGroupPresent())
            {
                app.Groups.Create(groupData);
            }

            List<GroupData> oldGroups = GroupData.GettAllGroups();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = GroupData.GettAllGroups();
            oldGroups.RemoveAt(0);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id , toBeRemoved.Id );
            }

        }

    }
}
