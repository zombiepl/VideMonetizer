using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Forms;
using Toci.VideoMonetizer.Bll.DataEntities;
using Toci.VideoMonetizer.Bll.Interfaces;
using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;



namespace Toci.VideoMonetizer.Bll
{
    public class Storage : IStorage
    {
        public const string Delimiter = ";";

        //protected string Path;

        //public Storage(string path)
        //{
        //    Path = path;
        //}
        SaveFileDialog save = new SaveFileDialog();
                               
        public virtual bool Save(List<IVideoReferenceMatchEntity> videoMatchList)
        {    //przyjmuje jako parametr wszystkie obiekty implelentujące interfejs            

            //save.OpenFile() save file patch ?
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.tci";
            save.Filter = "Toci files|*.tci";
            

            if (save.ShowDialog() == DialogResult.OK)
            {
              
              //????  List<IVideoReferenceMatchEntity> vRefMatchEnt = uiTranslation.GetVideoReferenes(listView1);


                using (StreamWriter writer = new StreamWriter(save.OpenFile()))
                {
                    foreach (var item in videoMatchList)
                    {
                        writer.WriteLine(item.BaseMovie + Delimiter + item.ReferencedMovie + Delimiter + item.TimeBaseMovie + Delimiter + item.TimeReferenced + "#");
                    }
                    
                    writer.Close();
                }
            }
            return true;
        }
    }
}