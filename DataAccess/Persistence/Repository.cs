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
        private TipoDeReclamoRepository _TipoDeReclamoRepository;
        private UsuarioRepository _UsuarioRepository;
        private ZonaRepository _ZonaRepository;
        private VerticeRepository _VerticeRepository;
        private LogReclamoRepository _LogReclamoRepository;

        public Repository()
        {
            this._TipoDeUsuarioRepository = new TipoDeUsuarioRepository();
            this._CuadrillaRepository = new CuadrillaRepository();
            this._ReclamoRepository = new ReclamoRepository();
            this._TipoDeReclamoRepository = new TipoDeReclamoRepository();
            this._UsuarioRepository = new UsuarioRepository();
            this._ZonaRepository = new ZonaRepository();
            this._VerticeRepository = new VerticeRepository();
            this._LogReclamoRepository = new LogReclamoRepository();
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

        public TipoDeReclamoRepository GetTipoDeReclamoRepository()
        {
            return this._TipoDeReclamoRepository;
        }
        public UsuarioRepository GetUsuarioRepository()
        {
            return this._UsuarioRepository;
        }
        public ZonaRepository GetZonaRepository()
        {
            return this._ZonaRepository;
        }
        public VerticeRepository GetVerticeRepository()
        {
            return this._VerticeRepository;
        }
        public LogReclamoRepository GetLogReclamoRepository()
        {
            return this._LogReclamoRepository;
        }
    }
}
