
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseDemo.practical
{
    class Bill2
    {
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; } = DateTime.Now;

        public string BillHolder { get; set; }
        public double BillAmount { get; set; }

    }
    enum particulars1 { wheat = 1, jower = 2, ragi = 3, oil = 4, rice = 5, sugar = 6 }
    class Item1
    {

        public int id { get; set; }
        public int quantity { get; set; } = 1;
        public int price { get; set; }
        public string ItemName { get; set; }

    }
    class addedItem
    {
        public string addid;
        public string addname;
        public string addprice;
        public string addqty;
        public string addtotal;

    }

    class UI91
    {
        static int totalAmount = 0;
        static int itemAmount = 0;
        static HashSet<Item> items = new HashSet<Item>();
        public static void item()
        {

            items.Add(new Item { id = 1, ItemName = "wheat", price = 40 });
            items.Add(new Item { id = 2, ItemName = "ragi", price = 50 });
            items.Add(new Item { id = 3, ItemName = "oil", price = 100 });
            items.Add(new Item { id = 4, ItemName = "rice", price = 200 });
            items.Add(new Item { id = 5, ItemName = "sugar", price = 50 });
            items.Add(new Item { id = 6, ItemName = "soap", price = 50 });
            items.Add(new Item { id = 7, ItemName = "salt", price = 50 });
            items.Add(new Item { id = 8, ItemName = "MTR Jamoon", price = 50 });
            items.Add(new Item { id = 9, ItemName = "Maggi", price = 50 });
            items.Add(new Item { id = 10, ItemName = "chilly powder", price = 50 });
            items.Add(new Item { id = 11, ItemName = "salt", price = 50 });
            items.Add(new Item { id = 12, ItemName = "sambar powder", price = 50 });
            items.Add(new Item { id = 13, ItemName = "jeera", price = 50 });
            items.Add(new Item { id = 14, ItemName = "detergent", price = 50 });

            foreach (var things in items)
            {
                Console.WriteLine($"{things.id}       {things.ItemName}          {things.price}");

            }
        }
        public static void CustomerName()
        {
            Console.WriteLine("Enter the customer name");
            string name = Console.ReadLine();
        }

        public static void Details()
        {
            int choice = utilities.GetNumber("enter 1 to add or 2 to bill");
            bool check = true;
            do
            {

                if (choice == 1)

                {


                    Console.WriteLine("CHOOSE THE ITEM ID WHICH YOU WANT TO ADD");
                    int id1 = int.Parse(Console.ReadLine());
                    foreach (var item in items)
                    {
                        // if (item is Item)
                        // {
                        //var unBox = item as Item;

                        if (item.id == id1)
                        {
                            //Console.WriteLine(unBox.id + " " + unBox.ItemName);
                            Console.WriteLine("CHOOSE THE ITEM QUANTITY WHICH YOU WANT TO ADD");
                            int quantity = int.Parse(Console.ReadLine());
                            Console.WriteLine(quantity * item.price);
                            totalAmount = Convert.ToInt32(quantity * item.price);
                            itemAmount += totalAmount;
                            addSelectedItems($"{item.id}", $"{ item.ItemName}", $"{ item.quantity}", $"{item.price}", $"{ totalAmount}");
                        }

                        //}
                        // }

                    }

                }



                else if (choice == 2)
                {
                    GenerateBill();
                    break;
                }

                choice = utilities.GetNumber("enter 1 to add or 2 to bill");


            } while (check);


        }
        static List<addedItem> AddedItems = new List<addedItem>();
        public static void addSelectedItems(string id, string name, string qty, string price, string total)
        {
            addedItem data = new addedItem { addid = id, addname = name, addprice = price, addqty = qty, addtotal = total };
            AddedItems.Add(data);

        }
        public static void GenerateBill()
        {


            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("BILL DETAILS");
            Random rnd = new Random();
            int Billno = rnd.Next(200);
            Console.WriteLine("BILL NO :" + Billno);
            Console.WriteLine("DATE:");
            DateTime date = DateTime.Now;
            Console.WriteLine(date);
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("ITEM ID\t\tITEAM NAME\t\tQUANTITY\t\tPRICE\t\tTOTAL AMOUNT");
            foreach (var item in AddedItems)
            {
                Console.WriteLine(item.addid +"               "+ item.addname +"                         " + item.addqty + "                       " +item.addprice + "                       "+item.addtotal );
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------");
            
            Console.WriteLine(" The total amount is " + itemAmount);


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the provision store");

            CustomerName();

            Console.WriteLine("CHOOSE THE ITEMS FROM BELOW");
            item();


            Console.WriteLine("ENTER THE ITEMS YOU WANT TO BUY");
            string parti = Console.ReadLine();
            Details();

        }
    }


}


















