using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        public class FileDelete
       {
        static void Main(string[] args)
        {
            string fname = "File.txt";
            string path =@"C:\Users\Aser\Desktop\cake\bad";
            string path1 = @"C:\Users\Aser\Desktop\cake\salt";
            string soufile = Path.Combine( path, fname);
            string desfile = Path.Combine( path1, fname);
            
         
           if(!Directory.Exists( path))
            {
                Directory.CreateDirectory( path);
              
            }
             FileStream fs=File.Create(soufile);
             fs.Close();
              File.Copy(soufile,desfile, true);
            if(Directory.Exists( path1))
            {
                string[] files = Directory.GetFiles( path);
                foreach(string s in files)
                {
                    fname = Path.GetFileName(s);
                    desfile = Path.Combine( path1, fname);
                    File.Copy(s,desfile,true);
                }
            } 
          if(Directory.Exists(@"C:\Users\Aser\Desktop\cake\bad"))
          {
           try
            {
            Directory.Delete(@"C:\Users\Aser\Desktop\cake\bad",true);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
                    return;
            }   
          }
            
           Console.ReadKey();
             
          
        }
        
      }
    }
}
