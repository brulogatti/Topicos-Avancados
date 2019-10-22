using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicoHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServicoHost.Servico), new Uri[] { });
            host.Open();
            Console.WriteLine("Serviço rodando...");
            Console.WriteLine("Tecle para finalizar.");
            Console.ReadKey();
            host.Close();
        }
    }
}
