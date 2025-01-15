using System;
using System.Collections.Generic;


namespace DentalClinic
{
 

    class Program
    {
        static List<Patient> patients = new List<Patient>();
        static List<Appointment> appointments = new List<Appointment>();
        static List<Payment> payments = new List<Payment>();
        static List<Treatment> treatments = new List<Treatment>();
        static List<DentalSupplies> dentalSupplies = new List<DentalSupplies>();
        static List<Supplier> suppliers = new List<Supplier>();
        static List<Order> orders = new List<Order>();
        static List<OrderDetail> orderItems = new List<OrderDetail>();
        static List<Dentist> dentists = new List<Dentist>();
        static List<Insurance> insurances = new List<Insurance>();
        static List<Prescription> prescriptions = new List<Prescription>();

        static void Main()
        {
            // Sample Data
            Treatment cleaning = new Treatment("T1", "Cleaning", 70);
            Treatment filling = new Treatment("T2", "Filling", 100);
            Treatment extraction = new Treatment("T3", "Extraction", 150);

            Dentist smith = new Dentist("DNT1", "Smith", 50, "1234567890");
            Dentist johnson = new Dentist("DNT2", "Johnson", 47, "9876543210");
            Dentist richard = new Dentist("DNT3", "Richard", 40, "4444552610");

            Patient edward = new Patient("PTN1", "edward elrick", 51, "4442332344", new Insurance("IN1","edward elrick","324444444"), null);
            Patient robert = new Patient("PTN2", "robert", 36, "5545332333", null, null);
            Patient mona = new Patient("PTN3", "mona", 18, "5945332333", new Insurance("IN2", "mona", "455555555"), new StudentConcession ("80943900"));

            treatments.Add(cleaning);
            treatments.Add(filling);
            treatments.Add(extraction);

            dentists.Add(smith);
            dentists.Add(johnson);
            dentists.Add(richard);

            treatments[0].UpdateDentistTreatment(johnson);

            patients.Add(edward);
            patients.Add(robert);
            patients.Add(mona);

            dentalSupplies.Add(new Medication("DSP1", "Painkiller", 43, "100mg"));
            dentalSupplies.Add(new Medication("DSP2", "Antibiotic", 92, "50mg"));
            dentalSupplies.Add(new ProtectiveEquipment("DSP3", "Gloves", 65));
            dentalSupplies.Add(new DentalTool("DSP4", "Scalpel", 80));
            dentalSupplies.Add(new ProtectiveEquipment("DSP5", "Mask", 5));

            suppliers.Add(new Supplier("SP1", "Pharma Supplier", "1234 Main St", "1234567890"));
            suppliers.Add(new Supplier("SP2", "Health Supplier", "5678 Elm St", "9876543210"));

            appointments.Add(new Appointment("APT1", patients[0], DateTime.Today.AddDays(-33), TimeSpan.Parse("12:00"), treatments[0]));
            appointments.Add(new Appointment("APT2", patients[1], DateTime.Today.AddDays(-23), TimeSpan.Parse("20:11"), treatments[2]));
            appointments.Add(new Appointment("APT3", patients[2], DateTime.Today.AddDays(-23), TimeSpan.Parse("09:00"), treatments[1]));
            appointments.Add(new Appointment("APT4", patients[0], DateTime.Today, TimeSpan.Parse("10:30"), treatments[0]));
            appointments.Add(new Appointment("APT5", patients[1], DateTime.Today, TimeSpan.Parse("11:00"), treatments[2]));

            appointments[0].Status = "COMPLETED";
            appointments[1].Status = "COMPLETED";
            appointments[2].Status = "COMPLETED";
            appointments[3].Status = "COMPLETED";

            payments.Add(new Payment("PY1", appointments[0], 234, DateTime.Today.AddDays(-23).AddHours(9)));
            payments.Add(new Payment("PY2", appointments[1], 44, DateTime.Today.AddDays(-13).AddHours(9)));
            payments.Add(new Payment("PY3", appointments[2], 34, DateTime.Today.AddDays(-3).AddHours(9)));
            payments.Add(new Payment("PY4", appointments[3], 204, DateTime.Today.AddHours(9)));

            // Link treatments to supplies
            treatments[0].AddSupply("DSP3", 4);
            treatments[1].AddSupply("DSP3", 4);
            treatments[2].AddSupply("DSP3", 2);
            treatments[1].AddSupply("DSP4", 3); 
            treatments[2].AddSupply("DSP4", 5);


            while (true)
            {
                Console.WriteLine("Dental Clinic Management System");
                Console.WriteLine("1. Front-End Operations");
                Console.WriteLine("2. Back-End Operations");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        FrontOperationMenu.ShowFrontOperationMenu();
                        break;
                    case "2":
                        BackOperationMenu.ShowBackOperationMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }
            }
        }

        public static void CreatePatient()
        {
            string patientId = $"PTN{patients.Count + 1}";
            Console.Write("Enter patient's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter contact info: ");
            string contactInfo = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            
            Insurance insuranceDetails = null;
            Console.Write("Does the patient have insurance? (y/n): ");
            bool hasInsurance = Console.ReadLine().ToUpper() == "Y";
            if (hasInsurance)
            {
                string insuranceId = $"IN{insurances.Count + 1}";
                Console.Write("Enter insurance provider name: ");
                string providerName = Console.ReadLine().ToUpper();
                Console.Write("Enter insurance policy number: ");
                string policyNumber = Console.ReadLine();
                insuranceDetails = new Insurance(insuranceId, providerName, policyNumber);
                insurances.Add(insuranceDetails);
            }

            IConcession pconcession = null;
            Console.Write("Enter discount type (STUDENT/SENIOR/VETERAN/NONE): ");
            string concession = Console.ReadLine().ToUpper();
            if(concession!="NONE")
            {
                Console.Write("Enter Concession Id: ");
                string concessionId = Console.ReadLine();
                switch (concession)
                {
                    case "STUDENT":
                        pconcession = new StudentConcession(concessionId);
                        break;
                    case "SENIOR":
                        pconcession = new SeniorConcession(concessionId);
                        break;
                    default:
                        pconcession = new VeteranConcession(concessionId);
                        break;
                }
            }
            patients.Add(new Patient(patientId, name, age, contactInfo, insuranceDetails,pconcession));
            Console.Clear();
            Console.WriteLine("Patient added successfully.\n");
        }

        public static void CreateAppointment()
        {
            Console.Clear();
            ListofTreatment();

            string appointmentId = $"APT{appointments.Count + 1}";
            Console.Write("\nEnter patient Id: ");
            string patientid= Console.ReadLine().ToUpper();

            Patient patient = patients.Find(p => p.Id == patientid);
            if(patient==null)
            {
                Console.WriteLine("Couldn't find patient Id!");
                return;
            }

            DateTime date = DateTime.Now;
            TimeSpan time = TimeSpan.FromHours(0);
           
            try
            {
                Console.Write("Enter appointment date (YYYY-MM-DD): ");
                date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter appointment time (HH:MM): ");
                time = TimeSpan.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n");
                return;
            }

            Console.Write("Enter treatment Id: ");
            string treatmentId = Console.ReadLine().ToUpper();

            
            Treatment treatment = treatments.Find(t => t.Id == treatmentId);
            if(treatment==null)
            {
                Console.WriteLine("Couldn't find treatment Id!");
                return;
            }
            appointments.Add(new Appointment(appointmentId, patient, date, time, treatment));
            Console.WriteLine($"Appointment {appointmentId} created.\n");
        }

        public static void CreatePayment()
        {
            Console.Clear();
            string paymentId = $"PY{payments.Count+1}";
            Console.Write("Enter patient ID: ");
            string patientId = Console.ReadLine().ToUpper();

            
            Appointment patientAppointment = appointments.Find(p => p.PatientAppoinment.Id == patientId);

            if (patientAppointment ==null)
            {
                 Console.WriteLine("Couldn't find patient\n");
                 return;
            }
                

            Appointment treatmentcost = appointments.Find(a => a.PatientAppoinment.Id == patientId && a.Status == "SCHEDULED");
            if (treatmentcost == null)
            {
                Console.WriteLine("No scheduled appointment found for this patient.");
                return;
            }

            double finalcost = patientAppointment.PatientAppoinment.UseDiscount(treatmentcost.TreatmentDetails.Cost);

            Console.WriteLine($"Total: ${finalcost}");

            DateTime date = DateTime.Now;
            Payment payment = new Payment(paymentId, patientAppointment, finalcost, date);
            payment.CompletePayment(appointments, dentalSupplies, treatments);
            payments.Add(payment);

            Console.Clear();
            Console.WriteLine($"Payment {paymentId} of amount ${finalcost} for patient {patientId} success. \n");
            

            Console.Write("\n1. To generate Invoice \n0. Back\n");
            Console.Write("Enter your choice: ");
            string opt = Console.ReadLine().ToUpper();
            if(opt=="1")
            {
                payment.GenerateInvoice();
            }       
        }
        
        public static void CancelAppointment()
        {
            Console.Clear();
            ListofAppointment();
            Console.Write("Enter appointment ID to cancel: ");
            string appointmentId = Console.ReadLine().ToUpper();
            Appointment appointment = appointments.Find(a => a.Id == appointmentId);

            if (appointment != null)
            {
                appointment.Status = "CANCLED";
                Console.WriteLine($"Appointment {appointmentId} has been canceled.\n");
            }
            else
            {
                Console.WriteLine($"Appointment {appointmentId} not found.\n");
            }
        }

        public static void CreatePrescription()
        {
            Console.Write("Enter Patient ID: ");
            string patientId = Console.ReadLine().ToUpper();
            Patient patient = patients.Find(p => p.Id == patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.\n");
                return;
            }

            DateTime date = DateTime.Now;
            string prescriptionId = $"PRC{date.ToString("d")}";

            List<string> medications = new List<string>();
            Console.Write("Enter number of medications: ");
            int numOfMedications = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfMedications; i++)
            {
                Console.Write($"Enter medication {i + 1}: ");
                medications.Add(Console.ReadLine());
            }

            prescriptions.Add(new Prescription(prescriptionId, patient, date, medications));
            Console.WriteLine("Prescription created successfully.\n");
        }
    

        public static void CreateOrder()
        {
            string orderId = $"ORD{orders.Count + 1}";
            Console.WriteLine("Suppliers available:");
            foreach (Supplier s in suppliers)
            {
                s.DisplaySupplier();
            }
            Console.Write("Enter supplier ID: ");
            string supplierId = Console.ReadLine().ToUpper();
            Supplier supplier = suppliers.Find(s => s.Id == supplierId);

            DateTime orderDate = DateTime.Now;



            
            List<OrderDetail> listorderofitems = new List<OrderDetail>();
            double totalAmout = 0;
            while (true)
            {
                Console.WriteLine("Available Dental Supplies:");
                foreach (var supply in dentalSupplies)
                {
                    Console.WriteLine($"ID: {supply.Id}, Name: {supply.Name}, Cost: ");
                }
                Console.Write("Enter supply ID to add to order (or 'done' to finish): ");
                string input = Console.ReadLine().ToUpper();
                if (input.ToUpper() == "DONE")
                {
                    break;
                }
                string supplyId = input;
                DentalSupplies supplyToAdd = dentalSupplies.Find(s => s.Id == supplyId);
                if (supplyToAdd != null)
                {
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter cost: ");
                    double cost = double.Parse(Console.ReadLine());
                    totalAmout += cost;
                    OrderDetail orderItem = new OrderDetail($"ORDD{orderItems.Count + 1}",supplyToAdd, quantity, cost);
                    listorderofitems.Add(orderItem);
                    
                    Console.WriteLine($"Dental Supply {supplyToAdd.Name} added to order");
                }
                else
                {
                    Console.WriteLine("Invalid supply ID, please try again.");
                }
            }
            Order order = new Order(orderId, supplier, orderDate,listorderofitems,totalAmout);
            order.UpdateInventoryIncrease(dentalSupplies);
            
            orders.Add(order);
            Console.Clear();
            Console.WriteLine($"Order {orderId} created for supplier {supplierId}.\n");
        }

        public static void ViewOrders()
        {
            Console.WriteLine("Orders:");
            foreach (Order order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Supplier ID: {order.OrderSupplier.Id}, Order Date: {order.OrderDate}");
                foreach (OrderDetail item in order.Listitem)
                {
                    var supply = dentalSupplies.Find(s => s.Id == item.Item.Id);
                    Console.WriteLine($"  Dental Supply: {supply.Name}, Quantity: {item.Quantity}, Cost: {item.Cost}");
                }
                Console.WriteLine($"Total: ${order.TotalAmountofOrder}\n" +
                    $"");
            }
            
            
        }

        public static void InventoryReport()
        {
            Console.Clear();
            Console.WriteLine("==== Inventory Report ====");
            foreach (var supply in dentalSupplies)
            {
                supply.DisplaySupplies();             
            }
            Console.WriteLine("");
        }

        public static void ViewAllSales()
        {
            Console.WriteLine("==== Sales Report ====");
            double totalSales = 0;
            foreach (Payment payment in payments)
            {
                Console.WriteLine($"ID: {payment.Id}, Date: {payment.PaymentDate}, Total Paid: ${payment.TotalPaid}, Method: {payment.PaymentMethod}");
                totalSales += payment.TotalPaid;
            }
            Console.WriteLine($"\nTotal Sales: ${totalSales}\n");
           
        }

        public static void ViewTodaySales()
        {
            int count = 1;
            Console.WriteLine("==== Today Sales Report ====");
            DateTime datetime =  DateTime.Today;
            string today = $"{datetime.Date.ToString("yyyy-MM-dd")}";
            double totalSales = 0;
            foreach (Payment payment in payments)
            {
                if (payment.PaymentDate == today)
                {
                    Console.WriteLine($"ID: {payment.Id}, Date: {payment.PaymentDate}, Total Paid: ${payment.TotalPaid}, Method: {payment.PaymentMethod}");
                    totalSales += payment.TotalPaid;
                }
            }
            Console.WriteLine($"\nTotal Sales: ${totalSales}\n");
        }

        public static void ViewDentists()
        {
            Console.WriteLine("Dentists:");
            foreach (Dentist dentist in dentists)
            {
                Console.WriteLine($"ID: {dentist.Id}, Name: {dentist.Name}, Contact: {dentist.ContactInfo}");
            }
            Console.WriteLine("");
        }

        public static void ListofAppointment()
        {
            int count = 1;
            Console.WriteLine("List of Scheduled Appointment");
            foreach (Appointment l in appointments )
            {
                if(l.Status=="SCHEDULED")
                {
                    Console.WriteLine($"{count++}. {l.Id} - {l.DateTime}");
                }
            }
            Console.WriteLine("\n");
        }

        public static void ListPatients()
        {
            Console.WriteLine("Patients:");
            foreach (Patient patient in patients)
            {
                patient.PatientInfo();
            }
            Console.WriteLine("");
        }

        public static void UpdatePatient()
        {
            Console.Write("Enter Patient ID to update: ");
            string id = Console.ReadLine().ToUpper();
            Patient patient = patients.Find(p => p.Id == id);
            if (patient != null)
            {
                Console.Write("Enter New Name: ");
                patient.Name = Console.ReadLine();
                Console.Write("Enter New Age: ");
                patient.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter New Contact Info: ");
                patient.ContactInfo = Console.ReadLine();
                Console.WriteLine("Patient updated successfully.\n");
            }
            else
            {
                Console.WriteLine("Patient not found.\n");
            }
        }

        public static void CreateDentist()
        {
            string id = $"DNT{dentists.Count+1}";
            Console.Write("Enter Dentist Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Contact Info: ");
            string contactInfo = Console.ReadLine();
            Console.Write("Enter Treatment Id: ");
            string treatmentId= Console.ReadLine();

            dentists.Add(new Dentist(id, name, age, contactInfo));
            Console.Clear();
            Console.WriteLine("Dentist added successfully.\n");
        }

        public static void UpdateDentist()
        {
            Console.Write("Enter Dentist ID to update: ");
            string id = Console.ReadLine().ToUpper();
            Dentist dentist = dentists.Find(d => d.Id == id);
            if (dentist != null)
            {
                Console.Write("Enter New Name: ");
                dentist.Name = Console.ReadLine();
                Console.Write("Enter New Age: ");
                dentist.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter New Contact Info: ");
                dentist.ContactInfo = Console.ReadLine();
                Console.WriteLine("Dentist updated successfully.\n");
            }
            else
            {
                Console.WriteLine("Dentist not found.\n");
            }
        }

        public static void CreateTreatment()
        {
            string id =$"T{treatments.Count+1}";
            Console.Write("Enter Treatment Name: ");
            string name = Console.ReadLine().ToUpper();
            Console.Write("Enter Cost: ");
            double cost = double.Parse(Console.ReadLine());

           

            treatments.Add(new Treatment(id, name, cost));
            Console.WriteLine("Available Supplies:");
            foreach (DentalSupplies s in dentalSupplies)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");
            }

            while (true)
            {
                Console.Write("Enter supply ID to add to treatment (or 'done' to finish): ");
                string input = Console.ReadLine().ToUpper();
                if (input.ToLower() == "done")
                {
                    break;
                }

                string supplyId = input;
                DentalSupplies supplyToAdd = dentalSupplies.Find(s => s.Id == supplyId);
                if (supplyToAdd != null)
                {
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Treatment temp = treatments.Find(f => f.Id == id);
                    temp.AddSupply(supplyId, quantity);
                    Console.WriteLine($"Supply {supplyToAdd.Name} added to treatment.");
                }
                else
                {
                    Console.WriteLine("Invalid supply ID, please try again.");
                }
            }
            Console.WriteLine("Treatment created successfully.\n");
        }

        public static void UpdateTreatment()
        {
            Console.Write("Enter Treatment ID to update: ");
            string id = Console.ReadLine().ToUpper();
            var treatment = treatments.Find(t => t.Id == id);
            if (treatment != null)
            {
                Console.Write("Enter New Name: ");
                treatment.Name = Console.ReadLine().ToUpper();
                Console.Write("Enter New Cost: ");
                treatment.Cost = double.Parse(Console.ReadLine());
                Console.WriteLine("1. Update Treatment Dentist");
                Console.WriteLine("0. Done");
                Console.Write("Enter Your Choice: ");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        UpdateDentistTreatment(id);
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }

                Console.WriteLine("Treatment updated successfully.\n");
            }
            else
            {
                Console.WriteLine("Treatment not found.\n");
            }
        }

        public static void UpdateDentistTreatment(string id)
        {
            Treatment treatment = treatments.Find(t => t.Id == id);
            if (treatment != null)
            {
                Console.Write("Enter Dentist ID: ");
                string dentistId = Console.ReadLine().ToUpper();
                var dentist = dentists.Find(d => d.Id == dentistId);
                if (dentist != null)
                {
                    treatment.UpdateDentistTreatment(dentist);
                    Console.WriteLine("Dentist treatment update successfully.\n");
                }
                else
                {
                    Console.WriteLine("Dentist not found.\n");
                }
            }
            else
            {
                Console.WriteLine("Treatment not found.\n");
            }
        }

       

        public static void ListofTreatment()
        {
            foreach(Treatment i in treatments)
            {
                i.DisplayTreatment();
            }
        }

    
    }
}


