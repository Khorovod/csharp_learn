﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allphones;
        private string allemails;
        private string fromEditor;

        public ContactData()
        {}

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        public string Photo { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public string Adress { get;  set; }

        public string Homephone { get;  set; }

        public string Mobilephone { get;  set; }

        public string Workphone { get;  set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string Allphones
        {
            get
            {
                if (allphones != null)
                {
                    return allphones;
                }
                else
                {
                    return (CleanUp(Homephone) + CleanUp(Mobilephone) + CleanUp(Workphone)).Trim();
                }
            }
            set
            {
                allphones = value;
            }
        }

        public string Allemails
        {
            get
            {
                if (allemails != null)
                {
                    return allemails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allemails = value;
            }
        }
          /*
        public string AllData
        {
            get
            {
                if (fromEditor == "" || fromEditor == null)
                {

                    return "";

                }
                else
                {
                    return (Firstname + " " + Middlename + " " + Lastname + "\r\n"
                            + Adress + "\r\n\r\n"
                            + "H: " + Homephone + "\r\n"
                            + "M: " + Mobilephone + "\r\n"
                            + "W: " + Workphone + "\r\n\r\n"
                            + Email + "\r\n"
                            + Email2 + "\r\n"
                            + Email3 + "\r\n").Trim();
                }
            }
            set
            {
                fromEditor = value;
            }
        }
        */

        public string AllData
        {
            get
            {
                if (Firstname != null || Firstname != "")
                {
                    return Firstname + " ";
                }  

                if (Middlename != null || Middlename != "")
                {
                    return Middlename + " ";
                }

                if (Lastname != null || Lastname != "")
                {
                    return Lastname + " " + "\r\n";
                }

                if (Adress != null || Adress != "")
                {
                    return Adress + "\r\n\r\n";
                }

                if (Homephone != null || Homephone != "")
                {
                    return "H: " + Homephone + "\r\n";
                }

                if (Mobilephone != null || Mobilephone != "")
                {
                    return "M: " + Mobilephone + "\r\n";
                }

                if (Workphone != null || Workphone != "")
                {
                    return "W: " + Workphone + "\r\n\r\n";
                }

                if (Email != null || Email != "")
                {
                    return Email + "\r\n";
                }

                if (Email2 != null || Email2 != "")
                {
                    return Email2 + "\r\n";
                }

                if (Email3 != null || Email3 != "")
                {
                    return Email3 + "\r\n";
                }
                return "";
            }
            set
            {
                fromEditor = value;
            }
        }
        

        private string CleanUp(string info)
        {
            if (info == null || info == "")
            {
                return "";
            }
            return Regex.Replace(info, "[ ()-]" , "") + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override string ToString()
        {
            return "Firstname =" + Firstname + "Lastname =" + Lastname;
        }

        //не один хешкод
        public override int  GetHashCode()
        {
            return 0;
        }

        public int CompareTo(ContactData other)
        {/*  сравнить сначала фамилии и если они равны,
            то сравнить имена и возвратить результат
            Иначе возвратить результат сравнения фамилий.*/

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);

        }

        public static List<ContactData> GettAllContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }

        }
    }
}
    
