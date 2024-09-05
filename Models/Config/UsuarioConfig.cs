using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ProjectLogin.Models.Config
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(i => i.Id).IsUnique();
            builder.HasIndex(i => i.NombreUsuario).IsUnique();
            builder.HasIndex(i => i.Correo).IsUnique();

            //builder.Property(c => c.Contenido).HasMaxLength(500);

            //builder.Property(no => no.NombreUsuario).HasMaxLength(50);
            //builder.Property(c => c.Correo).HasMaxLength(50);
            //builder.Property(cl => cl.clave).HasMaxLength(100);

        }
    }
}
