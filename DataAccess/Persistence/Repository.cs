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

        public Repository()
        {
            this._TipoDeUsuarioRepository = new TipoDeUsuarioRepository();
            this._CuadrillaRepository = new CuadrillaRepository();
            this._ReclamoRepository = new ReclamoRepository();
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
    }
}
