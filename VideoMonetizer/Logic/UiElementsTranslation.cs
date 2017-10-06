using System.Collections.Generic;
using System.Windows.Forms;
using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;

namespace VideoMonetizer.Logic
{       //UI - user interface
    public class UiElementsTranslation : IUiElementsTranslation
    {
        private ListViewItem listviewitem;//inicjalizacja obiektu
        public List<IVideoReferenceMatchEntity> GetVideoReferenes(ListView lVItem)
        {//metoda przyjmującalistview  a zwracajaca List 
            
            

            listviewitem = new ListViewItem(_videoReferenceMatchEntity.BaseMovie);
            listviewitem.SubItems.Add(_videoReferenceMatchEntity.ReferencedMovie);
            listviewitem.SubItems.Add(_videoReferenceMatchEntity.TimeBaseMovie);
            listviewitem.SubItems.Add(_videoReferenceMatchEntity.TimeReferenced);
            listView1.Items.Add(listviewitem);//wyjeba© do metody zapisujácej na listview1

            foreach (ListViewItem item in lVItem.Items)
            {

            }

            return null;
        }
    }
}