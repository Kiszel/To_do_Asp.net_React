using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class TaskQueue
    {
        private readonly SemaphoreSlim _semaphoreSlim;

        public TaskQueue()
        {
            _semaphoreSlim = new SemaphoreSlim(1);
        }

        public async Task<T> Enqueue<T>(Func<Task<T>> taskGenerator)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                return await taskGenerator();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async Task Enqueue(Func<Task> taskGenerator)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                await taskGenerator();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
