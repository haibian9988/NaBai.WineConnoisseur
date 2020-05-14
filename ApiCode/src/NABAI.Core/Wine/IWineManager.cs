using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace NABAI.Wines
{
    public interface IWineManager: IDomainService
    {
        Task<Wine> GetAsync(int id);
       
    }
}