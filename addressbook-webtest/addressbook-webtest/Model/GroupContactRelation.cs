using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name ="address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name ="group_id")]
        public String GroupId { get; }

        [Column(Name = "id")]
        public String ContactId { get; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
    }
}
