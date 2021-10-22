using System;

namespace Routing_Application.DAL
{
    /// <summary>
    /// статический класс, хранящий константы
    /// </summary>
    public static class Const
    {
        private static int inf = Int16.MaxValue;

        public static int INF
        {
            get { return inf; }
        }
    }
}
