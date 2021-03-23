using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    public class CoinChange
    {
        public string GreedlyAlgorithm(int x, int[] nominals)
        {
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
                throw new Exception("Input should be a positive integer");
            }
            if (x == 0)
                return string.Empty;
            List<int> result = new List<int>();
            string resultString = string.Empty;
            for (int i = nominals.Length - 1; i >= 0; i--)
            {
                while (x >= nominals[i])
                {
                    x -= nominals[i];
                    result.Add(nominals[i]);
                }
            }
            for (int i = nominals.Length - 1; i >= 0; i--)
            {
                if (result.Contains(nominals[i]))
                    resultString += $"{result.Where(x => x == nominals[i]).Count()} * {nominals[i]},";
            } 
            return resultString.Remove(resultString.Length - 1); ;
        }
        public string DynamicCoinCange(int change, int[] nominals)
        {
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
                throw new Exception("Input should be a positive integer");
            }
            if (change == 0)
                return string.Empty;
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
                foreach (var c in nominals)
                {
                    if (p == 0) count = 0; //если число равно 0 то количество необходимых монет равно 0
                    if (c <= p)//если номинал монеты меньше или равен текущему числу то идем дальше
                    {
                        if (1 + minCoins[p - c] < count)//если сумма 1 и минимального количества монет под индексом р-с меньше чем минимальное количество монет для текущей цифры то идем дальше
                        {
                            count = 1 + minCoins[p - c];//минимальное количество монет равно минимальному количеству монет для числа равном текущему числу - номинал текущей монеты
                            newCoin = Array.IndexOf(nominals, c);//индекс первой монеты для текущего числа равен индексу данной монеты в массиве монет
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
                var coin =nominals[firstCoinIndex[k]];
                result.Add(coin);
                k = k - coin;
            }
            string resultString = string.Empty;
            for (int i =nominals.Length - 1; i >= 0; i--)
            {
                if (result.Contains(nominals[i]))
                    resultString += $"{result.Where(x => x == nominals[i]).Count()} * {nominals[i]},";
            } 
            return resultString.Remove(resultString.Length - 1, 1);
        }
    }
}
