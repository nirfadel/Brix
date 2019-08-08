using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2_SearchText
{
    public class ReadAndSearchInput
    {
        public ReadAndSearchInput(string input)
        {
            _input = input;
            ReadFile();
        }

        public string[] GetSearchResult()
        {
            Dictionary<char, int> dicChars = getCharCount(_input);
            DictionaryComparer<char, int> dictionaryComparer = new DictionaryComparer<char, int>();
            
            var arrStr = Strings.Where(x => dictionaryComparer.Equals(getCharCount(x), dicChars)).Select(s => s);
            return arrStr.ToArray();
        }

        private void ReadFile()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Files\data.txt");
            Strings = File.ReadAllLines(path);

        }

        private Dictionary<char, int> getCharCount(string name)
        {
            return name.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
        }

        private string[] Strings;
        private string _input;
    }
}
