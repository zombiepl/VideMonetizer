using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;

namespace Toci.VideoMonetizer.Bll.DataEntities
{
    public class VideoReferenceMatchEntity : IVideoReferenceMatchEntity
    {
        public string BaseMovie { get; set; }
        public string ReferencedMovie { get; set; }
        public string TimeBaseMovie { get; set; }
        public string TimeReferenced { get; set; }
    }
}