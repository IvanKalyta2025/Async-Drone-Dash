using System;
using System.Threading.Tasks;

namespace AsyncTcsExample
{

    public class PickapOrder
    {
        public TaskCompletionSource<int> _orderFs = new TaskCompletionSource<int>();

        //у нас есть какой то заказ и нам нужно понять где находиться наш почтовый чел.
        public Task<int> WhereIsPostman => _orderFs.Task;

        public void StartOfDelivery(string whereispostman)
        {

        }

    }

}