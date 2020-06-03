using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

    public class NumberToWords
    {
        private const long Quadrillion = Trillion * 1000;
        private const long Trillion = Billion * 1000;
        private const long Billion = Million * 1000;
        private const long Million = Thousand * 1000;
        private const long Thousand = Hundred * 10;
        private const long Hundred = 100;

        public string ToVerbal(double value)
        {
            if (value == 0) return "zero";

            if (value < 0)
            {
                return "negative " + ToVerbal(Math.Abs(value));
            }

            System.Text.StringBuilder builder = new StringBuilder();

            int unit = 0;

            if (value >= Quadrillion)
            {
                unit = (int)(value / Quadrillion);
                value -= unit * Quadrillion;

                builder.AppendFormat("{0}{1} quadrillion", builder.Length > 0 ? ", " : string.Empty, ToVerbal(unit));
            }

            if (value >= Trillion)
            {
                unit = (int)(value / Trillion);
                value -= unit * Trillion;

                builder.AppendFormat("{0}{1} trillion", builder.Length > 0 ? ", " : string.Empty, ToVerbal(unit));
            }

            if (value >= Billion)
            {
                unit = (int)(value / Billion);
                value -= unit * Billion;

                builder.AppendFormat("{0}{1} billion", builder.Length > 0 ? ", " : string.Empty, ToVerbal(unit));
            }

            if (value >= Million)
            {
                unit = (int)(value / Million);
                value -= unit * Million;

                builder.AppendFormat("{0}{1} Million", builder.Length > 0 ? ", " : string.Empty, ToVerbal(unit));
            }

            if (value >= Thousand)
            {
                unit = (int)(value / Thousand);
                value -= unit * Thousand;

                builder.AppendFormat("{0}{1} Thousand", builder.Length > 0 ? ", " : string.Empty, ToVerbal(unit));
            }

            if (value >= Hundred)
            {
                unit = (int)(value / Hundred);
                value -= unit * Hundred;

                builder.AppendFormat("{0}{1} Hundred", builder.Length > 0 ? ", " : string.Empty, ToVerbal(unit));
            }

            if (builder.Length > 0 && value > 0) builder.AppendFormat(" and");

            if (value >= 90)
            {
                value -= 90;

                builder.AppendFormat("{0}Ninety", builder.Length > 0 ? " " : string.Empty);
            }

            if (value >= 80)
            {
                value -= 80;

                builder.AppendFormat("{0}Eighty", builder.Length > 0 ? " " : string.Empty);
            }

            if (value >= 70)
            {
                value -= 70;

                builder.AppendFormat("{0}Seventy", builder.Length > 0 ? " " : string.Empty);
            }

            if (value >= 60)
            {
                value -= 60;

                builder.AppendFormat("{0}Sixty", builder.Length > 0 ? " " : string.Empty);
            }

            if (value >= 50)
            {
                value -= 50;

                builder.AppendFormat("{0}Fifty", builder.Length > 0 ? " " : string.Empty);
            }

            if (value >= 40)
            {
                value -= 40;

                builder.AppendFormat("{0}Forty", builder.Length > 0 ? " " : string.Empty);
            }

            if (value >= 30)
            {
                value -= 30;

                builder.AppendFormat("{0}Thirty", builder.Length > 0 ? " " : string.Empty);
            }

            if (value >= 20)
            {
                value -= 20;

                builder.AppendFormat("{0}Twenty", builder.Length > 0 ? " " : string.Empty);
            }

            if (value == 19) builder.AppendFormat("{0}Nineteen", builder.Length > 0 ? " " : string.Empty);
            if (value == 18) builder.AppendFormat("{0}Eighteen", builder.Length > 0 ? " " : string.Empty);
            if (value == 17) builder.AppendFormat("{0}Seventeen", builder.Length > 0 ? " " : string.Empty);
            if (value == 16) builder.AppendFormat("{0}Sixteen", builder.Length > 0 ? " " : string.Empty);
            if (value == 15) builder.AppendFormat("{0}Fifteen", builder.Length > 0 ? " " : string.Empty);
            if (value == 14) builder.AppendFormat("{0}Fourteen", builder.Length > 0 ? " " : string.Empty);
            if (value == 13) builder.AppendFormat("{0}Thirteen", builder.Length > 0 ? " " : string.Empty);
            if (value == 12) builder.AppendFormat("{0}Twelve", builder.Length > 0 ? " " : string.Empty);
            if (value == 11) builder.AppendFormat("{0}Eleven", builder.Length > 0 ? " " : string.Empty);
            if (value == 10) builder.AppendFormat("{0}Ten", builder.Length > 0 ? " " : string.Empty);
            if (value == 9) builder.AppendFormat("{0}Nine", builder.Length > 0 ? " " : string.Empty);
            if (value == 8) builder.AppendFormat("{0}Eight", builder.Length > 0 ? " " : string.Empty);
            if (value == 7) builder.AppendFormat("{0}Seven", builder.Length > 0 ? " " : string.Empty);
            if (value == 6) builder.AppendFormat("{0}Six", builder.Length > 0 ? " " : string.Empty);
            if (value == 5) builder.AppendFormat("{0}Five", builder.Length > 0 ? " " : string.Empty);
            if (value == 4) builder.AppendFormat("{0}Four", builder.Length > 0 ? " " : string.Empty);
            if (value == 3) builder.AppendFormat("{0}Three", builder.Length > 0 ? " " : string.Empty);
            if (value == 2) builder.AppendFormat("{0}Two", builder.Length > 0 ? " " : string.Empty);
            if (value == 1) builder.AppendFormat("{0}One", builder.Length > 0 ? " " : string.Empty);

            return builder.ToString();
        }
    }
