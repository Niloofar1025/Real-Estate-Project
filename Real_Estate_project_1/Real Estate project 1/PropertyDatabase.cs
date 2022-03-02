using System;
using System.Collections.Generic;
using System.Text;

namespace Real_Estate_project
{
    class PropertyDatabase 
    {
        List<Property> PropertyList;

        public int PropertyNumber;

        public PropertyDatabase()
        {
            PropertyList = new List<Property>();
            PropertyNumber = 0;
        }

        public bool ExistenceProperty(string NewPropertyAddress)
        {
            for (int i = 0; i < PropertyList.Count; i++)
            { 
                if (NewPropertyAddress == PropertyList[i].Address)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddNewProperty(Property NewProperty)
        {
            if (NewProperty != null)
            {
                PropertyList.Add(NewProperty);
                PropertyNumber++;
            }
            else
            {
                UserInterface.Message("Invalid Property");
            }
        }


        /// List all the properties (Land and House)
  
        public List<Property> ListProperties(List<string> myAddress)
        {
            List<Property> MyProperty = new List<Property>();
            for (int i = 0; i < PropertyList.Count; i++)
            {
                if (myAddress.Count > 0)
                {
                    if (myAddress.Contains(PropertyList[i].Address))
                    {
                        MyProperty.Add(PropertyList[i]);
                    }
                }
                else
                {
                    return null;
                }
            }
            return MyProperty;
        }

        public List<Property> ListMyProperty(Customer owner)
        {
            int count = 0;
            // new list for my properties
            List<Property> MyProperty = new List<Property>();
            
            foreach (Property property in PropertyList)
            {

                if (property.Owner == owner)
                {
                   
                    MyProperty.Add(property);
                    // add to list
                    count++;
                }
            }
     
            return MyProperty;
            //return list
        }

        // Search the propertry for particular postcode 
        public void ParticularPostcode(int postcode)
        {
            UserInterface.Message("Properties Found:");
            foreach (Property property in PropertyList)
            {
                if (property.Postcode == postcode)
                {

                    UserInterface.Message(property.ToString());

                }
                
            }

            Console.WriteLine();
        }

        public Property NewBid(int postcode, List<string> MyAddresses)
        {
            List<Property> temporaryList = new List<Property>();

           for (int i = 0; i < PropertyNumber; i++)
           {
                if (!MyAddresses.Contains(PropertyList[i].Address))
                {
                    if (PropertyList[i].Postcode == postcode)
                    {
                        temporaryList.Add(PropertyList[i]);
                    }
                }
           }
           if (temporaryList.Count != 0)
           {
                Property BiddedProperty = UserInterface.ChooseFromList(temporaryList);
                return BiddedProperty;
           }
           else
           {
               return null;
           }
        }

        public void Addchecking(Property NewProp)
        {
            if (DuplicateExistenceCustomer(NewProp.Address) == true)
            {
                UserInterface.Message("Customer Address is duplicated!");
            }
        }

        public bool DuplicateExistenceCustomer(string Address)
        {
            for (int i = 0; i < PropertyNumber; i++)
            {
                if (Address == PropertyList[i].Address)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemovingPropertyList(Property RemovePropertyList)
        {
            PropertyList.Remove(RemovePropertyList); // removing from items in the list
            PropertyNumber--; // decreasing by number one
        }
    }
}
