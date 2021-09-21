using AccesoDeDatos.ModeloDeDatos;
using Concesionario.GUI.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concesionario.GUI.Mapeadores.Parametros
{
    public class MapeadorMarcaGUI : MapeadorBaseGUI<tb_marca, ModeloMarcaGUI>
    {
        public override ModeloMarcaGUI MapearTipo1Tipo2(tb_marca entrada)
        {
            return new ModeloMarcaGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        public override IEnumerable<ModeloMarcaGUI> MapearTipo1Tipo2(IEnumerable<tb_marca> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_marca MapearTipo2Tipo1(ModeloMarcaGUI entrada)
        {
            return new tb_marca()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };
        }

        public override IEnumerable<tb_marca> MapearTipo2Tipo1(IEnumerable<ModeloMarcaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}