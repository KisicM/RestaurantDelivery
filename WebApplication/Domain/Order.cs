using System;

namespace Domain
{
    public class Order : Entity
    {
        public int CustomerId { get; set; }
        public int DelivererId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }

        public Order()
        {
            
        }

        public Order(int customerId, int delivererId, DateTime starTime, DateTime endTime, string comment, string address, double price)
        {
            CustomerId = customerId;
            DelivererId = delivererId;
            StartTime = starTime;
            EndTime = endTime;
            Comment = comment;
            Address = address;
            Price = price;
        }

    }
}