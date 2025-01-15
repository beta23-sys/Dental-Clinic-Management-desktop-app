using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class FrontOperationMenu
    {
        public static void ShowFrontOperationMenu()
        {
            while (true)
            {
                Console.WriteLine("Front Operations");
                Console.WriteLine("1. Patient");
                Console.WriteLine("2. Appointment");
                Console.WriteLine("3. Create Payment");
                Console.WriteLine("4. View Dentists");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ShowPatientMenu();
                        break;
                    case "2":
                        ShowAppointmentMenu();
                        break;
                    case "3":
                        Program.CreatePayment();
                        break;
                    case "4":
                        Program.ViewDentists();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }
            }
        }

        public static void ShowPatientMenu()
        {
            while (true)
            {
                Console.WriteLine("Front Operations");
                Console.WriteLine("1. New Patient");
                Console.WriteLine("2. Patient Info");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Add Prescription");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Program.CreatePatient();
                        break;
                    case "2":
                        Program.ListPatients();
                        break;
                    case "3":
                        Program.UpdatePatient();
                        break;
                    case "4":
                        Program.CreatePrescription();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }

            }
        }

        public static void ShowAppointmentMenu()
        {
            while (true)
            {
                Console.WriteLine("Front Operations");
                Console.WriteLine("1. New Appointment");
                Console.WriteLine("2. Display Appointment");
                Console.WriteLine("3. Cancel Appointment");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Program.CreateAppointment();
                        break;
                    case "2":
                        Program.ListofAppointment();
                        break;
                    case "3":
                        Program.CancelAppointment();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }

            }
        }

    }
}
