using AutoMapper;
using Common;
using Data.Contracts.Catalogs.CatalogTypes;
using Data.DTOs;
using Data.DTOs.Catalogs.CatalogTypes;
using Entities.Catalogs;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Catalogs
{
    public class CatalogTypeRepository : ICatalogTypeRepository,IScopedDependency
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public CatalogTypeRepository(ApplicationDbContext context, IMapper mapper = null)
        {
            _context = context;
            this.mapper = mapper;
        }

        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var model = mapper.Map<CatalogType>(catalogType);
            _context.CatalogTypes.Add(model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>
               (
               true,
               new List<string> { $"تایپ {model.Type}  با موفقیت در سیستم ثبت شد" },
                mapper.Map<CatalogTypeDto>(model)
             );
        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var model = _context.CatalogTypes.SingleOrDefault(p => p.Id == catalogType.Id);
            mapper.Map(catalogType, model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>
              (
               true,
                new List<string> { $"تایپ {model.Type} با موفقیت ویرایش شد" },

                mapper.Map<CatalogTypeDto>(model)
              );
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            var data = _context.CatalogTypes.Find(Id);
            var result = mapper.Map<CatalogTypeDto>(data);

            return new BaseDto<CatalogTypeDto>(
                true,
                null,
                result
                );
        }

        public PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
        {
            int totalCount = 0;
            var model = _context.CatalogTypes
                .Where(p => p.ParentCatalogTypeId == parentId)
                .PagedResult(page, pageSize, out totalCount);
            var result = mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PaginatedItemsDto<CatalogTypeListDto>(page, pageSize, totalCount, result);
        }

        public BaseDto Remove(int Id)
        {
            var catalogType = _context.CatalogTypes.Find(Id);
            _context.CatalogTypes.Remove(catalogType);
            _context.SaveChanges();
            return new BaseDto
            (
             true,
             new List<string> { $"ایتم با موفقیت حذف شد" }
             );
        }
    }
}
