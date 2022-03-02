using System;
using System.Collections.Generic;
using System.Linq;

namespace Real_Estate_project
{
    class TestUserInterface
    {
        Menu menu;
        Menu CustomerMenu;

        private CustomerDatabase CustomerCollection;
        private PropertyDatabase collection;
        private Customer this_customer;

        public TestUserInterface()
        {
            menu = new Menu();
            CustomerMenu = new Menu();
            CustomerCollection = new CustomerDatabase();
            collection = new PropertyDatabase();
        }
        public Customer RegisterUser()
        {
            string name = UserInterface.GetInput("Full name");
            if (name != "") // if the user don't write anything 
            {
                string email = UserInterface.GetInput("Email");
                string password = UserInterface.GetPassword("Password");
                return new Customer(name, email, password);
            }
            else // return the message
            {
                UserInterface.Message("Name cannot be empty.");
                return null;
            }
        }

        public string GetCurrentUserName()
        {
            return this_customer.CustomerName;
        }

        public void AddUser()
        {
            CustomerCollection.AddNewUser(RegisterUser());
        }

        bool runCustomer = true;
        public void UserLogin()
        {
            string email = UserInterface.GetInput("Email");
            string password = UserInterface.GetPassword("Password");
            if (CustomerCollection.NewUserLogin(email, password) == null)
            {
                return;
            }
            else
            {
                this_customer = CustomerCollection.NewUserLogin(email, password);
                UserInterface.Message($"Welcome {this_customer.CustomerName}, ({email})");
               
                
                while (runCustomer) CustomerMenu.Display();
            }
        }

        public Land RegisterLand()
        {
            string Address = UserInterface.GetInput("Address");
            int Postcode = UserInterface.GetInteger("Post code");
            int LandMetres = UserInterface.GetInteger("Area (square metres)");
            if (collection.ExistenceProperty(Address) == false)
            {
                UserInterface.Message($"{Address}, {Postcode}, Land only {LandMetres}sqm registered successfully");
                this_customer.addnewuserproperty(Address);
                return new Land(Address, Postcode, this_customer, LandMetres);
            }
            return null;
        }
        public void AddLand()
        {
            collection.AddNewProperty(RegisterLand());
        }

        public House RegisterHouse()
        {
            string Address = UserInterface.GetInput("Address");
            int Postcode = UserInterface.GetInteger("Post code");
            string HouseDescription = UserInterface.GetInput("Enter description of house (list rooms etc)");
            if (collection.ExistenceProperty(Address) == false) // if the property doesn't exist for more than one time
            {   // output the message
                UserInterface.Message($"{Address}, {Postcode}: {HouseDescription}");
                this_customer.addnewuserproperty(Address); // add the address to new user property
                return new House(Address, Postcode, this_customer, HouseDescription); 
            }
            return null;
        }

        public void AddHouse()
        {
            collection.AddNewProperty(RegisterHouse());
        }

        public void ListProperties()
        {

            List<Property> MyProperty = new List<Property>(); // creating new list within the proeprty list
            // listing all the property items into the list from property collection
            MyProperty = collection.ListProperties(this_customer.ListThisUsersProperty());

            if (MyProperty != null) // if there exists a property
            {   // using the string interpolation to show the customer's name
                UserInterface.DisplayList($"Properties owned by: {this_customer.CustomerName}.", MyProperty);
            }
            else
            {
                UserInterface.Message($"Customer: {this_customer.CustomerName}, has no registered properties.");
            }
        }
        // searching for particular postcode
        public void ParticularPostcode()
        {   
            int Postcode = UserInterface.GetInteger("Post code");
            collection.ParticularPostcode(Postcode);
        }
    
        public void GetBid()
        {
            int Postcode = UserInterface.GetInteger("Post code");
            Property MyProperty = collection.NewBid(Postcode, this_customer.ListThisUsersProperty());
            if (MyProperty != null) // if there exists a property
            {  // enter input for bidding
                int EnteringBid = UserInterface.GetInteger("Enter Bid($)");
                // using string interpolation to show the bidding price as well as customer name and email
                UserInterface.Message($"{this_customer.CustomerName} ({this_customer.CustomerEmail}) bid ${EnteringBid} ");
                // from the bidding class add a new items then we can add bid on it
                Bidding bid = new Bidding(this_customer.CustomerName, this_customer.CustomerEmail, EnteringBid);
                MyProperty.AddBid(bid); // add the bidding part
            }
            else
            {
                UserInterface.Message("No properties found. Try again.");
            }
        }

        public void DisplayBids()
        {
            List<Property> MyProperties;
            MyProperties = collection.ListProperties(this_customer.ListThisUsersProperty());
            if (MyProperties != null && MyProperties.Count > 0)
            {
                Property ChooseProperty = UserInterface.ChooseFromList(MyProperties);
                ChooseProperty.DisplayBids();
            }
            else
            {
                UserInterface.Message("No Properties registered.");
            }
        }


        /// Selling the propperty to highest bidder
        /// choosing a property from the Myproperties - display a message the sold and remove from the propertyList

        public void SellingProperty()
        {
            List<Property> MyProperties;
            MyProperties = collection.ListMyProperty(this_customer);
            if (MyProperties.Count != 0) // if property exists 
            {   // choose properties from the list
                Property ChooseProperty = UserInterface.ChooseFromList(MyProperties);
                // if the address from choosing property had a max value
                if (ChooseProperty.MaxBid(ChooseProperty.Address) == true)
                {   // calculate the tax
                    double highestBid = ChooseProperty.tax();
                    // put the message and used interpolation to show the amount of bids
                    UserInterface.Message($" Payable Tax: ${highestBid}");
                    // removing the porperty from the list
                    collection.RemovingPropertyList(ChooseProperty); 
                }
            }
            else
            {   // if no property exists show the messages
                UserInterface.Message("No Properties registered.");
            }
        }

        public void Run()
        {
            menu.Add("Register as a new Customer", AddUser);
            menu.Add("Login as existing Customer", UserLogin);
            CustomerMenu.Add("Register new land for sale", AddLand);
            CustomerMenu.Add("Register new house for sale", AddHouse);
            CustomerMenu.Add("List all the propertries", ListProperties);
            CustomerMenu.Add("List bids received for a property", DisplayBids);
            CustomerMenu.Add("Sell one of my properties to highest bidder", SellingProperty);
            CustomerMenu.Add("Search for a property for sale", ParticularPostcode);
            CustomerMenu.Add("Place a bid on a property", GetBid);
            CustomerMenu.Add("Logout", CustomerDone);
            DisplayMainMenu();
        }
        

        // log out part
        private void CustomerDone()
        {
            runCustomer = false; // if the boolean is false out put the message as logged out
            Console.WriteLine($"{this_customer.CustomerName} logged out");

        }

        // show all the specific options after the user logged in
        public void DisplayMainMenu()
        {
            while (true)
                menu.Display();
        }
        static void Main(string[] args)
        {
            TestUserInterface test = new TestUserInterface();
            test.Run();
        }
    }
}
