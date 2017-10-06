using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;
//zawartosc writeline z writera z przycisku button1
namespace Toci.VideoMonetizer.Bll.DataEntities
{
    public class VideoReferenceMatchEntity : IVideoReferenceMatchEntity
    {       
        public string BaseMovie { get; set; }
        public string ReferencedMovie { get; set; }
        public string TimeBaseMovie { get; set; }
        public string TimeReferenced { get; set; }

        //stworzyc metode uzupelniania pol w itemviw1
    }
}