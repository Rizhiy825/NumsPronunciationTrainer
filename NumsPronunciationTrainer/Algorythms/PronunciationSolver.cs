using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumsPronunciationTrainer.Algorythms;

public class PronunciationSolver
{
    public string GetPronunciation(int number)
    {
        var digitsChain = GetDigitsChain(number);
        var builder = new StringBuilder();
        var skipFlag = false;

        for (int i = digitsChain.Count; i > 0; i--)
        {
            var digit = 0;

            switch (i)
            {
                case 4:
                    digit = digitsChain[i - 1];

                    if (digit == 0)
                    {
                        builder.Append(" ");
                        break;
                    }

                    builder.Append(simpleNums[digit] + " thousand");
                    break;

                case 3:
                    digit = digitsChain[i - 1];
                    if (digitsChain.Count > 3) builder.Append(" ");
                    builder.Append(simpleNums[digit] + " houndred");
                    break;

                case 2:
                    digit = digitsChain[i - 1];
                    var nextDigit = digitsChain[i - 2];
                    var summaryNum = digit * 10 + nextDigit;

                    if (simpleNums.ContainsKey(summaryNum))
                    {
                        if (digitsChain.Count > 2) builder.Append(" and ");
                        builder.Append(simpleNums[summaryNum]);
                        skipFlag = true;
                    }
                    else
                    {
                        if (digitsChain.Count > 2) builder.Append(" ");
                        builder.Append(simpleNums[digit * 10]);
                    }

                    break;

                case 1:
                    if (skipFlag) break;

                    digit = digitsChain[i - 1];
                    builder.Append(" " + simpleNums[digit]);
                    break;
            }
        }

        return builder.ToString();
    }

    private List<int> GetDigitsChain(int number)
    {
        var digits = new List<int>();

        while (number / 10 != 0 || number % 10 != 0)
        {
            var curDigit = number % 10;
            number /= 10;

            digits.Add(curDigit);
        }

        return digits;
    }

    private Dictionary<int, string> simpleNums = new Dictionary<int, string>()
    {
        [0] = "zero",
        [1] = "one",
        [2] = "two",
        [3] = "three",
        [4] = "four",
        [5] = "five",
        [6] = "six",
        [7] = "seven",
        [8] = "eight",
        [9] = "nine",

        [10] = "ten",
        [11] = "eleven",
        [12] = "twelve",
        [13] = "thirteen",
        [14] = "fourteen",
        [15] = "fiveteen",
        [16] = "sixteen",
        [17] = "seventeen",
        [18] = "eighteen",
        [19] = "nineteen",

        [20] = "twenty",
        [30] = "thirty",
        [40] = "forty",
        [50] = "fifty",
        [60] = "sixty",
        [70] = "eventy",
        [80] = "eighty",
        [90] = "ninety",
    };
}