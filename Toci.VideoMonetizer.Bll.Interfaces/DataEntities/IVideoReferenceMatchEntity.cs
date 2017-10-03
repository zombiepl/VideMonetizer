namespace Toci.VideoMonetizer.Bll.Interfaces.DataEntities
{
    public interface IVideoReferenceMatchEntity
    {
        string BaseMovie { get; set; }

        string ReferencedMovie { get; set; }

        string TimeBaseMovie { get; set; }

        string TimeReferenced { get; set; }
    }
}