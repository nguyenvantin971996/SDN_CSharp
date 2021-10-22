using Routing_Application.Domain;

namespace Routing_Application.Structures
{
    // структура роутер - величина связи - сегмент
    public struct Router_Connect_Segment
    {
        public Router Router;
        public int Connectivity;
        public Segment Segment;

        public Router_Connect_Segment(Router router, int connectivity, Segment segment)
        {
            Router = router;
            Connectivity = connectivity;
            Segment = segment;
        }
    }
}
