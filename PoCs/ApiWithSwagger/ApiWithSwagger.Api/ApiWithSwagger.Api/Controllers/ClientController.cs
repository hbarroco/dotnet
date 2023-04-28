using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithSwagger.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithSwagger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// Consulta todos os Clientes.
        /// </summary>        
        /// <returns>Retorna uma lista do Objeto Cliente</returns>
        // GET: api/Client
        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> Get()
        {
            var clients = new List<ClientDto>();
            clients.Add(new ClientDto { Id = "1", Name = "Cliente 1" });
            clients.Add(new ClientDto { Id = "2", Name = "Cliente 2" });
            clients.Add(new ClientDto { Id = "3", Name = "Cliente 3" });
            return Ok(clients);
        }


        /// <summary>
        /// Consulta clientes pelo seu Id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Retorna o Objeto CLiente</returns>
        // GET: api/Client/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ClientDto> Get(int id)
        {
            var client = new ClientDto { Id = "1", Name = "Cliente 1" };
            return Ok(client);
        }

        /// <summary>
        /// Realiza o insert de um novo cliente
        /// </summary>
        /// <param name="dto">objeto cliente</param>
        /// <returns>Retorna o Objeto Cliente que foi criado</returns>
        [HttpPost]
        public ActionResult<ClientDto> Post(ClientDto dto)
        {
            var client = new ClientDto { Id = "1", Name = "Cliente 1" };
            return Ok(client);
        }
        
        /// <summary>
        /// Realiza o update de um cliente
        /// </summary>
        /// <param name="id">Id do cliente a ser alterado</param>
        /// <param name="value">objeto cliente a ser alterado</param>
        /// <returns>Retorna o Objeto Cliente que foi Alterado</returns>
        // PUT: api/Client/5
        [HttpPut("{id}")]
        public ActionResult<ClientDto> Put(int id, ClientDto value)
        {
            var client = new ClientDto { Id = "1", Name = "Cliente 1" };
            return Ok(client);
        }

        /// <summary>
        /// Realiza o delete de um cliente
        /// </summary>
        /// <param name="id">Id do cliente a ser deletado</param>        
        /// <returns>Retorna o código 200</returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<ClientDto> Delete(int id)
        {            
            return Ok();
        }
    }
}
