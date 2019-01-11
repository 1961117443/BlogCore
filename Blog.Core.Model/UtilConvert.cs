using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
    public static class UtilConvert
    {
        public static long ObjToInt(this object data)
        {
            long.TryParse(data.ToString(), out long l);
            return l;
        }

        public static string ObjToString(this object data)
        {
            return data.ToString();
        }
    }
}
