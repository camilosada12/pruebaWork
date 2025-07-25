using Data.Interfaces;
using Data.Services;
using Entity.Context;
using Entity.DTOs;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

public class UserRepository : BaseModelData<User, UserDto>
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context, AutoMapper.IMapper mapper)
        : base(context, null!, mapper) // IConfiguration no se usa aquí
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return await _context.Users
            .Where(u => EF.Property<bool>(u, "isdeleted") == false)
            .Select(u => new UserDto
            {
                Id = u.id,
                UserName = u.username,
                Password = u.password,
            })
            .ToListAsync();
    }

    public async Task<List<string>> GetPermissionsByUserId(int userId)
    {
        var userRoleIds = await _context.RolUsers
            .Where(ru => ru.userid == userId && !ru.active)
            .Select(ru => ru.rolid)
            .ToListAsync();

        var permissions = await _context.RolFormPermissions
            .Where(rfp => userRoleIds.Contains(rfp.rolid) )
            .Include(rfp => rfp.Permission)
            .Select(rfp => rfp.Permission.name)
            .Distinct()
            .ToListAsync();

        return permissions;
    }

    public async Task<User> validacionUser(LoginRequestDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.username == dto.UserName &&
            u.password == dto.Password);

        return user ?? throw new UnauthorizedAccessException("credenciales incorrectas");
    }


}
