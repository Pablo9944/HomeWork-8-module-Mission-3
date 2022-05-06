using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_8_module_Mission_3
{
    internal class Program
    {
        const string Path = @"Delete";
        static DirectoryInfo dI = new DirectoryInfo(Path);
        static void Main(string[] args)
        {
         

            long count = 0;
            long height = 0;

            try
            {
                if (Check(Path))
                {
                    DeletDirectory(dI,ref height,ref count);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Папка и файлы внутри удалены");
            }


        }

        /// <summary>
        /// Метод удалаяет необходимую нам папку
        /// </summary>
        static void DeletDirectory(DirectoryInfo dI,ref long height, ref long count )
        {
            

          
            FileInfo[] fls = dI.GetFiles();
            
            foreach (FileInfo f in fls)
            {
                count++;
                height += f.Length;
                f.Delete();
                
            }

            

            DirectoryInfo[] dir = dI.GetDirectories();

            foreach (DirectoryInfo e in dir)
            {
               

                FileInfo[] File = e.GetFiles();
                
                foreach (FileInfo f in File)
                {
                    count++;
                    height += f.Length;
                    f.Delete();
                }


             

                e.Delete();

                
                if (dI.GetDirectories().Length == 0)
                {

                    Console.WriteLine($"Папка {dI.Name} размер: {height} \n");
                    Console.WriteLine($"Папка {dI.Name} имела {count} файлов\n");
                    Console.WriteLine($"Освобождено: {height}\n");
                    
                }

               
                DeletDirectory(dI,ref height,ref count);

            }





        }

        /// <summary>
        /// Метод позволяющий проверить путь к папке,а также использование файлов в течении 30 минут
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static bool Check(string Path)
        {
            DateTime time = DateTime.Now;
            bool check = false;


            if (Directory.Exists(Path))
            {
                FileInfo FI = new FileInfo(Path);
                DateTime timeCreate = FI.CreationTime;
                TimeSpan result = time - timeCreate;

                if (result.Minutes > 30)
                {
                    Console.WriteLine("Найдена директория которая неиспользовалась 30 минут");
                    check = true;
                }
                else
                {
                    Console.WriteLine("Файлы использовализь в течении 30 минут");
                    check = false;

                }
            }

            else
                Console.WriteLine("Проверьте указанный путь или присутствие папки");

            return check;
        }
    }
}    

