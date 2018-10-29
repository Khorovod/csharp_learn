using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private string middlename;
        private string photo;

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }

        public ContactData(string firstname, string lastname, string middlename, string photo)
        {
        this.firstname = firstname;
        this.lastname = lastname;
        this.middlename = middlename;
        this.photo = photo;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }

            set
            {
                middlename = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
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
            return "Firstname is" + Firstname ;
        }

        //не один хешкод
        public override int  GetHashCode()
        {
            return 0;
        }

        public int CompareTo(ContactData other)
        {/* в методе CompareTo надо будет сравнить сначала фамилии и если они равны,
            то сравнить имена и возвратить результат. Иначе возвратить результат сравнения фамилий.*/
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname) + Lastname.CompareTo(other.Lastname);

        }
    }
}
    
