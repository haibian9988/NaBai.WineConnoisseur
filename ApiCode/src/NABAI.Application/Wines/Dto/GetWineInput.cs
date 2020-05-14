
using NABAI.Dto;
using Abp.Runtime.Validation;
namespace NABAI.Wines.Dto
{
    public class GetWineListInput: PagedAndSortedInputDto, IShouldNormalize
    {
        public string Variety { get; set; }

        public string KeyWord { get; set; }

        public decimal PriceStart { get; set; }
        public decimal PriceEnd { get; set; }

        public void Normalize()
        {

        }
    }
}
