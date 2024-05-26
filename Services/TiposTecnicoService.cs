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
            .Include(t => t.Tecnicos)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public async Task MontoIncentivos()
    {
        var tiposTecnicos = await _contexto.TiposTecnicos.ToListAsync();

        foreach (var tipo in tiposTecnicos)
        {
            tipo.Incentivo = await CalcularMontoTotalIncentivos(tipo.TipoId);
        }
        await _contexto.SaveChangesAsync();
    }
    public async Task<decimal> CalcularMontoTotalIncentivos(int tipoId)
    {
        var montoTotal = await _contexto.Incentivos
            .Where(i => i.Tecnicos.TipoTecnicoId == tipoId)
            .SumAsync(i => (double)i.Monto);

        return (decimal)montoTotal;
    }
    public async Task<List<TiposTecnicos>> ListarTotal()
    {
        var tiposTecnicos = await _contexto.TiposTecnicos
            .Include(t => t.Tecnicos)
            .ToListAsync();

        foreach (var tipo in tiposTecnicos)
        {
            tipo.Incentivo = await CalcularMontoTotalIncentivos(tipo.TipoId);
        }
        return tiposTecnicos;
    }
}