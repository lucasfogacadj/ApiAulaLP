using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>();
    [HttpGet]
    public ActionResult<List<Produto>> GetAll()
    {
        return produtos;
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
        Produto produto = null;
        foreach(var p in produtos)
        {
            if(p.Id == id)
            {
                produto = p;
                break;
            }
        }

        if(produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        produtos.Add(produto);
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Produto produtoAtualizado)
    {
        Produto produto = null;
        foreach(var p in produtos)
        {
            if(p.Id == id)
            {
                produto = p;
                break;
            }
        }

        if(produto == null)
        {
            return NotFound();
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;

        return NoContent();    
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Produto produto = null;
        foreach(var p in produtos)
        {
            if(p.Id == id)
            {
                produto = p;
                break;
            }
        }

        if(produto == null)
        {
            return NotFound();
        }

        produtos.Remove(produto);

        return NoContent();
    }

}
