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
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CharityRecord, CharityRecordUiModel>();
        }
    }
}
