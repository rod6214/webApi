using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Articulos;
using Bpba.Models.PaginaModelo.Inaventarios;
using Bpba.Models.PaginaModelo.Perfiles;
using Bpba.Models.PaginaModelo.Personas;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Models.PaginaModelo.Usuarios;
using Bpba.Models.PaginaModelo.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace Bpba.Services.PaginaModelo.Validation
{
    public class UsuariosVal
    {
        private UsuarioRetriever _usrRet = new UsuarioRetriever();
        private PerfilRetriever _perfRet = new PerfilRetriever();
        private PersonaRetriever _perRet = new PersonaRetriever();
        private InventarioRetriever _invRet = new InventarioRetriever();
        private ArticuloRetriever _artRet = new ArticuloRetriever();
        private VentaRetriever _ventRet = new VentaRetriever();
        private SesionVal _sesion;
        private Permisos _permisos;
        private UsuarioModel _usuario;
        public UsuariosVal(CookieModel cookie)
        {
            _sesion = new SesionVal(cookie);
            _usuario = _sesion.GetUsuario();
            _permisos = new Permisos(cookie);
        }
        public IEnumerable<UsuarioModel> GetUsuarios(AccountAccess access)
        {
            List<UsuarioModel> lstUsr = new List<UsuarioModel>();
            foreach (var usr in _usrRet.GetAll())
                lstUsr.Add(usr); 
            if (_permisos.IsValidAll(access))
                return lstUsr;
            return null;
        }
        public bool RegisterUsuario(UsuarioRegisterModel usuarioRegister, AccountAccess perfil, string descripcionPerfil, AccountAccess access)
        {
            if (_permisos.IsValidAll(access))
            {
                PersonaModel persona = new PersonaModel
                {
                    Id = -1,
                    Nombre = "",
                    Apellido = "",
                    Correo = "",
                    Direccion = "",
                    Pais = Country.UNDEFINED,
                    Telefono = "",
                };
                if(usuarioRegister.Persona != null)
                    persona = _perRet.Register(usuarioRegister.Persona);
                else
                    persona = _perRet.Register(persona);
                if(usuarioRegister.Usuario != null)
                {
                    usuarioRegister.Usuario.Persona_id = persona.Id;
                    usuarioRegister.Usuario = _usrRet.Register(usuarioRegister.Usuario);
                    var perfilM = new PerfilModel
                    {
                        Id = 0,
                        Acceso = perfil,
                        Descripcion = descripcionPerfil,
                        Usuario_id = usuarioRegister.Usuario.Id
                    };
                    _perfRet.Register(perfilM);
                    return true;
                }
            }
            return false;
        }
        public bool RegisterUsuario(UsuarioRegisterModel usuarioRegister, AccountAccess access)
        {
            return RegisterUsuario(usuarioRegister, AccountAccess.USER, "Usuario con acceso limitado.", access);
        }
        public bool UpdateUsuario(UsuarioModel usuario, AccountAccess access)
        {
            if (_permisos.IsValidAll(access))
            {
                _usrRet.Update(usuario);
                return true;
            }
            return false;
        }
        public bool DeleteUsuario(int id, AccountAccess access)
        {
            if (_permisos.IsValidAll(access))
            {
                _usrRet.Delete(id);
                return true;
            }
            return false;
        }
        public bool SetPerfil(PerfilModel perfil, AccountAccess acces)
        {
            if (_permisos.IsValidAll(acces))
            {
                foreach (var perf in _perfRet.GetAll())
                    if (perf.Usuario_id == perfil.Usuario_id)
                    {
                        _perfRet.Register(perfil);
                        return true;
                    }
                _perfRet.Update(perfil);
                return true;
            }
            return false;
        }
        public bool SetDatosPersonales(PersonaModel persona, AccountAccess access)
        {
            if (_permisos.IsValidAll(access))
            {
                persona.Id = _usuario.Persona_id;
                _perRet.Update(persona);
                return true;
            }
            return false;
        }
        public bool GetUserArticulos(AccountAccess acces, out IEnumerable<ArticuloModel> articulos)
        {
            articulos = null;
            if (_permisos.IsValidAll(acces))
            {
                List<InventarioModel> lstInventarios = new List<InventarioModel>();
                List<ArticuloModel> lstArticulos = new List<ArticuloModel>();
                foreach (var inventario in _invRet.GetAll())
                    lstInventarios.Add(inventario);
                foreach (var articulo in lstArticulos)
                    lstArticulos.Add(articulo);
                var inventarios = lstInventarios.Where(x => x.Usuario_id == _usuario.Id);
                articulos = lstArticulos.Where(x => inventarios.Any(y => y.Articulo_id == x.Id));
                return true;
            }
            return false;
        }
        public bool GetAllArticulos(AccountAccess access, out IEnumerable<ArticuloModel> articulos)
        {
            articulos = null;
            if (_permisos.IsValidAll(access))
            {
                List<ArticuloModel> lstArticulos = new List<ArticuloModel>();
                foreach (var articulo in _artRet.GetAll())
                    lstArticulos.Add(articulo);
                articulos = lstArticulos;
                return true;
            }
            return false;
        }
        public bool ComprarArticulo(int inventarioId, AccountAccess access)
        {
            if (_permisos.IsValidAll(access))
            {
                VentaModel venta = new VentaModel
                {
                    Id = 0,
                    Comprador_id = _usuario.Id,
                    Fecha = DateTime.Now,
                    Inventario_id = inventarioId,
                    Status = StatusVentas.ESPERANDO
                };
                _ventRet.Register(venta);
                return true;
            }
            return false;
        }
        public bool GetCompras(AccountAccess access, out IEnumerable<VentaModel> compras, StatusVentas wichStatus)
        {
            compras = null;
            if (_permisos.IsValidAll(access))
            {
                List<VentaModel> lstCompras = new List<VentaModel>();
                foreach (var compra in _ventRet.GetAll())
                    lstCompras.Add(compra);

                if (wichStatus == StatusVentas.ALL)
                    compras = lstCompras.Where(x => x.Comprador_id == _usuario.Id);
                else
                    compras = lstCompras.Where(x => x.Comprador_id == _usuario.Id && x.Status == wichStatus);
                return true;
            }
            return false;
        }
        public bool GetVentas(AccountAccess access, out List<VentaModel> vendidos, StatusVentas whichStatus)
        {
            vendidos = null;
            if (_permisos.IsValidAll(access))
            {
                List<VentaModel> lstVentas = new List<VentaModel>();
                List<InventarioModel> lstInventarios = new List<InventarioModel>();
                foreach (var venta in _ventRet.GetAll())
                    lstVentas.Add(venta);
                foreach (var inventario in _invRet.GetAll())
                    lstInventarios.Add(inventario);
                var inventarios = lstInventarios.Where(x => x.Usuario_id == _usuario.Id);
                if (whichStatus == StatusVentas.ALL)
                    vendidos = lstVentas.
                        Where(x => inventarios.Any(y => y.Id == x.Inventario_id)).ToList();
                else
                    vendidos = lstVentas.
                        Where(x => inventarios.Any(y => y.Id == x.Inventario_id) && 
                        x.Status == whichStatus).ToList();
                return true;
            }
            return false;
        }
        public bool GetVentasDetalle(AccountAccess access, out List<InventarioModel> inventarios, StatusVentas wichStatus)
        {
            inventarios = new List<InventarioModel>();
            List<VentaModel> vendidos = null;
            if (GetVentas(access, out vendidos, wichStatus))
            {
                List<InventarioModel> lstInventarios = new List<InventarioModel>();
                foreach (var inventario in _invRet.GetAll())
                    lstInventarios.Add(inventario);
                inventarios = lstInventarios.Where(x => vendidos.Any(y => y.Inventario_id == x.Id)).ToList();
                return false;
            }
            return false;
        }
        public bool GetVendidosDescripcion(AccountAccess access, out List<ArticuloModel> articulos, StatusVentas wichStatus)
        {
            articulos = null;
            List<InventarioModel> inventarios;
            if (GetVentasDetalle(access, out inventarios, wichStatus))
            {
                List<ArticuloModel> lstArticulos = new List<ArticuloModel>();
                foreach (var articulo in _artRet.GetAll())
                    lstArticulos.Add(articulo);
                articulos = lstArticulos.Where(x => inventarios.Any(y => y.Articulo_id == x.Id)).ToList();
                return true;
            }
            return false;
        }
        public bool VenderArticulo(int ventaId, AccountAccess access)
        {
            if (_permisos.IsValidAll(access))
            {
                var venta = _ventRet.GetById(ventaId);
                venta.Status = StatusVentas.FINALIZADO;
                _ventRet.Update(venta);
                return true;
            }
            return false;
        }
        public bool RegistrarArticulo(RegistroModel registro, AccountAccess access)
        {
            if (_permisos.IsValidAll(access))
            {
                ArticuloModel articulo = new ArticuloModel
                {
                    Nombre = registro.Nombre,
                    Descripcion = registro.Descripcion
                };
                articulo = _artRet.Register(articulo);
                InventarioModel inventario = new InventarioModel
                {
                    Usuario_id = _usuario.Id,
                    Precio = registro.Precio,
                    Lugar = registro.Lugar,
                    Pais = registro.Pais,
                    Disponible = registro.Disponible,
                    Articulo_id = articulo.Id,
                };
                _invRet.Register(inventario);
                return true;
            }
            return false;
        }

        //public bool EliminarArticulo(int inventarioId, AccountAccess access)
        //{
        //    if (_permisos.IsValidAll(access))
        //    {
        //        var inventario = _invRet.GetById(inventarioId);
        //        var articulo = _artRet.GetById(inventario.Articulo_id);
        //        var venta = _ventRet.GetAll().Where(x => x.Inventario_id == inventario.Id);
        //        //var compras = inventario.Compras.Where(x => x.Inventario.Usuario_id == _usuario.Id);
        //        //var ventas = inventario.Ventas.Where(x => x.Inventario.Usuario_id == _usuario.Id);
        //        //var articulo = inventario.Articulo;
        //        //foreach (var compra in compras)
        //        //    _compRet.Delete(compra.Id);
        //        //foreach (var venta in ventas)
        //        //    _ventRet.Delete(venta.Id);
        //        //_artRet.Delete(articulo.Id);
        //        _invRet.Delete(inventario.Id);
        //        return true;
        //    }
        //    return false;
        //}
    }
}
