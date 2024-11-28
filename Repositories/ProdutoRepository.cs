
public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }
    public Produto Delete(int id)
    {
        var produto = _context.Produtos.Find(id);
        if(produto == null)
            return produto;
        
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return produto;
    }

    public Produto Get(int id)
    {
        return _context.Produtos.Find(id);
    }

    public List<Produto> GetAll()
    {
        return _context.Produtos.ToList();
    }

    public void Post(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public Produto Put(int id, Produto produtoAtualizado)
    {
       var produto = _context.Produtos.Find(id);
       if(produto == null)
            return produto;
        
        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;

        _context.SaveChanges();
        return produto;
    }
}