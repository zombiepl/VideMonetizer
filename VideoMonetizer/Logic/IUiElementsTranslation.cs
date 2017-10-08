using System.Collections.Generic;
using System.Windows.Forms;
using Toci.VideoMonetizer.Bll.DataEntities;
using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;

namespace VideoMonetizer.Logic
{
    public interface IUiElementsTranslation
    {
        List<IVideoReferenceMatchEntity> GetVideoReferenes(ListViewItem lVItem);
    }
}