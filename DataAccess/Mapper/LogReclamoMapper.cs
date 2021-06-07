using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class LogReclamoMapper
    {
        public DtoLogReclamo MapToDto(LogReclamo entity)
        {

            return new DtoLogReclamo
            {
                idLog = entity.idLog,
                estadoLog = entity.estadoLog,
                fechaYhoraLog = entity.fechaYhoraLog,
                observacionesCuadrilla = entity.observacionesCuadrilla,
                comentarioLog = entity.comentarioLog,
                idReclamo = entity.idReclamo,
                nombreDeUsuario = entity.nombreDeUsuario
            };
        }

        public LogReclamo MapToEntity(DtoLogReclamo dto)
        {

            return new LogReclamo
            {
                idLog = dto.idLog,
                estadoLog = dto.estadoLog,
                fechaYhoraLog = dto.fechaYhoraLog,
                observacionesCuadrilla = dto.observacionesCuadrilla,
                comentarioLog = dto.comentarioLog,
                idReclamo = dto.idReclamo,
                nombreDeUsuario = dto.nombreDeUsuario
            };
        }
    }
}
