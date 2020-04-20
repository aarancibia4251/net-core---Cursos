using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoId : IRequest<Curso>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<CursoId, Curso>
        {
            private readonly CursosonlineContext _cursosOnlineContext;
            public Manejador(CursosonlineContext context)
            {
                _cursosOnlineContext = context;
            }
            public async Task<Curso> Handle(CursoId request, CancellationToken cancellationToken)
            {
                return await _cursosOnlineContext.Curso.FindAsync(request.Id);
            }
        }
    }
}
