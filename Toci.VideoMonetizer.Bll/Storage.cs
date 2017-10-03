using System.IO;
using System.IO.IsolatedStorage;
using Toci.VideoMonetizer.Bll.Interfaces;
using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;

namespace Toci.VideoMonetizer.Bll
{
    public class Storage : IStorage
    {
        public const string Delimiter = ";";

        protected string Path;

        public Storage(string path)
        {
            Path = path;
        }


        public virtual bool Save(IVideoReferenceMatchEntity videoMatch)
        {
            // save.OpenFile() save file patch ?
            using (StreamWriter writer = new StreamWriter(Path))
            {
                writer.WriteLine(videoMatch.BaseMovie + Delimiter + videoMatch.ReferencedMovie + Delimiter + videoMatch.TimeBaseMovie + Delimiter + videoMatch.TimeReferenced + "#");

                writer.Close();
            }

            return true;
        }
    }
}