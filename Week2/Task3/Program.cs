using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task3
{
    class Program
    {
         static void Main(string[] args)
        {
            Way();
            Console.ReadKey();
        }

        private static void PrintInfo(FileSystemInfo sp, int k)
        {
            string path = new string(' ', k);
            path = path + sp.Name;
            Console.WriteLine(path);

            if(sp.GetType() == typeof(DirectoryInfo))
            {
                var items = (sp as DirectoryInfo).GetFileSystemInfos();
                
                foreach (var i in items)
                {
                    PrintInfo(i, k + 6);
                }
            }
        }

        private static void Way()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Aser\Desktop\cake");
            PrintInfo(dir, 1);
        }
    }
}
