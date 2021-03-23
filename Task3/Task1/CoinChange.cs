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
        public string DynamicCoinCange(int change, int[] nominals)
        {
            var oldNominals = _nominals;
            if (nominals.Distinct().ToArray().Length != nominals.Length)
            {
                throw new Exception("Coins should have unique values");
            }
            for (int g = 0; g < nominals.Length; g++)
            {
                if (nominals[g] < 0)
                    throw new Exception("Coin should be positive integer");
            }
            if (change < 0)
            {
                _nominals = oldNominals;
                _nominalsCount = oldNominals.Length;
                throw new Exception("Input should be a positive integer");
            }
            if (change == 0)
                return string.Empty;
            _nominals = nominals;
            _nominalsCount = nominals.Length;
            //Формула:
            //                ----- if p == 0 => 0
            //               |
            // minCoins[p] = |
            //               |
            //                ----- if p > 0 => if p >=c => if 1 + minCoins[p - c] < count => 1 + minCoins[p - c]
            //
            int[] minCoins = new int[change + 1];//массив с минимальным количеством монет для каждого числа от 1 до x
            int[] firstCoinIndex = new int[change + 1];//массив с индексами первых монет для каждого числа от 1 до x
            for (int p = 0; p < change + 1; p++)//начинаем заполнять массивы значениями для каждого числа от 1 до х
            {
                int count = p;//переменная для минимального количества необходимых монет для текущего числа
                int newCoin = 0;//переменная для индекса первой монеты для текущего числа
                foreach (var c in _nominals)
                {
                    if (p == 0) count = 0; //если число равно 0 то количество необходимых монет равно 0
                    if (c <= p)//если номинал монеты меньше или равен текущему числу то идем дальше
                    {
                        if (1 + minCoins[p - c] < count)//если сумма 1 и минимального количества монет под индексом р-с меньше чем минимальное количество монет для текущей цифры то идем дальше
                        {
                            count = 1 + minCoins[p - c];//минимальное количество монет равно минимальному количеству монет для числа равном текущему числу - номинал текущей монеты
                            newCoin = Array.IndexOf(_nominals, c);//индекс первой монеты для текущего числа равен индексу данной монеты в массиве монет
                        }
                    }
                }
                minCoins[p] = count;
                firstCoinIndex[p] = newCoin;
            }
            List<int> result = new List<int>();
            int k = change;
            while (k > 0)
            {
                var coin = _nominals[firstCoinIndex[k]];
                result.Add(coin);
                k = k - coin;
            }
            string resultString = string.Empty;
            for (int i = _nominalsCount - 1; i >= 0; i--)
            {
                if (result.Contains(_nominals[i]))
                    resultString += $"{result.Where(x => x == _nominals[i]).Count()} * {_nominals[i]},";
            }
            _nominals = oldNominals;
            _nominalsCount = oldNominals.Length;
            return resultString.Remove(resultString.Length - 1, 1);
        }
    }
}
