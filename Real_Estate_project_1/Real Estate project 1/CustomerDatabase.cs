using System;
using System.Collections.Generic;
using System.Text;

namespace Real_Estate_project
{  
    class CustomerDatabase
    {
        List<Customer> CustomerList; // creating a new 
        private int CustomerNumber;
        public CustomerDatabase()
        {
            CustomerList = new List<Customer>();
            CustomerNumber = 0;
        }
        public void AddNewUser (Customer NewUser)
        {
            if (NewUser != null)
            {   // restrictions for customerName and customerEmail
                // (they cannot register for the same name and email more than one time)
                if (ExistenceCustomer(NewUser.CustomerName, NewUser.CustomerEmail) == true) 
                {   // return this message if they put the same name or email more than once
                    UserInterface.Message("Customer Already Exists!");
                }
                else
                {
                    CustomerNumber++;  // increment cusnum
                    CustomerList.Add(NewUser); // add new user
                    UserInterface.Message($"{NewUser.CustomerName} registered successfully.");
                }
            }
        }

  
        /// Validate userLogin - checking if email and password are match 
        public Customer NewUserLogin(string email, string password)
        {
            for(int i = 0; i < CustomerList.Count; i++)
            {   
                if(email == CustomerList[i].CustomerEmail && password == CustomerList[i].CustomerPassword)
                {
                    return CustomerList[i]; // returning the userInput
                }
            }
            Console.WriteLine("Login information is incorrect. Please try again!");
            return null;
        }


        // checking the existence customer
        public bool ExistenceCustomer(string customerName, string customerEmail)
        {
            for (int i = 0; i < CustomerNumber; i++)
            {
               // if the customer name and first item in the list matched or
               // the customer email and the first item in the list matched return true 

                if (customerName == CustomerList[i].CustomerName || customerEmail == CustomerList[i].CustomerEmail)
                {
                    return true;
                } 
            }
            return false;
        }
    }
}
