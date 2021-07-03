using BussinessLogic.Logic;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TipoDeUsuarioController test = new TipoDeUsuarioController();
            DtoTipoUsuario dto = new DtoTipoUsuario();

            dto.tipo = "Funcionario";
            dto.descripcion = "Usuarios del sitio web de para funcionarios de la Alcaldía";

            test.AddUserType(dto);*/

            LZonaController test = new LZonaController();
            List<DtoZona> zonas = new List<DtoZona>();
            zonas = test.GetAllZonas();

            foreach (DtoZona item in zonas)
            {
                Console.WriteLine(item.nombre);
                Console.WriteLine(item.color);
                List<DtoVertice> vert = item.colVertices;
                foreach (DtoVertice i in vert)
                {
                    Console.WriteLine(i.latitud);
                    Console.WriteLine(i.longitud);
                }
                
              
            }

            Console.ReadKey();

            /////*4556465464654654
        }
    }
}
