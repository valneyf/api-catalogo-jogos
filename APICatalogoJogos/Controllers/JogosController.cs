﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogoJogos.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Obter()
        {
            return Ok();
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<object>> Obter(Guid idJogo)
        {
            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult<object>> InserirJogo(object jogo)
        {
            return Ok();
        }

        // Atualiza todo o recurso
        [HttpPut("{idJogo:guid}")] 
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, object jogo)
        {
            return Ok();
        }

        // Atualiza parte especifica do recurso
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            return Ok();
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }


    }
}
