using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CirclePointsA
{
    class PointReg
    {
        internal double _x;
        internal double _y;

        public void RegEXP(string text)
        {
            string pattern = @"[-+]?\d+(\.\d+)?";

            List<double> ds = new List<double>();

            MatchCollection matchCollection = Regex.Matches(text, pattern);

            foreach (Match match in matchCollection)
            {
                double theid = double.Parse(match.Value);
                ds.Add(theid);
            }

            _x = ds[0];
            _y = ds[1];
        }
    }

}