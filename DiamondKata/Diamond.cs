using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondKata
{
    public class Diamond
    {
        private readonly char[] _alphabet;

        public Diamond()
        {
            _alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
        }

        public string Create(char input)
        {
            if (!_alphabet.Contains(input))
            {
                throw new ArgumentException("Invalid character. Only uppercase letters are allowed.");
            }

            return BuildFullDiamond(input);
        }

        private string BuildFullDiamond(char input)
        {
            var topHalfDiamond = BuildHalfDiamond(input);
            var bottomHalfDiamond = BuildBottomHalfDiamond(topHalfDiamond);
            var fullDiamond = topHalfDiamond.Concat(bottomHalfDiamond);

            return string.Join(string.Empty, fullDiamond).TrimEnd(Environment.NewLine.ToCharArray());
        }

        private List<string> BuildHalfDiamond(char input)
        {
            var lines = new List<string>();
            var maximumLetterPosition = Array.IndexOf(_alphabet, input);

            for (var i = 0; i <= maximumLetterPosition; i++)
            {
                lines.Add(BuildLine(i, maximumLetterPosition));
            }

            return lines;
        }

        private List<string> BuildBottomHalfDiamond(List<string> halfDiamond)
        {
            var bottomHalfDiamond = new List<string>();
            bottomHalfDiamond.AddRange(halfDiamond);
            bottomHalfDiamond.Reverse();

            return bottomHalfDiamond.Skip(1).ToList();
        }

        private string BuildLine(int currentLetterPosition, int maximumLetterPosition)
        {
            var paddingOuter = maximumLetterPosition - currentLetterPosition;
            var paddingMiddle = currentLetterPosition * 2 - 1;

            var sb = new StringBuilder();
            sb.Append(string.Empty.PadLeft(paddingOuter));
            sb.Append(_alphabet[currentLetterPosition]);

            if (currentLetterPosition > 0)
            {
                sb.Append(string.Empty.PadLeft(paddingMiddle));
                sb.Append(_alphabet[currentLetterPosition]);
            }

            sb.Append(string.Empty.PadLeft(paddingOuter));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
