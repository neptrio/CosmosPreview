using CosmosPreview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosPreview
{
    class CatService: BaseService<Cat>
    {
        public CatService(SchroedingerContext context) : base(context)
        {

        }

        public Task<Cat> GetCatById(int id)
        {
            return Repository.SingleAsync(b => b.CatId == id);
        }

        public Task<Cat> GetCatByName(string name)
        {
            return Repository.SingleAsync(b => b.Name == name);
        }



    }
}
