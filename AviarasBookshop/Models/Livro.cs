namespace AviarasBookshop.Models
{
    public enum CategoriaLivro
    {
        NaoFiccao,
        Fantasia,
        Romance,
        Ciencia,
        Historia,
        Terror
    }
    public class Livro
    { 
        public int Id { get; set; }

        public string Titulo { get; set; }

        public String Categoria { get; set; }

        public string Autor {  get; set; }

        public decimal Preco {  get; set; }

        public ICollection<Autor>? Autores { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
