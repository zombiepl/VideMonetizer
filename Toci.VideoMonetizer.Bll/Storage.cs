using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Forms;
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
                               
        public virtual bool Save(IVideoReferenceMatchEntity videoMatch)
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

                    foreach (var writerlista in listView1)
                    {
                        writer.WriteLine(videoMatch.BaseMovie + Delimiter + videoMatch.ReferencedMovie + Delimiter +
                                         videoMatch.TimeBaseMovie + Delimiter + videoMatch.TimeReferenced + "#");
                    }
                   

                    writer.Close();
                }
            }
            return true;
        }
    }
}