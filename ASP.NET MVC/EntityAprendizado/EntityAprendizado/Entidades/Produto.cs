﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado.Entidades
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CategoriaID { get; set; }
        public virtual IList<ProdutoVenda> ProdutosVendas { get; set; }
    }
}
