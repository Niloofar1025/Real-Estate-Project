using System;
using System.Collections.Generic;
using System.Text;

namespace Real_Estate_project
{

    // inheritance between land and property
    // the property class (child) inherits the fields and methods from the Land class (parent)
    public class Land : Property
    {
        private int metres;

        public int Metres
        {
            get
            {
                return metres;
            }
            private set
            {
                metres = value;
            }
        }
        public Land( string address, int postcode, Customer owner, int metres) : base(address, postcode, owner)
        {
            this.metres = metres;
        }

        public override string ToString()
        {
            return Address + ", " + Postcode + ", Land only " + metres +"sqm";
        }

        public override void AddBid(Bidding addingBid)
        {
            BiddingList.Add(addingBid);

        }

        /// Bid an Amount for the property

        public override void DisplayBids()
        {
            if (BiddingList.Count > 0)
            {
                foreach (Bidding displayingBids in BiddingList)
                {
                    Console.WriteLine(displayingBids.CustomerName + ": " + displayingBids.BidAmount);
                }
            }
            else
            {
                UserInterface.Message("No bids.");
            }
        }

        public override bool MaxBid(string Address)
        {
            double maxBid;
            List<double> BidAmountList = new List<double>();
            if (BiddingList.Count > 0)
            {
                for (int i = 0; i < BiddingList.Count; i++)
                {
                    BidAmountList.Add(BiddingList[i].BidAmount);
                }
                BidAmountList.Sort();
                BidAmountList.Reverse();
                maxBid = BidAmountList[0];
                for (int i = 0; i < BidAmountList.Count; i++)
                {
                    if (maxBid == BiddingList[i].BidAmount)
                    {
                        Console.WriteLine($"{Address} sold to {BiddingList[i].CustomerName},({BiddingList[i].CustomerEmail}) bid {maxBid}");
                        return true;
                    }
                }
            }
            else
            {
                UserInterface.Message("No bids.");
                return false;
            }
            return false;
        }



        public override double tax()
        {
            double this_tax = Math.Ceiling(this.Metres * 5.50); // Math.ceiling round up a number 
            return this_tax;
        }

    }
}
