using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class Payment
    {
        private string _paymentID;
        private Appointment _appointmentPayment;
        private double _totalpaid;
        private DateTime _date;
        private TimeSpan _time;
        private string _method;

        public Payment(string id, Appointment appointment, double totalpaid, DateTime date)
        {
            _paymentID = id;
            _appointmentPayment = appointment;
            _totalpaid = totalpaid;
            _date = date.Date;
            _time = date.TimeOfDay;
            _method = "CARD";
        }

        public void CompletePayment(List<Appointment> appointments, List<DentalSupplies> dentalSupplies, List<Treatment> treatments)
        {
            var appointment = appointments.Find(a => a.PatientAppoinment.Id == _appointmentPayment.PatientAppoinment.Id && a.Status == "SCHEDULED");
            if (appointment != null)
            {
                appointment.CompleteAppointment(dentalSupplies, treatments);
            }
        }

        public void GenerateInvoice()
        {
            Console.Clear();
            Console.WriteLine("===== Dental Clinic ======");
            Console.WriteLine("3000 Unknown Town Centre");
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine("Invoice for patient ID: " + _appointmentPayment.PatientAppoinment.Id);

            
            
            Console.WriteLine($"Appointment ID: {_appointmentPayment.Id}, Date: {_appointmentPayment.DateTime} \nTreatment Details: {_appointmentPayment.TreatmentDetails.Name} - ${_appointmentPayment.TreatmentDetails.Cost}");
            double totalDue = _appointmentPayment.TreatmentDetails.Cost;
            double discountedAmount = _appointmentPayment.PatientAppoinment.UseDiscount(totalDue);
            double totalDiscount = totalDue - discountedAmount;

          
            Console.WriteLine($"Payment method: CARD");
            Console.WriteLine($"Total Discount: ${totalDiscount}\n");
            Console.WriteLine($"\nTotal Due: ${discountedAmount}, Total Paid: ${_totalpaid}, Balance: ${discountedAmount-_totalpaid}\n");
        }

        public Appointment AppointmentPayment
        {
            get { return _appointmentPayment; }
        }

        public double TotalPaid
        {
            get { return _totalpaid; }
        }

        public string PaymentMethod
        {
            get { return _method; }
        }

        public string PaymentDate
        {
            get { return $"{_date.ToString("yyyy-MM-dd")}"; }
        }

        public string Time
        {
            get { return $"{_time}"; }
        }

        public string Id
        {
            get { return _paymentID; }
        }
    }

}
