namespace AviarasBookshop.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }

        // Many-to-many relationship with Autor
        public ICollection<Autor>? Autores { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
