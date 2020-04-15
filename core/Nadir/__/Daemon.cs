using System.Collections.Generic;

namespace Nadir
{
    public class Daemon
    {
        internal void Start()
        {
            foreach (var worker in Workers)
            {
                worker.Run();
            }
        }



        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }





        public IList<Worker> Workers { get; } = new List<Worker>();
    }
}
