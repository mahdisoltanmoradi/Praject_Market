using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Data.Contracts;
using Entities.Common;

namespace infrastructure.WebFramework.CrudRefrences
{
    public class CrudController<TDto, TEntity, TKey> : Controller where TDto : class where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> Repository;

        protected readonly IMapper Mapper;
        public CrudController(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult> Index()
        {
            var model = await Repository.TableNoTracking.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public virtual ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(TDto dto, CancellationToken cancellationToken)
        {
            var model = Mapper.Map<TDto, TEntity>(dto);
            await Repository.AddAsync(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public virtual async Task<ActionResult> Edit(TKey id, CancellationToken cancellationToken)
        {
            var model = await Repository.GetByIdAsync(cancellationToken, id);
            var projected = Mapper.Map<TEntity, TDto>(model);
            return View(projected);
        }
        [HttpPost]
        public virtual async Task<ActionResult> Edit(TDto dto, CancellationToken cancellationToken)
        {
            var model = Mapper.Map<TDto, TEntity>(dto);

            if (!ModelState.IsValid) return View(dto);
            await Repository.UpdateAsync(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        public virtual async Task<ActionResult> Delete(TKey id, CancellationToken cancellationToken)
        {
            var model = await Repository.GetByIdAsync(cancellationToken, id);
            await Repository.DeleteAsync(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }

    public class CrudController<TEntity, TKey> : CrudController<TEntity, TEntity, TKey> where TEntity : class, IEntity
    {
        public CrudController(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
