using System;
using System.Collections.Generic;
using System.Text;

namespace Real_Estate_project
{
    public class Bidding
    {
        private string customerName;
        private double bidAmount;
        private string customerEmail;

        public Bidding(
            string customerName,
            string customerEmail,
            double bidAmount)
        {
            this.CustomerName = customerName;
            this.CustomerEmail = customerEmail;
            this.BidAmount = bidAmount;
        }

        public string CustomerEmail
        {
            get => customerEmail;
            set
            {
                customerEmail = value;
            }

        }

        public string CustomerName
        {
            get => customerName;
            set
            {
                customerName = value;
            }
        }

        public double BidAmount
        {
            get
            {
                return bidAmount;
            }
            private set
            {
                bidAmount = value;
            }
        }

    }

}
