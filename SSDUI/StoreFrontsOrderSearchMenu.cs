using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class StoreFrontsOrderSearchMenu : IMenu
    {
        private static List<Orders> listOfSearchedOrders = new List<Orders>();
        private static List<LineItems> theOrderLineItems = new List<LineItems>();
        private static List<Products> listOfProducts = new List<Products>();
        private string criteria;
        private string value;
        private IOrderBL _orderBL;
        private ILineItemBL _lineItemBL;
        private IProductBL _productBL;
        public StoreFrontsOrderSearchMenu(IOrderBL p_orderBL, ILineItemBL p_lineItemBL, IProductBL p_productBL)
        {
            _orderBL = p_orderBL;
            _lineItemBL = p_lineItemBL;
            _productBL = p_productBL;
        }
        public void Menu()
        {
            System.Console.Clear();
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome to Store Front Order Searching Menu!!!");
            System.Console.WriteLine("Please pick a searching criteria");
            System.Console.WriteLine("[1] Order ID");
            System.Console.WriteLine("[2] Customer ID");
            System.Console.WriteLine("[3] StoreFront ID");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("-----------------------------------------------------------------------");
        }

        public MenuType YourChoice()
        {
            System.Console.Write("Enter Your Choice: ");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    criteria = "id";
                    System.Console.Write("Enter Order Id: ");
                    SearchAndDisplayOrder(criteria);
                    return MenuType.StoreFrontsOrderSearchMenu;
                case "2":
                    criteria = "customerID";
                    System.Console.Write("Enter Customer Id: ");
                    SearchAndDisplayOrder(criteria);
                    return MenuType.StoreFrontsOrderSearchMenu;
                case "3":
                    criteria = "storeFrontID";
                    System.Console.Write("Enter StoreFront Id: ");
                    SearchAndDisplayOrder(criteria);
                    return MenuType.StoreFrontsOrderSearchMenu;
                case "0":
                    return MenuType.StoreFrontsCustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }


        public void SearchAndDisplayOrder(string p_criteria)
        {
            bool repeat = true;
            while(repeat)
            {
                try
                {
                    value = Console.ReadLine();
                    listOfSearchedOrders = _orderBL.SearchOrders(criteria, value);
                    if (listOfSearchedOrders.Count == 0)
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
                        foreach(Orders o in listOfSearchedOrders)
                        {
                            System.Console.WriteLine(o.ToString());
                        }
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        repeat = false;
                        //if for displaying an order detail
                        if (criteria == "id")
                        {
                            double total = 0.0;
                            theOrderLineItems = _lineItemBL.GetAnOrderLineItems(int.Parse(value));
                            listOfProducts = _productBL.GetAllProducts();
                            System.Console.WriteLine("Order Details");
                            foreach(LineItems li in theOrderLineItems)
                            {
                                foreach(Products p in listOfProducts)
                                {
                                    if(p.Id == li.ProductId)
                                    {
                                        System.Console.WriteLine("Product Name: " + p.Name + 
                                                        " ||| Price: $" + string.Format("{0:0.00}",p.Price) + 
                                                        " ||| Purchased Quantity: " + li.Quantity +
                                                        " ||| Line Total: $" +  string.Format("{0:0.00}",(p.Price*li.Quantity)));
                                        total += (p.Price*li.Quantity);
                                    }
                                }
                            }
                            System.Console.WriteLine("-----------------------------------------------------------------------Order Total: $" + string.Format("{0:0.00}",total));
                        }

                        System.Console.Write("Enter To Continue");
                        System.Console.ReadLine();


                        
                    }
                }
                catch(System.Exception)
                {
                    System.Console.WriteLine("Input Was Not Valid");
                    System.Console.WriteLine("Order Not Found");
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