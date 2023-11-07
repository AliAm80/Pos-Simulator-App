using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos
{
    public interface IFileData
    {
        public void ReadData(string path, List<string> list);
        public void SaveData(string path, List<string> list);
    }
}