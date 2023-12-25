using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OBD.WorkPages.DirectoryPages
{
    class DirTest
    {
        public bool f;

        public DirTest() { }

        public Tuple<int, int, int, int, int> testVal(string h, string width, string id, string weigth, string l)
        {
            try
            {
                int new_h = Convert.ToInt32(h);
                int new_width = Convert.ToInt32(width);
                int new_id = Convert.ToInt32(id);
                int new_weigth = Convert.ToInt32(weigth);
                int new_l = Convert.ToInt32(l);

                f = true;
                return Tuple.Create(new_h, new_width, new_id, new_weigth, new_l);
            }
            catch 
            {
                f = false;
                return Tuple.Create(0, 0, 0, 0, 0);
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
