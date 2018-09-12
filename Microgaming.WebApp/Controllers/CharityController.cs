using Microgaming.BAL;
using Microgaming.UiModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Microgaming.WebApp.Controllers
{
    [Authorize]
    public class CharityController : ApiController
    {
        [HttpGet]
        [Route("api/Charity/Get")]
        
        public List<CharityRecordUiModel> Get()
        {
            CharityRecordServices obj = new CharityRecordServices();
           if( User.IsInRole("Admin") ==true)
            {
                return obj.GetRecords();
            }
            return obj.GetRecords(User.Identity.GetUserId());
        }
        [HttpPost]
        [Route("api/Charity/CreateCharity")]
        public async Task<HttpResponseMessage> CreateCharity()
        {
            
            var model = GetRecordInfo(HttpContext.Current);
            CharityRecordServices balObj = new CharityRecordServices();
            balObj.CreateCharityRecord(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/Charity/LoadRecordtoEdit")]
        public CharityRecordUiModel LoadRecordtoEdit(int trid)
        {
            CharityRecordServices obj = new CharityRecordServices();
            return obj.LoadRecordtoEdit(trid);
        }
        [HttpPost]
        [Route("api/Charity/UpdateCharity")]
        public async Task<HttpResponseMessage> UpdateCharity()
        {
           
            var model=GetRecordInfo(HttpContext.Current);
            CharityRecordServices balObj = new CharityRecordServices();            
            balObj.UpdateCharityRecord(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private CharityRecordUiModel GetRecordInfo(HttpContext httpContext)
        {
            CharityRecordUiModel model = new CharityRecordUiModel();
            try
            {
                model.Title = httpContext.Request.Params["Title"];
                model.Description = httpContext.Request.Params["Description"];
                model.Charity = httpContext.Request.Params["Charity"];
               
                var b = httpContext.Request.Params["Id"];
                if (httpContext.Request.Params["Id"] != "")
                {
                    model.id = Convert.ToInt64(httpContext.Request.Params["Id"]);
                }
                model.UserId = User.Identity.GetUserId();
                model.Currency = float.Parse(httpContext.Request.Params["Amount"], CultureInfo.InvariantCulture.NumberFormat);
                model.PlayItFwd = bool.Parse(httpContext.Request.Params["PlayItFwd"]);
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                    if (httpPostedFile != null)
                    {
                        var type = httpPostedFile.ContentType;
                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(httpPostedFile.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(httpPostedFile.ContentLength);
                            FileDetailsUiModel fileobj = new FileDetailsUiModel();
                            fileobj.FileInfo = fileData;
                            fileobj.FileName = httpPostedFile.FileName;
                            try
                            {
                                model.FileDetails.Add(fileobj);
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        if (type != "application/pdf")
                        {
                            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return model;

        }

        [HttpGet]
        [Route("api/Charity/DeleteRecord")]
        public bool DeleteRecord(int trid)
        {
            CharityRecordServices obj = new CharityRecordServices();
            obj.DeleteCharityRecord(trid);
            return true;
        }

        [HttpGet]
        [Route("api/Charity/ApproveCharity")]
        public bool ApproveCharity(int id)
        {
            CharityRecordServices obj = new CharityRecordServices();
            obj.ApproveCharityRecord(id);
            return true;
        }
    }
}
