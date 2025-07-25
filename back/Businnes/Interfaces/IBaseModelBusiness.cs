using System.Dynamic;
using Business.Enums;
using Entity.DTOs;
using Entity.Model;

public interface IBaseModelBusiness<T, D> where T : BaseModel where D : BaseDto
{
    Task<List<D>> GetAllAsync();
    /// <summary>
    /// Obtener por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    Task<D> CreateAsync(D entityDto);
    /// <summary>
    /// Guardar Detalles
    /// </summary>
    /// <param name="details"></param>
    /// <returns></returns>
    Task UpdateAsync(D entityDto);

    /// <summary>
    /// Actualizar Detalles
    /// </summary>
    /// <param name="details"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(int id, DeleteMode mode);



}
