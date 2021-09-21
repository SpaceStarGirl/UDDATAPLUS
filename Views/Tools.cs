using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDDATA.Views
{
    class Tools
    {
        internal static object connectionString;

        public static string cr()
        {
            return Console.ReadLine();
        }

        public static DateTime String2Datetime(string dob)
        {
            string[] dobStringSplitArray = dob.Split('-');
            int[] dobIntArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int.TryParse(dobStringSplitArray[i], out dobIntArray[i]);
            }
            DateTime dt = new DateTime(dobIntArray[2], dobIntArray[1], dobIntArray[0]);
            return dt;
        }
    }
}
