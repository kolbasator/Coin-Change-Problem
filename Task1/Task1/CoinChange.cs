using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    public class CoinChange
    {
        private static int[] _nominals = new int[] { 1, 2, 5, 10, 20, 50, 100 };
        private static int _nominalsCount = _nominals.Length;
        public string GreedlyAlgorithm(int x)
        {
            if (x == 0)
                return string.Empty;
            List<int> result = new List<int>();
            string resultString = string.Empty;
            for (int i = _nominalsCount - 1; i >= 0; i--)
            {
                while (x >= _nominals[i])
                {
                    x -= _nominals[i];
                    result.Add(_nominals[i]);
                }
            }
            for (int i = _nominalsCount - 1; i >= 0; i--)
            {
                if (result.Contains(_nominals[i]))
                {
                    resultString += $"{result.Where(x => x == _nominals[i]).Count()} * {_nominals[i]},";
                }
            } 
            return resultString.Remove(resultString.Length - 1); ;
        }
    }
}
