# Parte 4 – Código Incompleto / Refatoração

Analise o código abaixo e identifique os problemas:

```csharp
[HttpPost("clientes")]
public IActionResult Cadastrar(string nome, string email)
{
    var cliente = new Cliente();
    cliente.Nome = nome;
    cliente.Email = email;
    var jaExiste = _context.Clientes.Any(c => c.Email == email);
    if (jaExiste) return Ok("Já existe cliente");
    _context.Clientes.Add(cliente);
    _context.SaveChanges();
    return Ok(cliente);
}
```

---

## 💭 Resposta

1 - Vejo que toda a complexidade está em apenas um método, não chama um serviço, o próprio controller executa as regras de negócio e adiciona os clientes no banco.

Não utiliza um constructor, instancia um objeto da Cliente que muitas vezes não é válido, para só depois conferir a ele um nome e um email. Quando a classe Cliente for refatorada ou tiver mais uma propriedade obrigatória, eu precisaria procurar todas as ocorrências de criação de Cliente no código para lhe conferir a nova propriedade. Caso utilizasse um constructor, ao adicionar uma nova propriedade, todas as ocorrências de instanciar a classe Cliente se tornariam inválidas, impossibilitando o código de rodar com baixa confiabilidade.

A chamada para conferir se o cliente já existe não espera o retorno do banco, faltou um await.

Quando o cliente já existe estamos retornando um código 200 ao utilizar o Ok("Já existe cliente").

Também precisamos esperar o banco salvar a adição do novo Cliente no banco antes de retornar um Ok(cliente), pois ainda pode ocorrer um erro com o banco e não queremos enviar uma informação equivocada.

2 - Para melhorar esse código, eu separaria as responsabilidades seguindo os princípios SOLID. Primeiro, criaria um serviço dedicado para gerenciar a lógica de negócio dos clientes, movendo toda a complexidade do controller para lá. O controller ficaria apenas responsável por receber a requisição, chamar o serviço e retornar a resposta apropriada.

Implementaria um constructor na classe Cliente que recebesse nome e email como parâmetros obrigatórios, garantindo que o objeto sempre seja criado em um estado válido. Isso evitaria a necessidade de instanciar um objeto vazio e depois atribuir valores, e também forçaria a atualização de todos os pontos do código quando novas propriedades obrigatórias fossem adicionadas.

Tornaria o método assíncrono e adicionaria await nas operações de banco de dados, tanto na verificação de existência quanto no salvamento. Para o retorno quando o cliente já existe, usaria BadRequest(409) ou Conflict() ao invés de Ok(), já que é um erro de negócio, não um sucesso.

Adicionaria validação de entrada usando Data Annotations ou FluentValidation, e implementaria tratamento de exceções para capturar erros de banco de dados. Também consideraria usar um padrão de Result ou Response para padronizar as respostas da API e facilitar o tratamento de erros no frontend.