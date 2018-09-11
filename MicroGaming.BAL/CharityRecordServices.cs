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
            return provider.GetRecords(userId);

        }
        

        public void CreateCharityRecord(CharityRecordUiModel model)
        {
            try
            {               
                CharityRecordWriter writer = new CharityRecordWriter();
                writer.Write(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }    
           
        }

        public List<CharityRecordUiModel> GetRecords()
        {
            CharityRecordProvider provider = new CharityRecordProvider();
            return provider.GetRecords();
        }

        public CharityRecordUiModel LoadRecordtoEdit(int trid)
        {
            CharityRecordProvider provider = new CharityRecordProvider();

            return provider.LoadRecordtoEdit(trid);
        }

        public void UpdateCharityRecord(CharityRecordUiModel model)
        {
            try
            {
                CharityRecordWriter writer = new CharityRecordWriter();
                writer.Update(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteCharityRecord(int trid)
        {
            CharityRecordWriter writer = new CharityRecordWriter();
            writer.DeleteRecord(trid);
        }

        public void ApproveCharityRecord(int trid)
        {
            CharityRecordWriter writer = new CharityRecordWriter();
            writer.ApproveCharity(trid);
        }
    }
}
    

