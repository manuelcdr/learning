using AprendendoEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEntity
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Iniciando aplicaçao...");


            Usuario usuario = new Usuario()
            {
                Nome = "Manuel",
                Senha = "123"
            };


            EntityContext contexto = new EntityContext();
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
            contexto.Dispose();





            Console.Read();
        }
    }
}
