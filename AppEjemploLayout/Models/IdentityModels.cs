﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppEjemploLayout.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AppEjemploLayout.Models.ClasesUsuario.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<AppEjemploLayout.Models.ClasesProyecto.Proyecto> Proyectoes { get; set; }
        
        public System.Data.Entity.DbSet<AppEjemploLayout.Models.Proyecto_Usuario.ProyectoUsuarioRelacion> ProyectoUsuario { get; set; }
        
        public System.Data.Entity.DbSet<AppEjemploLayout.Models.ClasesHistoriaUsuario.HistoriaUsuario> HistoriaUsuarios { get; set; }

        public System.Data.Entity.DbSet<AppEjemploLayout.Models.ClasesSprints.Sprint> Sprint { get; set; }
        public System.Data.Entity.DbSet<AppEjemploLayout.Models.ClasesSprints.TareaSprint> TareaSprint { get; set; }
    }
}