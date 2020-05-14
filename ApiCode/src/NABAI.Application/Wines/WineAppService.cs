using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using NABAI.Authorization;
using Abp;
using NABAI.Wines.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;

namespace NABAI.Wines
{
    //[AbpAuthorize]
    public class WineAppService :  IWineAppService
    {
        private readonly IWineManager _wineManager;
        private readonly IRepository<Wine> _wineRepository;

        public WineAppService(
            IWineManager wineManager,
            IRepository<Wine> wineRepository)
        {
            _wineManager = wineManager;
            _wineRepository = wineRepository;
        }


        public async Task<WineDto> Get(GetWineInput input)
        {
            var wine = await _wineRepository.GetAll().Where(x => x.Id == input.Id).FirstOrDefaultAsync();

            return wine.MapTo<WineDto>();
        }

        public async Task<PagedResultDto<WineListDto>> GetAll(GetWineListInput input)
        {

            var query = _wineRepository.GetAll();
            if (input.Variety != null)
            {
                query = query.Where(x => x.Variety == input.Variety);
            }
            if (!input.KeyWord.IsNullOrEmpty())
            {
                query = query.Where(x => x.Country.Contains(input.KeyWord) ||x.Province.Contains(input.KeyWord) || x.Region_1.Contains(input.KeyWord) || x.Region_2.Contains(input.KeyWord));
            }
            if (input.PriceStart != 0)
            {
                query = query.Where(x=>x.Price>=input.PriceStart);
            }

            if (input.PriceEnd != 0)
            {
                query = query.Where(x => x.Price <= input.PriceStart);
            }

            
            var resultCount = await query.CountAsync();
            var wines =  query .OrderByDescending(e => e.CreationTime)
                                 .PageBy(input)
                                 .ToList();

            var res = new PagedResultDto<WineListDto>(resultCount, wines.MapTo<List<WineListDto>>());
            foreach (var item in res.Items)
            {
                item.Producer = item.Country+" "+item.Province;
                if (!item.Region_1.IsNullOrEmpty())
                {
                    item.Producer += " " + item.Region_1;
                }

                if (!item.Region_2.IsNullOrEmpty())
                {
                    item.Producer += " " + item.Region_2;
                }
            }
            return res;
        }


    }
}

