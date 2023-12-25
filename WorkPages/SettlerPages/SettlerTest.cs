using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBD.WorkPages.SettlerPages
{
    class SettlerTest
    {
        public bool f;

        public SettlerTest() { }

        public Tuple<int, int> testVal(string n, string i)
        {
            try
            {
                int newN = Convert.ToInt32(n);
                int newI = Convert.ToInt32(i);

                f = true;
                return Tuple.Create(newN, newI);
            }
            catch
            {
                f = false;
                return Tuple.Create(0, 0);
            }
        }

        public int idTest(string id)
        {
            try
            {
                f = true;
                return Convert.ToInt32(id);
            }
            catch
            {
                f = false;
                return 1;
            }
        }

        public DateTime StringToDateTime(string date)
        {
            var temp = date.Split(':');

            if (temp.Length != 3)
            {
                f = false;
                return new DateTime(1, 1, 1);
            }
            else
            {
                try
                {
                    int year = Convert.ToInt32(temp[0]);
                    int month = Convert.ToInt32(temp[1]);
                    int day = Convert.ToInt32(temp[2]);

                    DateTime newDate = new DateTime(year, month, day);
                    f = true;

                    return newDate;
                }
                catch
                {
                    f = false;

                    return new DateTime(1, 1, 1);
                }
            }
        }

        public string DateTimeToString(DateTime dt)
        {
            return $"{dt.Year}:{dt.Month}:{dt.Day}";
        }
    }
}
