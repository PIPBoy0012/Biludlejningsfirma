using System;
using System.Collections.Generic;
using System.Linq;
using Test.Context;
using Test.Model.Repository;

namespace Test.Model.DataManager
{
    public class OrderLineManager : IDataRepository<OrderLine>
    {
        readonly bilbixContext _orderLineContext;

        public OrderLineManager(bilbixContext orderLineContext)
        {
            _orderLineContext = orderLineContext;
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _orderLineContext.OrderLines.ToList();
        }

        public OrderLine Get(long id)
        {
            return _orderLineContext.OrderLines.FirstOrDefault(e => e.OrderLines == id);
        }

        public void Add(OrderLine orderLine)
        {
            _orderLineContext.Add(orderLine);
            _orderLineContext.SaveChanges();
        }

        public void Update(OrderLine orderLineToUpdate, OrderLine orderLine)
        {
            orderLineToUpdate.Antal = orderLine.Antal;
            orderLineToUpdate.SamletPris = orderLine.SamletPris;
            orderLineToUpdate.OrderId = orderLine.OrderId;
            orderLineToUpdate.ProduktId = orderLine.ProduktId;

            _orderLineContext.SaveChanges();
        }

        public void Delete(OrderLine orderLine)
        {
            _orderLineContext.Remove(orderLine);
            _orderLineContext.SaveChanges();
        }
    }
}
