using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microgaming.UiModels;
using System.Data.Entity;
using Microgaming.Helper;

namespace Microgaming.Assignment
{
    public class CharityRecordProvider
    {
        public List<CharityRecordUiModel> GetRecords(string userId)
        {
            using (CharityEntities entities = new CharityEntities())
            {
                List<CharityRecord> record = entities.CharityRecords.Where(x => x.UserId == userId).ToList();
                var model = new List<CharityRecordUiModel>();
                foreach (var item in record)
                {
                    var result = new CharityRecordUiModel()
                    {
                        Charity = item.Charity,
                        Currency = (float)item.Currency,
                        Description = item.Description,
                        id = item.Id,
                        PlayItFwd = item.PlayItForward,
                        Title = item.Title,
                        UserId = item.UserId,
                        IsAdmin = false,
                        status = GetStatus(item.Status)
                                         
                    };
                    model.Add(result);
                }
                return model;
            }
        }

        private string GetStatus(int id) => ((Status)id).ToString();

        public List<CharityRecordUiModel> GetRecords()
        {
            using (CharityEntities entities = new CharityEntities())
            {
                List<CharityRecord> record = entities.CharityRecords.ToList();
                var model = new List<CharityRecordUiModel>();
                foreach (var item in record)
                {
                    var result = new CharityRecordUiModel()
                    {
                        Charity = item.Charity,
                        Currency = (float)item.Currency,
                        Description = item.Description,
                        id = item.Id,
                        PlayItFwd = item.PlayItForward,
                        Title = item.Title,
                        UserId = item.UserId,
                        IsAdmin = true,
                        status = GetStatus(item.Status)
                    };
                    model.Add(result);
                }
                return model;
            }
        }

        public CharityRecordUiModel LoadRecordtoEdit(int trid)
        {
            using(CharityEntities entities = new CharityEntities())
            {
                var result= entities.CharityRecords.Where(x => x.Id == trid).Include(x => x.FileDetails).
                FirstOrDefault();
                List <FileDetailsUiModel> files= new List<FileDetailsUiModel>();
                foreach(var item in result.FileDetails)
                {
                    FileDetailsUiModel model = new FileDetailsUiModel();
                    model.FileInfo = item.FileInfo;                    
                    model.FileName = item.FileName;
                    model.CharityId = item.CharityId;
                    model.id = item.Id;
                    files.Add(model);
                }

                var record = new CharityRecordUiModel()
                {
                    Charity = result.Charity,
                    Currency = (float)result.Currency,
                    Description = result.Description,
                    id = result.Id,
                    PlayItFwd = result.PlayItForward,
                    Title = result.Title,
                    UserId = result.UserId,                   
                    FileDetails=files                 
                };
                

                return record;
            }
           
        }
    }
}
