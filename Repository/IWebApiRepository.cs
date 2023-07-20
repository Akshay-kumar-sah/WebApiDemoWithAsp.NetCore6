using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Repository
{
    public interface IWebApiRepository
    {
        Task<List<WebApiModel>> GetAllWebApi();
        Task<WebApiModel ?> GetWebApiById(int? webApiId);
        Task<int> CreateWebApi(WebApiModel webApiModel);
        Task UpdateWebApi(int webApiId, WebApiModel webApiModel);
        Task DeleteWebApi(int webApiId);
    }
}