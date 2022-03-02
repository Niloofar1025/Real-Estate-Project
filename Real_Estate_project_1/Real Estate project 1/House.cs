using System;
using System.Collections.Generic;
using System.Text;

namespace Real_Estate_project
{  
    // inheritance between house and property
    // the property class (child) inherits the fields and methods from the House class (parent)
    public class House : Property
    {    
        private string description;

        public string Description
        {
            get => description;
            set
            {
                description = value;
            }
        }

        public House(string address,  int postcode, Customer owner, string description):base(address,postcode, owner)
        {
            this.description = description;
        }

        // override the ToString method in order to provide the information for the house (Address, postcode and description)
        public override string ToString()
        {
            return this.Address + " " + this.Postcode + " " + this.description;
        }

        public override void AddBid(Bidding addingBid)
        {
            BiddingList.Add(addingBid);
        }


        // Bid an Amount for the property
        public override void DisplayBids()
        {
            if (BiddingList.Count > 0) // if the customer put a bid on a property
            {
                foreach (Bidding displayingBids in BiddingList) // display the bids in bidding list
                {
                    Console.WriteLine(displayingBids.CustomerName + ": " + displayingBids.BidAmount);
                }
            }
            else // if the customer don't put a bids on a property, return the message
            {
                UserInterface.Message("No bids received.");
            }
        }

        // Highest bid on a property
        public override bool MaxBid(string Address) // take the highest bid by the customer
        {
            double maxBid;
            List<double> BidAmountList = new List<double>();
            if (BiddingList.Count > 0) // if the customer put a bid on a property (greater than zero)
            {
                for (int i = 0; i < BiddingList.Count; i++)
                {
                    BidAmountList.Add(BiddingList[i].BidAmount);
                }
                BidAmountList.Sort(); // sort all the bidding list
                BidAmountList.Reverse(); // reverse the list
                maxBid = BidAmountList[0]; // the first item in the bid amount list should be equal to the highest bid
                for (int i = 0; i < BidAmountList.Count; i++)
                {
                    if (maxBid == BiddingList[i].BidAmount) // if the highest bid is equal to the bidding amount in the first index of the list
                    {   
                        // return the message
                        Console.WriteLine($"{Address} sold to {BiddingList[i].CustomerName},({BiddingList[i].CustomerEmail}) bid {maxBid}");
                        return true;
                    }
                }
            }
            else // if the customer don't put any bids 
            {   // return this message
                UserInterface.Message("No bids received.");
                return false;
            }
            return false;
        }




        public override double tax()
        {
            double maxBid;
            List<double> BidAmountList = new List<double>();
            for (int i = 0; i < BiddingList.Count; i++)
            {
                BidAmountList.Add(BiddingList[i].BidAmount);
            }
            BidAmountList.Sort();
            BidAmountList.Reverse();
            maxBid = BidAmountList[0];
            double this_tax = Math.Ceiling(maxBid * 0.1);
            return this_tax; // selling the price for the house
        }




    }

}