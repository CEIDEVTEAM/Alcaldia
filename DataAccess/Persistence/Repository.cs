using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class Repository
    {
        private TipoDeUsuarioRepository _TipoDeUsuarioRepository;
        private CuadrillaRepository _CuadrillaRepository;
        private ReclamoRepository _ReclamoRepository;
        private UbicacionRepository _UbicacionRepository;
        private TipoDeReclamoRepository _TipoDeReclamoRepository;

        public Repository()
        {
            this._TipoDeUsuarioRepository = new TipoDeUsuarioRepository();
            this._CuadrillaRepository = new CuadrillaRepository();
            this._ReclamoRepository = new ReclamoRepository();
            this._UbicacionRepository = new UbicacionRepository();
            this._TipoDeReclamoRepository = new TipoDeReclamoRepository();
        }


        public TipoDeUsuarioRepository GetTipoDeUsuarioRepository()
        {
            return this._TipoDeUsuarioRepository;
        }

        public CuadrillaRepository GetCuadrillaRepository()
        {
            return this._CuadrillaRepository;
        }

        public ReclamoRepository GetReclamoRepository()
        {
            return this._ReclamoRepository;
        }

        public UbicacionRepository GetUbicacionRepository()
        {
            return this._UbicacionRepository;
        }

        public TipoDeReclamoRepository GetTipoDeReclamoRepository()
        {
            return this._TipoDeReclamoRepository;
        }
    }
}
