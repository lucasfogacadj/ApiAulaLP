public interface IProdutoRepository
{
    public List<Produto> GetAll();
    public Produto Get(int id);
    public void Post(Produto produto);
    public Produto Put(int id, Produto produtoAtualizado);
    public Produto Delete(int id);
}