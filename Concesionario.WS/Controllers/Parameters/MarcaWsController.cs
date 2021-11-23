using Concesionario.WS.Models;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Concesionario.WS.Controllers.Parameters
{
    public class MarcaWsController : ApiController
    {

        private ImplMarcaLogica logica = new ImplMarcaLogica();
        // GET: api/Marca
        public IEnumerable<MarcaDTO> Get()
        {
            var lista = logica.ListarRegistrosReporte();
            return lista;
        }

        // GET: api/Marca/5
        public MarcaDTO Get(int id)
        {
            return logica.BuscarRegistro(id);
        }

        // POST: api/Marca
        public bool Post([FromBody] ModeloMarcaWs modelo)
        {
            MarcaDTO dto = new MarcaDTO()
            {
                Nombre = modelo.Nombre
            };
            return logica.GuardarRegistro(dto);
        }

        // PUT: api/Marca/5
        public bool Put(int id, [FromBody] ModeloMarcaWs modelo)
        {
            MarcaDTO dto = new MarcaDTO()
            {
                Id = id,
                Nombre = modelo.Nombre
            };
            return logica.EditarRegistro(dto);
        }

        // DELETE: api/Marca/5
        public bool Delete(int id)
        {
            return logica.EliminarRegistro(id);
        }
    }
}
