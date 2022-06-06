using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW2_Extension
{
    public static class HW2_Extension
    {
        public static string Ago(this DateTime time)
        {

            var now = DateTime.Now;
            var beforeAfter = time < now ? "önce" : "sonra";
            var ago = time.Subtract(now);
            var days = beforeAfter == "önce" ? -1 * ago.Days : ago.Days;
            var hours = beforeAfter == "önce" ? -1 * ago.Hours : ago.Hours;
            var minutes = beforeAfter == "önce" ? -1 * ago.Minutes : ago.Minutes;

            return $"{days} gün {hours} saat {minutes} dakika {beforeAfter}";

        }
    }
}
}
