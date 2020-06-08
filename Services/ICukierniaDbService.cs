using System.Collections;
using System.Collections.Generic;
using Cw13.DTOs;
using Cw13.Models;

namespace Cw13.Services
{
    public interface ICukierniaDbService
    {
         public IEnumerable GetOrders();
        public IEnumerable GetOrders(string name);
        public string AddNewOrder(int id, AddNewOrderRequest request);
    }
}