using Routing_Application.Domain;

namespace Routing_Application.Structures
{
    // структура сегмент - величина связи - сегмент
    public struct Segment_Connect_Segment
    {
        public Segment Segment;
        public int Connectivity;
        public Segment ConnectedSegment;

        public Segment_Connect_Segment(Segment segment, int connectivity, Segment connectedSegment)
        {
            this.Segment = segment;
            this.Connectivity = connectivity;
            this.ConnectedSegment = connectedSegment;
        }

    }
}
