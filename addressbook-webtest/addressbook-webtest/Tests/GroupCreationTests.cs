﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                    Name = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            List <GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Create(group);

            //int count = app.Groups.GetGroupsCount();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void BadGroupCreationTest()
        {
            GroupData group = new GroupData("a'q")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count , app.Groups.GetGroupsCount());

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            Assert.AreEqual(oldGroups.Count , newGroups.Count);
        }
    }
}
