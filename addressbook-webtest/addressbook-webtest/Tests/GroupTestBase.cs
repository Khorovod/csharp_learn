using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUi = app.Groups.GetGroupsList();
                List<GroupData> fromDb = GroupData.GettAllGroups();
                fromUi.Sort();
                fromDb.Sort();

                Assert.AreEqual(fromUi, fromDb);

            }
        }

    }
}
