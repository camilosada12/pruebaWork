using AutoMapper;
using Data.Repository;
using Entity.Context;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class RolFormPermissionRepository : BaseModelData<RolFormPermissions, RolFormPermissionDto>
    {
        private readonly ApplicationDbContext _context;

        public RolFormPermissionRepository(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
            : base(context, configuration, mapper)
        {
            _context = context;
        }

        public async Task<IEnumerable<RolFormPermissionDto>> GetAllJoinAsync()
        {
            return await _context.RolFormPermissions
                .Include(x => x.Rol)
                .Include(x => x.Form)
                .Include(x => x.Permission)
                .Select(rfp => new RolFormPermissionDto
                {
                    Id = rfp.id,
                    RolId = rfp.rolid,
                    FormId = rfp.formid,
                    Permissionid = rfp.permissionid,
                })
                .ToListAsync();
        }
    }
}