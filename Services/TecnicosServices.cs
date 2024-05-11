using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TecnicosRegistros.DAL;
using TecnicosRegistros.Models;

namespace TecnicosRegistros.Services
{
    public class TecnicosServices
    {
        private readonly Contexto _contexto;
        public TecnicosServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        private async Task<bool> Insertar(Tecnicos Tecnicos)
        {
            _contexto.Tecnicos.Add(Tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Tecnicos Tecnicos)
        {
            _contexto.Update(Tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Existe(int TecnicoId)
        {
            return await _contexto.Tecnicos
                .AnyAsync(a => a.TecnicoId == TecnicoId);
        }
        public async Task<bool> Guardar(Tecnicos Tecnicos)
        {
            if (!await Existe(Tecnicos.TecnicoId))
                return await Insertar(Tecnicos);
            else
                return await Modificar(Tecnicos);
        }
        public async Task<bool> Eliminar(Tecnicos Tecnicos)
        {
            var cantidad = await _contexto.Tecnicos
                .Where(a => a.TecnicoId == Tecnicos.TecnicoId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }
        public async Task<Tecnicos?> Buscar(int MetaId)
        {
            return await _contexto.Tecnicos
                .Where(a => a.TecnicoId == MetaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await _contexto.Tecnicos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
