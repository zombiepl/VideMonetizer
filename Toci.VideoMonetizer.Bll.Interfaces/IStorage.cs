using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;

namespace Toci.VideoMonetizer.Bll.Interfaces
{
    public interface IStorage
    {
        bool Save(IVideoReferenceMatchEntity videoMatch);
    }
}