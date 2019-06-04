using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class CharArray
    {
        public void Test()
        {
            var input = "2346578811";
            var map = new Dictionary<char, string>()
            {
                {'0', "ABC"},
                {'1', ""},
                {'2', "DEF"},
                {'3', "GHJ"},
                {'4', "KLM"},
                {'5', "NO"},
                {'6', "PQR"},
                {'7', "ST"},
                {'8', "UVW"},
                {'9', "XYZ"},
            };

            var arr = input.ToCharArray();
            Dictionary<char,List<char>> mapArr=new Dictionary<char, List<char>>();
            foreach (var item in arr)
            {
                var mapParamArr = map[item].ToCharArray();
                foreach (var m in mapParamArr)
                {
                    
                }
            }
        }
    }
}
