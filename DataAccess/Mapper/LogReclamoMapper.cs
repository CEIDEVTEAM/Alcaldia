using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class LogReclamoMapper
    {
        public dtoLogReclamo toDto(LogReclamo entity)
        {

            return new dtoLogReclamo
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
        public LogReclamo toEntity(dtoLogReclamo dto)
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
