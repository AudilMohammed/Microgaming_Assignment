using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microgaming.UiModels
{
    public class FileDetailsUiModel
    {
        
        public int id { get; set; }      
        public long CharityId { get; set; }      
        public string FileName { get; set; }
        
        public byte[] FileInfo { get; set; }

        public  CharityRecordUiModel CharityRecord { get; set; }
    }
}
