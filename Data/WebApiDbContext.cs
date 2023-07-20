using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApiDemo.Data
{
public class WebApiDbContext : DbContext
    {
        
     public WebApiDbContext (DbContextOptions<WebApiDbContext> options)
     :base(options)
     {

     }
      
      public DbSet<WebApis>WebApis {get;set;}
       


    }
}