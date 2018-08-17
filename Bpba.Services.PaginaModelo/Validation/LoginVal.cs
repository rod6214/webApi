using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Usuarios;
using Util.Converters;

namespace Bpba.Services.PaginaModelo.Validation
{
    public class LoginVal
    {
        private UsuarioModel _usuario;
        private UsuarioRetriever _usrRet = new UsuarioRetriever();
        private Converter _converter = new Converter();
            
        public UsuarioModel ValidUser => _usuario;
        public bool IsValid => ValidUser != null;
        public LoginVal(UsuarioModel usuario)
        {
            usuario.Pass = _converter.Encrypt256(usuario.Pass);
            foreach(var usr in _usrRet.GetAll())
                if(usr.Pass.Equals(usuario.Pass) && usr.Nombre.Equals(usuario.Nombre))
                {
                    _usuario = usr;
                    break;
                }
        }
    }
}
