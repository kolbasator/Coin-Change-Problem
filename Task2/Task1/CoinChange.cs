using System;
using System.Text.RegularExpressions; 
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    public class CoinChange
    {
        private static int[] _nominals = new int[] { 1, 2, 5, 10, 20, 50, 100 };
        private static int _nominalsCount = _nominals.Length;
        public string GreedlyAlgorithm(int x, int[] nominals)
        { 
            var oldNominals = _nominals; 
            for (int p = 0; p < nominals.Length; p++)
            {
                var nominalMatchCount = nominals.Where(x => x == nominals[p]).Count();
                if (nominalMatchCount != 1) 
                    throw new Exception("Coins should have uniquevalues");  
                else if (nominals[p] < 0) 
                    throw new Exception("Coin should be positive integer");  
            } 
            if (x < 0)
            {
                _nominals = oldNominals;
                _nominalsCount = oldNominals.Length;
                throw new Exception("Input should be a positive integer"); 
            }
            if (x == 0) 
                return string.Empty;
            _nominals = nominals;
            _nominalsCount = nominals.Length;
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
                    resultString += $"{result.Where(x => x == _nominals[i]).Count()} * {_nominals[i]},"; 
            }
            _nominals = oldNominals;
            _nominalsCount = oldNominals.Length;
            return resultString.Remove(resultString.Length - 1); ;
        }
    }
}
