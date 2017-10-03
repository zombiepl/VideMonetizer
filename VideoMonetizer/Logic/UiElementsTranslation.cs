using System.Collections.Generic;
using System.Windows.Forms;
using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;

namespace VideoMonetizer.Logic
{
    public class UiElementsTranslation : IUiElementsTranslation
    {
        public List<IVideoReferenceMatchEntity> GetVideoReferenes(ListView lVItem)
        {
            foreach (ListViewItem item in lVItem.Items)
            {

            }

            return null;
        }
    }
}