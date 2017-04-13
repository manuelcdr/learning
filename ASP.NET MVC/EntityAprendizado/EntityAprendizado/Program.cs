using EntityAprendizado.Dao;
using EntityAprendizado.Entidades;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado
{
    class Program
    {
        static void Main(string[] args)
        {

            EntityContext ctx = new EntityContext();

            UsuarioDao dao = new UsuarioDao(ctx);

            PessoaFisica pf = new PessoaFisica()
            {
                Nome = "Guilherme",
                CPF = "123456",
                Senha = "123"
            };

            ctx.PessoasFisicas.Add(pf);

            PessoaJuridica pj = new PessoaJuridica()
            {
                Nome = "Alura",
                CNPJ = "789",
                Senha = "123"
            };

            ctx.PessoasJuridicas.Add(pj);

            ctx.SaveChanges();
        }
    }
}
