using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRUDBasico.API.ViewModels;
using CRUDBasico.Data.Context;
using CRUDBasico.Domain.Interfaces.Service;
using CRUDBasico.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDBasico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper)
        {
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        // GET: api/Funcionario
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<IEnumerable<FuncionarioViewModel>>> Get()
        {
            var funcionarios = await _funcionarioService.GetAll();
            var funcionariosViewModel = _mapper.Map<IEnumerable<FuncionarioViewModel>>(funcionarios);

            if (funcionariosViewModel.Count() == 0)
                return NotFound();

            return Ok(funcionariosViewModel);
        }

        //GET: api/Funcionario/5
        [HttpGet("{id:int}", Name = "Get")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<FuncionarioViewModel>> Get(int id)
        {
            var funcionario = await _funcionarioService.Get(id);
            var funcionarioViewModel = _mapper.Map<FuncionarioViewModel>(funcionario);

            if (funcionarioViewModel == null)
                return NotFound();

            return Ok(funcionarioViewModel);
        }

        // POST: api/Funcionario
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<FuncionarioViewModel>> Post(FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var funcionario = _mapper.Map<Funcionario>(funcionarioViewModel);
            await _funcionarioService.Post(funcionario);

            return CreatedAtAction(nameof(Post), funcionario);
        }

        // PUT: api/Funcionario/5
        [HttpPut("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult<FuncionarioViewModel>> Put(int id, FuncionarioViewModel funcionarioViewModel)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            if (id != funcionarioViewModel.Id)
                return BadRequest();

            var funcionario = _mapper.Map<Funcionario>(funcionarioViewModel);
            await _funcionarioService.Put(funcionario);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<FuncionarioViewModel>> Delete(int id)
        {
            var funcionario = await _funcionarioService.Get(id);
            if (funcionario == null)
                return NotFound();

            await _funcionarioService.Delete(funcionario);
            return Ok();
        }
    }
}
