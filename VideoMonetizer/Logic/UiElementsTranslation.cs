using System.Collections.Generic;
using System.Windows.Forms;
using Toci.VideoMonetizer.Bll.DataEntities;
using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;

namespace VideoMonetizer.Logic
{       //UI - user interface
    public class UiElementsTranslation : IUiElementsTranslation
    {
        private List<IVideoReferenceMatchEntity> dupa = new List<IVideoReferenceMatchEntity>();
        //  private ListViewItem listviewitem;//inicjalizacja obiektu
        //public zwraca List<IVideoReferenceMatchEntity>  przeyjmuje: GetVideoReferenes(ListView lVItem)
        public List<IVideoReferenceMatchEntity> GetVideoReferenes(ListViewItem lVItem)
        {
            VideoReferenceMatchEntity vrme = new VideoReferenceMatchEntity();

            vrme.BaseMovie = lVItem.Text;
            vrme.ReferencedMovie = lVItem.SubItems[1].Text;
            vrme.TimeBaseMovie = lVItem.SubItems[2].Text;
            vrme.TimeReferenced = lVItem.SubItems[3].Text;
            

            dupa.Add(vrme);
            return dupa;
        }
    }
}