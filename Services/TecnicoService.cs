using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TecnicosRegistros.DAL;
using TecnicosRegistros.Models;

namespace TecnicosRegistros.Services;
public class TecnicoService
{
    private readonly Contexto _contexto;
    public TecnicoService(Contexto contexto)
    {
        _contexto = contexto;
    }
    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Add(tecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        _contexto.Update(tecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int tecnicoId)
    {
        return await _contexto.Tecnicos
            .AnyAsync(t => t.TecnicoId == tecnicoId);
    }
    public async Task<bool> Existe(int tecnicoId, string? nombres)
    {
        return await _contexto.Tecnicos
            .AnyAsync(t => t.TecnicoId != tecnicoId && t.Nombres.Equals(nombres));
    }
    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await Existe(tecnico.TecnicoId))
            return await Insertar(tecnico);
        else
            return await Modificar(tecnico);
    }
    public async Task<bool> Eliminar(Tecnicos tecnico)
    {
        var cantidad = await _contexto.Tecnicos
            .Where(t => t.TecnicoId == tecnico.TecnicoId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<Tecnicos?> Buscar(int tecnicoId)
    {
        return await _contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t =>t.TecnicoId == tecnicoId);
    }
    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        return await _contexto.Tecnicos
            .Include(t => t.TiposTecnicos)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}