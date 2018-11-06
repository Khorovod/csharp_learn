using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allphones;
        private string allemails;

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Photo { get; set; }

        public string Id { get; set; }

        public string Adress { get;  set; }

        public string Homephone { get;  set; }

        public string Mobilephone { get;  set; }

        public string Workphone { get;  set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

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
                    return CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3);
                }
            }
            set
            {
                allemails = value;
            }
        }

        private string CleanUp(string info)
        {
            if(info == null /*|| phone = ""*/)
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
            return "Firstname =" + Firstname + "LasTname =" + Lastname;
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
    }
}
    
