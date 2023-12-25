using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBD.WorkPages.WorkerPages
{
    class WorkerTest
    {
        public bool f;

        public WorkerTest() { }

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
    }
}
