using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicPassword
{
    public class FileData : IFileData
    {
        public void ReadData(string path, List<string> list)
        {
            // Read Data On File
            var read = new StreamReader(path);
            string line = read.ReadLine();
            while (line != null)
            {
                list.Add(line);
                line = read.ReadLine();
            }
            read.Close();
            
        }

        public void SaveData(string path, List<string> list)
        {
            // Write Data On File
            var write = new StreamWriter(path);
            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    write.WriteLine(item);
                }
            }
            write.Close();
        }
    }
}