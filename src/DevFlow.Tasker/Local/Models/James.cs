using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Tasker.Local.Models
{
    public interface IService
    {
        IService Create();
        List<Service> Services { get; }
    }

    public class Service : IService
    {
        private static IService Instance;

        public static IService Get() => Instance;

        static Service()
        {
            Instance = new Service();
        }

        private Service()
        {

        }

        public List<Service> Services { get; private set; }

        public IService Create()
        {
            Service service = new Service();
            Services.Add(service);
            return service;
        }
    }
}
