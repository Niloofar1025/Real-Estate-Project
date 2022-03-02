using System;
using System.Collections.Generic;
using System.Text;

namespace Real_Estate_project
{
    public class Customer
    {
        private string customerName;
        private string customerEmail;
        private string customerPassword;
        List<string> userproperties;
       public string CustomerName
        {
            get => customerName; 
            set
            {
                customerName = value;
            }
        }
        public string CustomerEmail
        {
            get => customerEmail;
    
            set
            {
                customerEmail = value;
            }
        }
        public string CustomerPassword
        {
            get => customerPassword;

            set
            {
                customerPassword = value;
            }
        }

        public Customer(string CustomerName, string CustomerEmail, string CustomerPassword)
        {
            this.CustomerName = CustomerName;
            this.CustomerEmail = CustomerEmail;
            this.CustomerPassword = CustomerPassword;
            userproperties = new List<string>();
            clearUserProperty();
        }
        
        //Add the new property to the uer proeprty list
        public void addnewuserproperty(string uniqueAddress)
        {
                userproperties.Add(uniqueAddress);
        }

        public void clearUserProperty()
        {
            userproperties.Clear();
        }

        public List<string> ListThisUsersProperty()
        {
            return userproperties;
        }
      

    }
}
