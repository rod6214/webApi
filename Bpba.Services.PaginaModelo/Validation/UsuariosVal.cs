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
        //private SesionVal _sesion;
        //private Permisos _permisos;
        //private UsuarioModel _usuario;
        public UsuariosVal(CookieModel cookie)
        {
            //_sesion = new SesionVal(cookie);
            //_usuario = _sesion.GetUsuario();
            //_permisos = new Permisos(cookie);
        }
        public UsuariosVal() { }
        public IEnumerable<UsuarioModel> GetUsuarios()
        {
            List<UsuarioModel> lstUsr = new List<UsuarioModel>();
            foreach (var usr in _usrRet.GetAll())
                lstUsr.Add(usr);
            return lstUsr;
        }
        public bool RegisterUsuario(UsuarioRegisterModel usuarioRegister, AccountAccess perfil, string descripcionPerfil)
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
            if (usuarioRegister.Persona != null)
                persona = _perRet.Register(usuarioRegister.Persona);
            else
                persona = _perRet.Register(persona);
            if (usuarioRegister.Usuario != null)
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
            return false;
        }
        public bool RegisterUsuario(UsuarioRegisterModel usuarioRegister)
        {
            return RegisterUsuario(usuarioRegister, AccountAccess.USER, "Usuario con acceso limitado.");
        }
        public void UpdateUsuario(UsuarioModel usuario)
        {
            _usrRet.Update(usuario);
        }
        public void DeleteUsuario(int id)
        {
            _usrRet.Delete(id);
        }
        public void SetPerfil(PerfilModel perfil)
        {
            foreach (var perf in _perfRet.GetAll())
                if (perf.Usuario_id == perfil.Usuario_id)
                {
                    _perfRet.Register(perfil);
                    return;
                }
            _perfRet.Update(perfil);
        }
        public void SetDatosPersonales(int usuarioId, PersonaModel persona)
        {
            persona.Id = _usrRet.GetById(usuarioId).Persona_id;
            _perRet.Update(persona);
        }
        public void GetUserArticulos(int usuarioId, out IEnumerable<ArticuloModel> articulos)
        {
            articulos = null;
            List<InventarioModel> lstInventarios = new List<InventarioModel>();
            List<ArticuloModel> lstArticulos = new List<ArticuloModel>();
            foreach (var inventario in _invRet.GetAll())
                lstInventarios.Add(inventario);
            foreach (var articulo in lstArticulos)
                lstArticulos.Add(articulo);
            var inventarios = lstInventarios.Where(x => x.Usuario_id == usuarioId);
            articulos = lstArticulos.Where(x => inventarios.Any(y => y.Articulo_id == x.Id));
        }
        public void GetAllArticulos(out IEnumerable<ArticuloModel> articulos)
        {
            articulos = null;
            List<ArticuloModel> lstArticulos = new List<ArticuloModel>();
            foreach (var articulo in _artRet.GetAll())
                lstArticulos.Add(articulo);
            articulos = lstArticulos;
        }
        public void ComprarArticulo(int usuarioId, int inventarioId)
        {
            VentaModel venta = new VentaModel
            {
                Id = 0,
                Comprador_id = usuarioId,
                Fecha = DateTime.Now,
                Inventario_id = inventarioId,
                Status = StatusVentas.ESPERANDO
            };
            _ventRet.Register(venta);
        }
        public void GetCompras(int usuarioId, out IEnumerable<VentaModel> compras, StatusVentas wichStatus)
        {
            compras = null;
            List<VentaModel> lstCompras = new List<VentaModel>();
            foreach (var compra in _ventRet.GetAll())
                lstCompras.Add(compra);

            if (wichStatus == StatusVentas.ALL)
                compras = lstCompras.Where(x => x.Comprador_id == usuarioId);
            else
                compras = lstCompras.Where(x => x.Comprador_id == usuarioId && x.Status == wichStatus);
        }
        public void GetVentas(int usuarioId, out List<VentaModel> vendidos, StatusVentas whichStatus)
        {
            vendidos = null;
            List<VentaModel> lstVentas = new List<VentaModel>();
            List<InventarioModel> lstInventarios = new List<InventarioModel>();
            foreach (var venta in _ventRet.GetAll())
                lstVentas.Add(venta);
            foreach (var inventario in _invRet.GetAll())
                lstInventarios.Add(inventario);
            var inventarios = lstInventarios.Where(x => x.Usuario_id == usuarioId);
            if (whichStatus == StatusVentas.ALL)
                vendidos = lstVentas.
                    Where(x => inventarios.Any(y => y.Id == x.Inventario_id)).ToList();
            else
                vendidos = lstVentas.
                    Where(x => inventarios.Any(y => y.Id == x.Inventario_id) &&
                    x.Status == whichStatus).ToList();
        }
        //public void GetVentasDetalle(out List<InventarioModel> inventarios, StatusVentas wichStatus)
        //{
        //    inventarios = new List<InventarioModel>();
        //    List<VentaModel> vendidos = null;
        //    List<InventarioModel> lstInventarios = new List<InventarioModel>();
        //    foreach (var inventario in _invRet.GetAll())
        //        lstInventarios.Add(inventario);
        //    inventarios = lstInventarios.Where(x => vendidos.Any(y => y.Inventario_id == x.Id)).ToList();
        //}
        //public void GetVendidosDescripcion(out List<ArticuloModel> articulos, StatusVentas wichStatus)
        //{
        //    articulos = null;
        //    List<InventarioModel> inventarios;
        //    GetVentasDetalle(out inventarios, wichStatus);
        //    List<ArticuloModel> lstArticulos = new List<ArticuloModel>();
        //    foreach (var articulo in _artRet.GetAll())
        //        lstArticulos.Add(articulo);
        //    articulos = lstArticulos.Where(x => inventarios.Any(y => y.Articulo_id == x.Id)).ToList();
        //}
        public void VenderArticulo(int ventaId)
        {
            var venta = _ventRet.GetById(ventaId);
            venta.Status = StatusVentas.FINALIZADO;
            _ventRet.Update(venta);
        }
        //public void RegistrarArticulo(RegistroModel registro)
        //{
        //    ArticuloModel articulo = new ArticuloModel
        //    {
        //        Nombre = registro.Nombre,
        //        Descripcion = registro.Descripcion
        //    };
        //    articulo = _artRet.Register(articulo);
        //    InventarioModel inventario = new InventarioModel
        //    {
        //        Usuario_id = _usuario.Id,
        //        Precio = registro.Precio,
        //        Lugar = registro.Lugar,
        //        Pais = registro.Pais,
        //        Disponible = registro.Disponible,
        //        Articulo_id = articulo.Id,
        //    };
        //    _invRet.Register(inventario);
        //}

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
