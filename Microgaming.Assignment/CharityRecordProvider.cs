using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microgaming.Assignment
{
    public class CharityRecordProvider
    {
        public IEnumerable<CharityRecord> GetRecords(string userId)
        {
            using (CharityEntities entities = new CharityEntities())
            {
                return entities.CharityRecords.Where(x=>x.UserId==userId).ToList();                 
            }


        }
    }
}
