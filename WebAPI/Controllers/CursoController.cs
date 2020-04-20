using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Aplicacion.Cursos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Curso>>> GetCursos()
        {
            return await _mediator.Send(new Consulta.ListaCursos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCursoById(int id)
        {
            return await _mediator.Send(new ConsultaId.CursoId{ Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> SaveCourse(Nuevo.Ejecutar data)
        {
            return await _mediator.Send(data);
        }
    }
}