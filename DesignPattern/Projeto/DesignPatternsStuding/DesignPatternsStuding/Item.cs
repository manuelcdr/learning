namespace DesignPatternsStuding
{
    public class Item
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Item(string nome, double preco, int quantidade = 1)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Quantidade = quantidade;
        }
    }
}