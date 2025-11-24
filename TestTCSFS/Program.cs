using System;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AsyncTcsExample
{

    public class PickapOrder
    {
        public TaskCompletionSource<int> _orderStatus = new TaskCompletionSource<int>();

        //у нас есть какой то заказ и нам нужно понять где находиться наш почтовый чел.
        public Task<int> WhereIsPostman => _orderStatus.Task;

        public void StartOfDelivery(string whereispostman)
        {
            var time = DateTime.Now;
            Console.WriteLine($"The driver started driving from the main distribution center. Time: {time}");

        }

    }

}