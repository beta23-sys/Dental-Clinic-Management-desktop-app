using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{

    public class Patient : Person
    {
        private Insurance _insurancedetails;
        private IConcession _concession;


        public Patient(string id, string name, int age, string contactInfo, Insurance insuranceDetails, IConcession concession)
            : base(id, name,age, contactInfo)
        {
            _insurancedetails= insuranceDetails;
            _concession = concession;
        }

        public Insurance InsuranceDetails
        {
            get { return _insurancedetails; }
        }

        public double UseDiscount(double finalprice)
        {
            
            if (_concession != null)
            {
                finalprice = _concession.GetDiscountedPrice(finalprice);
            }
            if (InsuranceDetails != null)
            {
                finalprice += 0.2 * finalprice; 
            }
            return finalprice;
        }

        public void PatientInfo()
        {
            Console.WriteLine($"ID: {base.Id}, Name: {base.Name}, Age: {base.Age}, Contact Info: {base.ContactInfo}");
        }
   

    }

}
