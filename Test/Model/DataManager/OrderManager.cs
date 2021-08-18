using System;
using System.Collections.Generic;
using System.Linq;
using Test.Context;
using Test.Model.Repository;

namespace Test.Model.DataManager
{
    public class OrderManager : IDataRepository<Order>
    {
        readonly bilbixContext _orderContext;

        public OrderManager(bilbixContext orderContext)
        {
            _orderContext = orderContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderContext.Orders.ToList();
        }

        public Order Get(long id)
        {
            return _orderContext.Orders.FirstOrDefault(e => e.OrderId == id);
        }

        public void Add(Order order)
        {
            _orderContext.Add(order);
            _orderContext.SaveChanges();
        }

        public void Update(Order orderToUpdate, Order order)
        {
            orderToUpdate.OrderId = order.OrderId;
            orderToUpdate.StartDato = order.StartDato;
            orderToUpdate.SlutDato = order.SlutDato;
            orderToUpdate.EjerId = order.EjerId;

            _orderContext.SaveChanges();
        }

        public void Delete(Order order)
        {
            _orderContext.Remove(order);
            _orderContext.SaveChanges();
        }

    }
}
