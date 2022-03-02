using System;
using System.Collections.Generic;
using System.Text;

namespace Real_Estate_project
{
    public abstract class Property
    {
        private string address;
        private int postcode;
        private List<Bidding> biddingList;
        private Customer owner;

        public string Address
        {
            get
            {
                return address;
            }
            private set
            {
                address = value;
            }
        }
        public int Postcode
        {
            get
            {
                return postcode;
            }
            private set
            {
                postcode = value;
            }
        }

        public List<Bidding> BiddingList
        {
            get
            {
                return biddingList;
            }
            private set
            {
                biddingList = value;
            }
        }

        public Customer Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        }


        public Property(
            string address,
            int postcode,
            Customer owner
            )
        {
            this.address = address;
            this.postcode = postcode;
            this.owner = owner;
            biddingList = new List<Bidding>();
        }


        public abstract void AddBid(Bidding addingBid);
        public abstract void DisplayBids();
        public abstract bool MaxBid(string Address);
        public abstract double tax();
    }
}
