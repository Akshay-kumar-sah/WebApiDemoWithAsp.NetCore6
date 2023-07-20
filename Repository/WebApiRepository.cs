using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApiDemo.Data;
using WebApiDemo.Models;

namespace WebApiDemo.Repository
{
    public class WebApiRepository : IWebApiRepository
    {
      
         private readonly WebApiDbContext _context;
      public WebApiRepository (WebApiDbContext context) 
      {
          _context = context;
      }
      
    public async Task<List<WebApiModel>> GetAllWebApi()
    {
        var records = await _context.WebApis.Select(x => new WebApiModel(){
            Id = x.Id,
            FullName = x.FullName,
            Contact = x.Contact
        }).ToListAsync();

        return records;


    }

     public async Task<WebApiModel?> GetWebApiById(int? webApiId)
    {
        var record = await _context.WebApis.Where(x => x.Id == webApiId).Select(x => new WebApiModel(){
            Id = x.Id,
            FullName = x.FullName,
            Contact = x.Contact
        }).FirstOrDefaultAsync();
      
        return record;


    }
     public async Task<int> CreateWebApi(WebApiModel webApiModel)
    {
       
       var record = new WebApis()
       {
        FullName = webApiModel.FullName,
        Contact = webApiModel.Contact
       };
      

      _context.WebApis.Add(record);
     await _context.SaveChangesAsync();
        
        return record.Id;


    }
     public async Task UpdateWebApi(int webApiId, WebApiModel webApiModel)
    {
       
      var webApi = await _context.WebApis.FindAsync(webApiId);

      if(webApi != null)
      {
        webApi.FullName = webApiModel.FullName;
        webApi.Contact = webApiModel.Contact;
        await _context.SaveChangesAsync();
      }


    }

     public async Task DeleteWebApi(int webApiId)
    {
       
      var webApi = new WebApis(){Id = webApiId};
      _context.WebApis.Remove(webApi);
      await _context.SaveChangesAsync();
    


    }


    }
}