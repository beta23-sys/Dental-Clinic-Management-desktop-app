using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class Prescription
    {
        private string _prescriptionID;
        private Patient _patient;
        private DateTime _date;
        private List<string> _listmedicines;

        public Prescription(string id, Patient patient, DateTime date, List<string> prescribedMedications)
        {
            _prescriptionID = id;
            _patient = patient;
            _date = date;
            _listmedicines = prescribedMedications;
        }

       
    }

}
