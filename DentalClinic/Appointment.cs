using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    using System;

    public class Appointment
    {
        private string _appointmentID;
        private Patient _patient;
        private DateTime _date;
        private TimeSpan _time;
        private Treatment _treatment;
        private string _status;
       

        public Appointment(string id, Patient patient, DateTime date, TimeSpan time, Treatment treatmentDetails)
        {
            _appointmentID = id;
            _patient = patient;
            _date = date.Date;
            _time = time;
            _treatment = treatmentDetails;
            _status = "SCHEDULED";
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Patient PatientAppoinment
        {
            get { return _patient; }
        }

        public void CompleteAppointment(List<DentalSupplies> dentalSupplies, List<Treatment> treatments)
        {
            Status = "COMPLETED";
            Treatment treatment = treatments.Find(t => t.Id == _treatment.Id);
            if (treatment != null)
            {
                foreach (var supply in treatment.TreatmentSupplpies)
                {
                    var dentalSupply = dentalSupplies.Find(s => s.Id == supply.Key);
                    if (dentalSupply != null)
                    {
                        dentalSupply.DecreaseQuantity(supply.Value);
                    }
                }
            }
        }

        public string Id
        {
            get { return _appointmentID; }
        }

        public string DateTime
        {
            get { return $"{_date.ToString("d")} {_time.ToString()}"; }
        }

    
        public Treatment TreatmentDetails
        {
            get { return _treatment; }
        }

        
    }

}
