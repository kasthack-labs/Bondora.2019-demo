using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bondora.homeAssignment.Data;
using bondora.homeAssignment.Core.Services.Contracts;
using System.Linq;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using bondora.homeAssignment.Models.DTO;

namespace bondora.homeAssignment.Core.Services.Impl
{

    public class CategoryService : ICategoryService
    {
        private readonly DemoAppContext context;
        private readonly IConfigurationProvider mapperConfiguration;

        public CategoryService(DemoAppContext context, IConfigurationProvider mapperConfiguration)
        {
            this.context = context;
            this.mapperConfiguration = mapperConfiguration;
        }

        public async Task<CategoryContract> Get(long id) => await this.context.ProductCategories.Where(a => a.Id == id).ProjectTo<CategoryContract>(this.mapperConfiguration).FirstOrDefaultAsync();

        public async Task<IEnumerable<CategoryContract>> List(int page) => await this.context.ProductCategories.ProjectTo<CategoryContract>(this.mapperConfiguration).ToListAsync();
    }
}
