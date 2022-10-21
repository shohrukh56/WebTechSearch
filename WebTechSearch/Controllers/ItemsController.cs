using WebTechSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebTechSearch.Controllers
{
    public class WebTechSearchController : ApiController
    {
        public IEnumerable<itemsEntities> Get()
        {
            using (ItemsDBContext dbContext = new ItemsDBContext())
            {
                return dbContext.Employees.ToList();
            }
        }
        public Item Get(int id)
        {
            using (ItemDBContext dbContext = new ItemDBContext())
            {
                return dbContext..FirstOrDefault(e => e.ID == id);
            }
        }
    }
}