using System.Collections.Generic;

namespace Toci.VideoMonetizer.Bll.Interfaces.DataEntities
{
    public interface IVideoReferenceMatchEntity//<ReferenceMatchList>//dodany generyk
    {

        
        string BaseMovie { get; set; }

        string ReferencedMovie { get; set; }

        string TimeBaseMovie { get; set; }

        string TimeReferenced { get; set; }

      //  List<ReferenceMatchList> ReferenceMatchLists {get;set;}//dodane
    }
}


