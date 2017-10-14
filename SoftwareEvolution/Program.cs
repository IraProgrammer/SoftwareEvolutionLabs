using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    class Program
    {
        static void Main(string[] args)
        {

            string filename = "BillInfo.yaml";
            if (args.Length == 1)
            {
                filename = args[0];
            }

            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            YAMLFile yamlfile = new YAMLFile();
            IPresenter p = new TXTPresenter();
            Console.WriteLine(yamlfile.CreateBill(sr, p));

            Console.ReadKey();
        }
    }
}