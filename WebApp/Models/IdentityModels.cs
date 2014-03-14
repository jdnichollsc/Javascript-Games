using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
// Proveedor de datos propio de Microsoft para Entity Framework que se incorpora al seleccionar la opción Individual User Accounts
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebApp.Models
{
    // Podemos añadir más campos que necesitemos de nuestros usuarios, para más info => http://go.microsoft.com/fwlink/?LinkID=317594

    //Con ASP.NET Identity podemos tener nuestro propio proveedor de datos que se adapte a un esquema de BBDD en específico
    //Como por ejemplo un proveedor NoSQL para MongoDb

    //IdentityUser utiliza la interfaz IUser(Solo define los campos Id y UserName) y añade los campos PasswordHash y SecurityStamp => Tabla AspNetUsers 
    public class ApplicationUser : IdentityUser
    {
        //Agregamos los demás campos que necesitemos de nuestros usuarios
        #region [ Fields ]
        [DisplayName("Nombre"), Required(ErrorMessage = "Debe ingresar su nombre."), StringLength(250)]
        public string FirstName { get; set; }

        [DisplayName("Apellidos"), Required(ErrorMessage = "Debe ingresar sus apellidos."), StringLength(250)]
        public string LastName { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "Debe ingresar un email válido."), StringLength(250)]
        public string Email { get; set; }

        [DisplayName("Documento"), Required(ErrorMessage = "Debe ingresar su documento."), StringLength(50)]
        public string Document { get; set; }

        [DisplayName("Teléfono"), Required(ErrorMessage = "Debe ingresar su número de teléfono."), StringLength(50)]
        public string Phone { get; set; }

        [DisplayName("Celular"), Required(ErrorMessage = "Debe ingresar su número de celular."), StringLength(50)]
        public string CellPhone { get; set; }

        [DisplayName("Género"), Required(ErrorMessage = "Debe ingresar su género.")]
        public bool Gender { get; set; }

        [DisplayName("Fecha de Nacimiento"), 
         Required(ErrorMessage = "Debe ingresar su fecha de nacimiento."), 
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [DisplayName("Dirección"), Required(ErrorMessage = "Debe ingresar su dirección."), StringLength(100)]
        public string Address { get; set; }

        public DateTime? CreationDate { get; set; }

        #endregion
    }

    //Siempre que modificamos nuestro esquema de datos tenemos que actualizarlo en la BBDD, ya sea eliminando las tablas con los datos o realizar Migraciones.
    //Al agregar una nueva migración esta se genera automáticamente comparando el esquema de la BBDD con el que tendría que haber según nuestro Modelo.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityUser>().ToTable("Users").
            //    Property(u => u.PasswordHash).HasColumnName("Password");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").
                Property(u => u.PasswordHash).HasColumnName("Password");
        }
    }
}