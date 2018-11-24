using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');

                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });

            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            List <GroupData> oldGroups = GroupData.GettAllGroups();

            app.Groups.Create(group);

            //int count = app.Groups.GetGroupsCount();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = GroupData.GettAllGroups();
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

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start =  DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupsList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GettAllGroups();
            //db.Close(); можно не использовать
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }
        [Test]
        public void TestDBContactsInGroup()
        {
            foreach (ContactData contact in GroupData.GettAllGroups()[0].GetContactsFromGroup())
            {
                System.Console.Out.WriteLine(contact);
            }

        }

    }
}
