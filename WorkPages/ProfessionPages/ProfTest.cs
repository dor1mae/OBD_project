using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBD.WorkPages.ProfessionPages
{
    class ProfTest
    {
        public bool f;

        public ProfTest() { }

        public Tuple<int, int> testVal(string n, string id)
        {
            try
            {
                int new_n = Convert.ToInt32(n);
                int new_id = Convert.ToInt32(id);

                f = true;
                return Tuple.Create(new_n, new_id);
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
    }
}
