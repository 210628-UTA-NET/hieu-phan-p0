using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class CustomersSearchMenu : IMenu
    {
        private static List<Customers> listOfSearchedCustomer;
        private string criteria;
        private string value;
        private ICustomerBL _customerBL;

        public CustomersSearchMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }

        public void Menu()
        {
            System.Console.Clear();
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome to Customer Searching Menu!!!");
            System.Console.WriteLine("Please pick a searching criteria");
            System.Console.WriteLine("[1] Using First Name");
            System.Console.WriteLine("[2] Using Last Name");
            System.Console.WriteLine("[3] Using Address");
            System.Console.WriteLine("[4] Using Email");
            System.Console.WriteLine("[5] Using Phone Number");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("-----------------------------------------------------------------------");
        }

        public MenuType YourChoice()
        {
            System.Console.Write("Enter Your Choice: ");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "5":
                    criteria = "phone";
                    System.Console.Write("Enter Customer's Phone Number: ");
                    SearchAndDisplayCustomer(criteria);
                    return MenuType.CustomersSearchMenu;
                case "4":
                    criteria = "email";
                    System.Console.Write("Enter Customer's Email: ");
                    SearchAndDisplayCustomer(criteria);
                    return MenuType.CustomersSearchMenu;
                case "3":
                    criteria = "address";
                    System.Console.Write("Enter Customer's Address: ");
                    SearchAndDisplayCustomer(criteria);
                    return MenuType.CustomersSearchMenu;
                case "2":
                    criteria = "lname";
                    System.Console.Write("Enter Customer's Last Name: ");
                    SearchAndDisplayCustomer(criteria);
                    return MenuType.CustomersSearchMenu;
                case "1":
                    criteria = "fname";
                    System.Console.Write("Enter Customer's First Name: ");
                    SearchAndDisplayCustomer(criteria);
                    return MenuType.CustomersSearchMenu;
                case "0":
                    return MenuType.StoreFrontsCustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreFrontsMenu;
            }


        }

        public void SearchAndDisplayCustomer(string p_criteria)
        {
            bool repeat = true;
            while(repeat)
            {
                try
                {
                    value = Console.ReadLine().ToUpper();
                    listOfSearchedCustomer = _customerBL.SearchCustomers(criteria, value);
                    if (listOfSearchedCustomer.Count == 0)
                    {
                        System.Console.WriteLine("No Results.");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            repeat = false;
                            break;
                            default:
                            System.Console.WriteLine("Re-enter Your " + p_criteria + " Search Value: ");
                            break;
                        }
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        System.Console.WriteLine("List of Results");
                        foreach(Customers c in listOfSearchedCustomer)
                        {
                            System.Console.WriteLine(c.ToString());
                        }
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        System.Console.Write("Enter To Continue");
                        System.Console.ReadLine();
                        repeat = false;
                    }
                }
                catch(System.Exception)
                {
                    System.Console.WriteLine("Input Was Not Valid");
                    System.Console.WriteLine("Customer Not Found");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        repeat = false;
                        break;
                        default:
                        System.Console.WriteLine("Re-enter Your " + p_criteria + " Search Value: ");
                        break;
                    }
                }
            }

        }

    }
}