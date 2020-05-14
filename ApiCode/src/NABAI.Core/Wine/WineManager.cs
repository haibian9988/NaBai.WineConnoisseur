using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Microsoft.EntityFrameworkCore;

namespace NABAI.Wines
{
    public class WineManager : IWineManager
    {

        private readonly IRepository<Wine> _wineRepository;

        public WineManager(
            IRepository<Wine> wineRepository)
        {
            _wineRepository = wineRepository;
           
        }

        public async Task<Wine> GetAsync(int id)
        {
            var @event = await _wineRepository.FirstOrDefaultAsync(id);
            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the wine, maybe it's deleted!");
            }

            return @event;
        }
       
    }
}
