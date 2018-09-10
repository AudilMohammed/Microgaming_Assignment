using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microgaming.UiModels
{
    public class CharityRecordUiModel
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Charity { get; set; }
        public bool PlayItFwd { get; set; }       
        public byte[] FileInfo { get; set; }      
        public float Currency { get; set; }

        public string UserId { get; set; }
    }
}
