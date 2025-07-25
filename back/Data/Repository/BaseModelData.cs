using AutoMapper;
using Data.Repository;
using Entity.Context;
using Entity.DTOs;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BaseModelData<T, D> : ABaseModelData<T, D> where T : BaseModel where D : BaseDto
{
    protected readonly ApplicationDbContext _context;
    protected readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public BaseModelData(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
    {
        _context = context;
        _configuration = configuration;
        _mapper = mapper;
    }

    public override async Task<IEnumerable<D>> GetAllAsync()
    {
        var lstModel = await _context.Set<T>().Where(e => e.active).ToListAsync();
        var lstDto = new List<D>();
        foreach (var item in lstModel)
        {
            lstDto.Add(_mapper.Map<D>(item));
        }
        return lstDto;
    }

    public override async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


    public override async Task UpdateAsync(T entity)
    {
        var existingEntity = await _context.Set<T>().FindAsync(entity.id);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
        else
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        await _context.SaveChangesAsync();
    }

    public override async Task<int> DeleteAsync(int id)
    {
        return await _context.Set<T>().Where(d => d.id == id).ExecuteDeleteAsync();
    }

    public override async Task<int> DeleteLogicalAsync(int id)
    {
        var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.id == id);
        entity.active = true;
        await UpdateAsync(entity);
        return entity.id;
    }
}
