using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lab3
{
        class FarManager
        {
            public int cursor;
            public string path;
            public int sz;
            public bool ok;
            DirectoryInfo directory = null;
            FileSystemInfo currentFs = null;

            public FarManager(string path)
            {
                this.path = path;
                cursor = 0;
                directory = new DirectoryInfo(path);
                sz = directory.GetFileSystemInfos().Length;
                ok = true;
            }

            public void Color(FileSystemInfo fs, int index)//choice colors
            {
                if (cursor == index)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    currentFs = fs;
                }
                else if (fs.GetType() == typeof(DirectoryInfo))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }

            public void Show() //write in output name of directories or files in order with number
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                directory = new DirectoryInfo(path);
                FileSystemInfo[] fs = directory.GetFileSystemInfos();
                for (int i = 0; i < fs.Length; i++)
                {
                    if (ok == false && fs[i].Name[0] == '.')//avoid from hidden files
                    {
                        continue;
                    }
                    Color(fs[i], i);
                    Console.Write(i + 1 + ".");
                    Console.WriteLine(fs[i].Name);
                }
            }
            public void Up()//motion "up"
            {
                cursor--;
                if (cursor < 0)
                    cursor = sz - 1;
            }
            public void Down()//motion "down"
            {
                cursor++;
                if (cursor == sz)
                    cursor = 0;
            }

            public void CalcSz()//don't write index of hidden file
            {
                directory = new DirectoryInfo(path);
                FileSystemInfo[] fs = directory.GetFileSystemInfos();
                sz = fs.Length;
                if (ok == false)
                    for (int i = 0; i < fs.Length; i++)
                        if (fs[i].Name[0] == '.')
                            sz--;
            }
            public void Opentxt(string name) //open text file
            {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    StreamReader sr = new StreamReader(name);
                    string red = sr.ReadToEnd();
                    Console.WriteLine(red);
                    ConsoleKeyInfo n = Console.ReadKey();
                     if (n.Key == ConsoleKey.Backspace)
                     {
                        sr.Close();
                        return;
                     }
                     else
                        Opentxt(name);
            }
            
            public void Start() //fundamental method
            {
              ConsoleKeyInfo consoleKey = Console.ReadKey();
              while (consoleKey.Key != ConsoleKey.Escape)//when press "Esc" program close 
              {
                CalcSz();//method that delete place of hidden file and decrise length
                Show();//method to show in output directories or files
                consoleKey = Console.ReadKey(); //defining a button
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.Enter)//opening directories ,files
                {
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        path = currentFs.FullName;
                    }
                    else if (currentFs.Name.EndsWith(".txt"))//if find text file open it
                        Opentxt(currentFs.FullName);//method of opening text file
                }
                if (consoleKey.Key == ConsoleKey.Backspace)//motion back
                {
                    cursor = 0;
                    path = directory.Parent.FullName;
                }
                if (consoleKey.Key == ConsoleKey.Delete) //deleting directories or files
                {
                    cursor = 0;
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                        Directory.Delete(currentFs.FullName, true);
                    currentFs.Delete();

                }
                if(consoleKey.Key==ConsoleKey.Home)//renaming directories or files
                {
                    string fn = Console.ReadLine();
                    fn = Path.Combine(directory.FullName, fn);
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                        Directory.Move(currentFs.FullName, fn);
                    else
                        File.Move(currentFs.FullName, fn);
                }
              }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                string path = @"C:\Users\Aser\Desktop\cake";//point into path
                FarManager farManager = new FarManager(path);//create farmanager
                farManager.Start();//go to method Start
            }
        }
 }

