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

        public Repository()
        {
            this._TipoDeUsuarioRepository = new TipoDeUsuarioRepository();
        }


        public TipoDeUsuarioRepository GetTipoDeUsuarioRepository()
        {
            return this._TipoDeUsuarioRepository;
        }
    }
}
