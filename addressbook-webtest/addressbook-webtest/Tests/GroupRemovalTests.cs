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
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {

            GroupData groupData = new GroupData("Группа подхвата");

            if (! app.Groups.IsGroupPresent())
            {
                app.Groups.Create(groupData);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
