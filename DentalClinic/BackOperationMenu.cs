using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class BackOperationMenu
    {
        public static void ShowBackOperationMenu()
        {
            while (true)
            {

                Console.WriteLine("Back Operations");
                Console.WriteLine("1. Inventory Report");
                Console.WriteLine("2. Sales Report");
                Console.WriteLine("3. Order");
                Console.WriteLine("4. Dentist");
                Console.WriteLine("5. Treatment");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Program.InventoryReport();
                        break;
                    case "2":
                        ShowSalesReportMenu();
                        break;
                    case "3":
                        ShowOrderMenu();
                        break;
                    case "4":
                        ShowDentistMenu();
                        break;
                    case "5":
                        ShowTreatmentMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }

            }
        }

        public static void ShowOrderMenu()
        {
            while (true)
            {
                Console.WriteLine("Back Operations");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. View Order");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Program.CreateOrder();
                        break;
                    case "2":
                        Program.ViewOrders();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }
            }
        }

        public static void ShowDentistMenu()
        {
            while (true)
            {
                Console.WriteLine("Dentist Management");
                Console.WriteLine("1. New Dentist");
                Console.WriteLine("2. View Dentists");
                Console.WriteLine("3. Update Dentist");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Program.CreateDentist();
                        break;
                    case "2":
                        Program.ViewDentists();
                        break;
                    case "3":
                        Program.UpdateDentist();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }
            }
        }

        public static void ShowSalesReportMenu()
        {
            while (true)
            {
                Console.WriteLine("Sales Report Menu");
                Console.WriteLine("1. Today's Sales");
                Console.WriteLine("2. All Sales");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Program.ViewTodaySales();
                        break;
                    case "2":
                        Program.ViewAllSales();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.\n");
                        break;
                }
            }


        }

        public static void ShowTreatmentMenu()
        {
            while (true)
            {
                Console.WriteLine("Treatment Menu");
                Console.WriteLine("1. New Treatment");
                Console.WriteLine("2. Display Treatment");
                Console.WriteLine("3. Update Treatment");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Program.CreateTreatment();
                        break;
                    case "2":
                        Program.ListofTreatment();
                        break;
                    case "3":
                        Program.UpdateTreatment();
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
