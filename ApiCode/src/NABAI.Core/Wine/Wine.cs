using System;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace NABAI.Wines
{
    [Table("Wines")]
    public class Wine : Entity, IHasCreationTime
    {
        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string Province { get; set; }

        [StringLength(100)]
        public string Region_1 { get; set; }
        [StringLength(100)]
        public string Region_2 { get; set; }
      
        public string Description { get; set; }
        [StringLength(100)]
        public string Designation { get; set; }
        
        public int Points { get; set; }

        public decimal Price { get; set; }

        [StringLength(100)]
        public string Taster_name { get; set; }
        [StringLength(100)]
        public string Taster_twitter_handle { get; set; }
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Variety { get; set; }

        [StringLength(100)]
        public string Winery { get; set; }
        public DateTime CreationTime { get; set; }

  
    }
}
