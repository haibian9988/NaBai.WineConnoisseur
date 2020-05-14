using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NABAI.Wines;
namespace NABAI.Wines.Dto
{
    [AutoMapFrom(typeof(Wine))]
    public class WineDto : FullAuditedEntityDto<int>
    {
        public string Country { get; set; }
        
        public string Province { get; set; }

        public string Region_1 { get; set; }
       
        public string Region_2 { get; set; }

        public string Description { get; set; }
      
        public string Designation { get; set; }

        public int Points { get; set; }

        public decimal Price { get; set; }

        public string Taster_name { get; set; }
      
        public string Taster_twitter_handle { get; set; }
        
        public string Title { get; set; }

       
        public string Variety { get; set; }

        public string Winery { get; set; }
       
    }
}
