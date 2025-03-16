using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public static class ReadFile
    {
        public static List<Personnel> JsonReadFile(string path)
        {
            var json = File.ReadAllText(path);
            var personnelList = JsonSerializer.Deserialize<List<Personnel>>(json);
            return personnelList;
        }
    }
}
