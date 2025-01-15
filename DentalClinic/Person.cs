using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public abstract class Person
    {
        private string _personID;
        private string _name;
        private int _age;
        private string _contact;

        public Person(string id, string name, int age, string contactInfo)
        {
            _personID = id;
            _name = name.ToUpper();
            _age = age;
            _contact = contactInfo;
        }


        public string Id
        {
            get { return _personID; }
        }

        public  virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string ContactInfo
        {
            get { return _contact; }
            set { _contact = value; }
        }



    }
}
