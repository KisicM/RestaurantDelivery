using System.Collections.Generic;
using Domain;

namespace Service
{
    public interface IOrderService
    {
        public Order GetById(int id);
        public IEnumerable<Order> GetAll();
        public Order Create(Order order);
        public Order Update(int id, Order order);
    }
}