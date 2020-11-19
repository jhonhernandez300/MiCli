using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCli
{
    class CrearContexto
    {
        public string UnoAMuchos(string modeloDeUno, string modeloDeMuchos)
        {
            string relacion = "modelBuilder.Entity<" + modeloDeUno + ">()" + Environment.NewLine +
                "   .HasOne(p => p." + modeloDeMuchos + ")" + Environment.NewLine +
                "   .WithMany(b => b." + modeloDeUno + ")" + Environment.NewLine +
                ".HasForeignKey(t => t.Id" + modeloDeMuchos + ");";

            return relacion;
        }

    }
}
