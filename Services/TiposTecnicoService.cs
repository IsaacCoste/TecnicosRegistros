using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TecnicosRegistros.DAL;
using TecnicosRegistros.Models;

namespace TecnicosRegistros.Services;
    public class TiposTecnicoService
    {
    private readonly Contexto _contexto;
    public TiposTecnicoService(Contexto contexto)
    {
        _contexto = contexto;
    }
    private async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        _contexto.TiposTecnicos.Add(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
        _contexto.Update(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int tipoId)
    {
        return await _contexto.TiposTecnicos
            .AnyAsync(t => t.TipoId == tipoId);
    }
    public async Task<bool> Existe(int tipoId, string? Descripcion)
    {
        return await _contexto.TiposTecnicos
            .AnyAsync(t => t.TipoId != tipoId && t.Descripcion.Equals(Descripcion));
    }
    public async Task<bool> Guardar(TiposTecnicos tiposTecnicos)
    {
        if (!await Existe(tiposTecnicos.TipoId))
            return await Insertar(tiposTecnicos);
        else
            return await Modificar(tiposTecnicos);
    }
    public async Task<bool> Eliminar(TiposTecnicos tiposTecnicos)
    {
        var cantidad = await _contexto.TiposTecnicos
            .Where(t => t.TipoId == tiposTecnicos.TipoId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }
    public async Task<TiposTecnicos?> Buscar(int tipoId)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoId == tipoId);
    }
    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}