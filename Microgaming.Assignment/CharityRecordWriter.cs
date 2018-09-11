using Microgaming.UiModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microgaming.Assignment
{
    public class CharityRecordWriter
    {
        public void Write(CharityRecordUiModel record)
        {
            try
            {
                using (CharityEntities entities = new CharityEntities())
                {
                    CharityRecord charityRecord = new CharityRecord();

                    charityRecord.Title = record.Title;
                    charityRecord.Description = record.Description;
                    charityRecord.Charity = record.Charity;
                    charityRecord.PlayItForward = record.PlayItFwd;
                    charityRecord.UserId = record.UserId;
                    charityRecord.Currency = record.Currency;
                    charityRecord.Status = 0;

                    foreach (var item in record.FileDetails)
                    {
                        FileDetail detailsobj = new FileDetail();
                        detailsobj.FileInfo = item.FileInfo;
                        detailsobj.FileName = item.FileName;
                        detailsobj.CharityId = charityRecord.Id;
                        entities.FileDetails.Add(detailsobj);
                    }

                    entities.CharityRecords.Add(charityRecord);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public void Update(CharityRecordUiModel model)
        {
            try
            {
                using (CharityEntities entities = new CharityEntities())
                {
                    CharityRecord charityRecord = new CharityRecord();
                    var record = entities.CharityRecords.Where(x => x.Id == model.id).FirstOrDefault();

                    record.Title = model.Title;
                    record.Description = model.Description;
                    record.Charity = model.Charity;
                    record.PlayItForward = model.PlayItFwd;
                    record.UserId = model.UserId;
                    record.Currency = model.Currency;
                    foreach (var files in record.FileDetails)
                    {
                        record.FileDetails.Remove(files);

                    }
                    foreach (var item in model.FileDetails)
                    {

                        FileDetail detailsobj = new FileDetail();
                        detailsobj.FileInfo = item.FileInfo;
                        detailsobj.FileName = item.FileName;
                        detailsobj.CharityId = item.CharityId;
                        entities.FileDetails.Add(detailsobj);
                    }
                     
                    entities.SaveChanges();
                }
            }
            catch 
            {
                throw;
            }
        }

        public void ApproveCharity(int trid)
        {
            using (CharityEntities entities = new CharityEntities())
            {
                var result = entities.CharityRecords.Where(x => x.Id == trid).FirstOrDefault();
                result.Status = 1;
                entities.SaveChanges();
            }
        }
        public void DeleteRecord(int trid)
        {
            try
            {
                using (CharityEntities entities = new CharityEntities())
                {
                    var result = entities.CharityRecords.Where(x => x.Id == trid).Include(x => x.FileDetails).
                   FirstOrDefault();
                    entities.FileDetails.RemoveRange(result.FileDetails);
                    entities.CharityRecords.Remove(result);
                    entities.SaveChanges();
                }
            }
            catch
            {
                throw;
            }

        }
    }
    }

