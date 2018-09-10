using AutoMapper;
using Microgaming.Assignment;
using Microgaming.UiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microgaming.BAL
{
    public class CharityRecordServices
    {
        public List<CharityRecordUiModel> GetRecords(string userId)
        {
            CharityRecordProvider provider = new CharityRecordProvider();
            {

                IEnumerable<CharityRecord> record = provider.GetRecords(userId);
                var model = new List<CharityRecordUiModel>();
                foreach (var item in record)
                {
                    var result = new CharityRecordUiModel()
                    {
                        Charity = item.Charity,
                        Currency = item.Currency,
                        Description = item.Description,
                        FileInfo = item.FileInfo,
                        id = item.Id,
                        PlayItFwd = item.PlayItForward,
                        Title = item.Title,
                        UserId = item.UserId
                    };
                    model.Add(result);
                }
                return model;
            }
        }
    }
}
    

