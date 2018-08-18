using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Usuarios;
using System;
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
        public LoginVal() { }
        public LoginVal(UsuarioModel usuario)
        {
            _usuario = ValidateUsuario(usuario);
        }
        private UsuarioModel ValidateUsuario(UsuarioModel usuario)
        {
            usuario.Pass = _converter.Encrypt256(usuario.Pass);
            foreach (var usr in _usrRet.GetAll())
                if (usr.Pass.Equals(usuario.Pass) && usr.Nombre.Equals(usuario.Nombre))
                    return usr;
            return null;
        }
        public string GenerarToken(UsuarioModel usuario)
        {
            string token = null;
            Random rand = new Random();
            _usuario = ValidateUsuario(usuario);
            if (_usuario != null)
            {
                var phrase = _usuario.Id + _usuario.Nombre + rand.Next().ToString();
                token = _converter.Encrypt256(phrase);
            }
            return token;
        }
    }
}
