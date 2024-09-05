using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjectLogin.Models;
using ProjectLogin.Resources;
using ProjectLogin.Services.Contract;
using System.Diagnostics;
using System.Security.Claims;

namespace ProjectLogin.Controllers
{
    public class InicioController1 : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public InicioController1(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.clave = Utilities.EncriptarClave(modelo.clave);

            Usuario usuarioCreado = await _usuarioService.SaveUsuarios(modelo);

            if (usuarioCreado.Id > 0)
                return RedirectToAction("IniciarSesion", "InicioController1");
           

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _usuarioService.GetUsuarios(correo, Utilities.EncriptarClave(clave));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.NombreUsuario) 
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            //return RedirectToAction("Inicio", "IniciarSesion"); 
            return RedirectToAction("Index", "Home"); 
            
        }
        
    }
}
