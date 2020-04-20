using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListaCursos : IRequest<List<Curso>> { }
        public class Manejador : IRequestHandler<ListaCursos, List<Curso>>
        {
            private readonly CursosonlineContext _cursosonlineContext;
            public Manejador(CursosonlineContext cursosOnlineContext)
            {
                _cursosonlineContext = cursosOnlineContext;
            }
            public async Task<List<Curso>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                return await this._cursosonlineContext.Curso.ToListAsync();
            }
        }
    }
}
