using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _repository;

    public ProdutosController(IProdutoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<Produto>> GetAll()
    {
        var produtos = _repository.GetAll();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _repository.Get(id);
        if(produto == null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        _repository.Post(produto);
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Produto produtoAtualizado)
    {
        var produto = _repository.Put(id, produtoAtualizado);
        
        if(produto == null)
            return NotFound();

        return Ok(produto);    
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var produto = _repository.Delete(id);
        if(produto == null)
            return NotFound();

        return NoContent();
    }

}
