using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcKayitProgram.Formlar
{
    internal class GlobalEvents
    {
        public static event EventHandler DataChanged;

        public static void OnDataChanged()
        {
            DataChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
