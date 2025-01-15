using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class Dentist : Person
    {
        public Dentist(string id, string name, int age, string contactinfo):base(id,name,age,contactinfo)
        {
           
        }

        public override string Name
        {
            get { return $"Dr.{base.Name}"; }
            set { base.Name = value; }
        }

        }
    }
