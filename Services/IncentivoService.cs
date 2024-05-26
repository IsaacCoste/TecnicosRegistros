using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TecnicosRegistros.DAL;
using TecnicosRegistros.Models;

namespace TecnicosRegistros.Services;
public class IncentivoService
{
    private readonly Contexto _contexto;
    public IncentivoService(Contexto contexto)
    {
        _contexto = contexto;
    }
    private async Task<bool> Insertar(Incentivos incentivo)
    {
        _contexto.Incentivos.Add(incentivo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Incentivos incentivo)
    {
        _contexto.Update(incentivo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int incentivoId)
    {
        return await _contexto.Incentivos
            .AnyAsync(t => t.IncentivoId == incentivoId);
    }
    public async Task<bool> Existe(int incentivoId, string? descripcion)
    {
        return await _contexto.Incentivos
            .AnyAsync(t => t.IncentivoId != incentivoId && t.Descripcion.Equals(descripcion));
    }
    public async Task<bool> Guardar(Incentivos incentivo)
    {
        if (!await Existe(incentivo.TecnicoId))
            return await Insertar(incentivo);
        else
            return await Modificar(incentivo);
    }
    public async Task<bool> Eliminar(Incentivos incentivo)
    {
        var cantidad = await _contexto.Incentivos
            .Where(t => t.IncentivoId == incentivo.IncentivoId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Incentivos?> Buscar(int incentivoId)
    {
        return await _contexto.Incentivos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.IncentivoId == incentivoId);
    }
    public async Task<List<Incentivos>> Listar(Expression<Func<Incentivos, bool>> criterio)
    {
        return await _contexto.Incentivos
            .Include(t => t.Tecnicos)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}