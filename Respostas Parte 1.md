# 📝 Respostas - Questões Técnicas

## Parte 1 – Teoria

### 1. Como você usaria ferramentas de IA (ex.: GitHub Copilot, ChatGPT) no seu processo de desenvolvimento para ganhar produtividade sem comprometer qualidade?

**Resposta:**

Gosto de utilizar a IA principalmente para realizar tarefas físicas que demoro para fazer mas que ela faz bem rapido, como digitação. Com isto a implementação do codigo fica bem rapida e consigo fazer entregas constantes em tempo recorde.

Muita coisa e necessária para que eu possa utilizar a IA desta forma, principalmente ter uma base de código muito bem feita, testada, e principalmente simples. Outra coisa que julgo necessário para deixar a IA implementar uma feature para mim é no caso de ter um outro exemplo MUITO similar ao que eu preciso ja presente na aplicação, neste caso eu solicito que ela faça algo ja com o demonstrativo de como deve ser feito, evitando problemas de comunicação, digitação ou entendimento.

Desta forma fica mais fácil para revisar e ajustar o código também.

Também utilizo ela para refatorar blocos de código, gosto de fazer manualmente uma vez, uso como exemplo e peço ela para prosseguir da mesma maneira em outras ocorrências.

Aprendizado também costuma ser muito útil, se preciso aprender uma ação rapidamente, eu peço ela e fico contextualizado, ao procurar a informação na internet depois, eu ja me sinto situado sobre o assunto, fazendo com que minha busca seja mais precisa e rápida.

Code Review: utilizar as ferramentas de IA para analisar qualidade de código antes de fazer um pull request costuma ser bem efetivo.

---

### 2. Explique em poucas palavras o que é Dependency Injection no .NET Core e porque é importante.

**Resposta:**

É um padrão de design que permite injetar dependências em uma classe ao invés de criá-las internamente:

```csharp

// Sem DI - acoplamento forte
public class ClienteService 
{
    private readonly MongoDbContext _context = new MongoDbContext(); // ❌
}

// Com DI - baixo acoplamento
public class ClienteService 
{
    private readonly MongoDbContext _context;
    
    public ClienteService(MongoDbContext context) // ✅ Injeção via construtor
    {
        _context = context;
    }
}
```

Facilita criação de mocks em testes unitários, permite trocar implementações sem modificar código reduzindo acoplamento entre classes e fazendo com que as dependências possam ser compartilhadas entre serviços.

**Escopos de Dependência:**

```csharp
// No Program.cs
services.AddSingleton<IConfigurationService, ConfigurationService>(); // Uma instância para toda aplicação
services.AddScoped<IClienteService, ClienteService>(); // Uma instância por requisição HTTP
services.AddTransient<IEmailService, EmailService>(); // Nova instância a cada injeção
```

- **Singleton**: Uma única instância para toda a aplicação (ex: configurações, cache)
- **Scoped**: Uma instância por requisição HTTP (ex: serviços de negócio, contexto de banco)
- **Transient**: Nova instância a cada injeção (ex: utilitários, validadores)

---

### 3. Qual a diferença entre SQL Server (relacional) e MongoDB (NoSQL)? Dê um exemplo de cenário adequado para cada.

**Resposta:**

A principal diferença entre SQL Server e MongoDB está na forma como organizam e armazenam os dados. O SQL Server é um banco relacional que utiliza tabelas com esquema fixo, onde os dados são organizados em linhas e colunas com relacionamentos bem definidos através de chaves estrangeiras. Ele garante consistência ACID forte, ideal para transações críticas como sistemas financeiros ou de vendas, onde a integridade dos dados é fundamental.

O MongoDB, por outro lado, é um banco NoSQL que armazena dados em formato de documentos JSON flexíveis, permitindo estruturas variáveis dentro da mesma coleção. Ele prioriza escalabilidade horizontal e performance em operações de escrita, sendo excelente para cenários como sistemas de logs, onde a estrutura dos dados pode variar e a velocidade de inserção é mais importante que a consistência imediata.

Para um sistema de vendas tradicional, escolheria SQL Server porque os dados são estruturados (pedidos, produtos, clientes) e os relacionamentos são complexos, exigindo consultas com múltiplos JOINs e garantia de transações ACID. Já para um sistema de logs de aplicação, optaria pelo MongoDB, pois cada log pode ter campos diferentes dependendo do tipo de evento, e a alta frequência de escrita com estruturas variáveis se beneficia da flexibilidade dos documentos JSON.

---

### 4. Em uma API REST, quando você deve retornar 404 e quando 400?

**Resposta:**

A diferença entre os códigos de status 404 e 400 está relacionada ao tipo de problema que ocorreu na requisição. O 404 Not Found é usado quando o recurso solicitado simplesmente não existe no sistema. Isso acontece quando você tenta acessar um cliente com um ID que não foi encontrado no banco de dados, quando a rota da API não está mapeada, ou quando um recurso que existia anteriormente foi removido. É como procurar por um arquivo que não está na pasta - o problema não está na forma como você fez a busca, mas sim no fato de que o que você procura não existe.

Já o 400 Bad Request indica que há algo errado com os dados que foram enviados na requisição. Isso inclui situações como dados em formato incorreto, campos obrigatórios que não foram preenchidos, validações de regras de negócio que falharam, ou parâmetros de query malformados. É como tentar enviar um formulário com campos em branco ou com dados inválidos - o problema está na qualidade ou completude dos dados enviados, não na existência do recurso.

Em resumo: **404** significa "o que você procura não existe", enquanto **400** significa "o que você enviou está errado".

---

### 5. No Angular, qual a função de um Service e como ele se comunica com componentes?

**Resposta:**

Os Services no angular são funcionam podem cuidar de tarefas específicas para os componentes. Ele centraliza a lógica de negócio, podendo fazer a comunicação com APIs externas se necessário, podem gerencia o estado dos dados entre os componentes evitando a repetição código em vários lugares

A comunicação entre Services e componentes acontece principalmente através da injeção de dependência.

---

### 6. Você tem que criar uma API para cadastro de motoristas que deve ser consultada com frequência por outros sistemas. O que faria para garantir performance e segurança? Usaria SQL Server ou MongoDB para armazenar? Justifique.

**Resposta:**

Para uma API de motoristas que será consultada frequentemente, eu escolheria o SQL Server. Os dados de motoristas são bem estruturados contendo documentos como CPF, CNH, nome, endereço com isso posso precisar de fazer consultas mais complexas, relatórios e relacionamentos. Além disso, dados de motoristas são críticos e não podem ter inconsistências, então a garantia ACID do SQL Server é fundamental.

Para garantir performance, implementaria cache com Redis para as consultas mais frequentes, criaria índices no banco para CPF, CNH e status ativo, e sempre usaria paginação para evitar retornar milhares de registros de uma vez. O cache é especialmente importante porque consultas por CPF ou CNH são muito comuns e você não quer ficar batendo no banco toda hora.

Na parte de segurança, usaria autenticação JWT para proteger todos os endpoints, implementaria rate limiting para evitar abuso da API, e faria validação rigorosa de todos os dados de entrada - especialmente CPF e email que são campos críticos. Também adicionaria logs de auditoria para rastrear quem acessou o quê e quando.

---

### 7. Durante o desenvolvimento, o time sugere expor os dados sem autenticação porque 'vai ser só interno'. Quais riscos você enxerga nessa decisão? Como garantir segurança sem complicar demais o consumo?

**Resposta:**

Qualquer pessoa que descobrir a URL da API pode acessar todos os dados, incluindo informações sensíveis como CPFs e dados pessoais. Sem autenticação eu nao consigo rastrear quem acessou o quê, não teria controle sobre o uso da API, e pode sofrer ataques automatizados que vão derrubar o servidor.

O pior é que mesmo sendo interno, dados podem vazar por engano caso alguém compartilhe a URL, faça um print da tela, ou até mesmo um funcionário mal-intencionado pode decidir violar os dados. Isso pode gerar problemas sérios de compliance com LGPD..

Para resolver isso de forma simples, eu implementaria uma API Key básica que os sistemas internos usariam no header das requisições. É super simples de implementar e usar, mas já protege contra acessos não autorizados. Também colocaria rate limiting para evitar abuso e logs para rastrear o uso. Se quiser algo ainda mais simples, pode usar whitelist de IPs da rede interna, mas a API Key é mais flexível e segura.

---

### 8. Você está desenvolvendo um sistema que precisa notificar múltiplos módulos sobre a criação de um cliente. Qual mecanismo de mensageria você usaria, e por quê?

**Resposta:**

Para notificar múltiplos módulos sobre a criação de um cliente, eu usaria o Apache Kafka. Parece otimo para esse cenário porque eu teria um evento único (cliente criado) que precisa ser consumido por vários módulos diferentes - como envio de email de boas-vindas, criação de perfil no CRM, registro de métricas de analytics, e envio de SMS.

O Kafka é ideal porque ele garante que a mensagem não seja perdida, permite que múltiplos consumidores processem o mesmo evento independentemente, e se um módulo falhar, ele pode reprocessar a mensagem depois. Além disso, é muito escalável e pode lidar com milhões de mensagens por segundo se necessário.

Considerei outras opções como RabbitMQ, mas o Kafka é mais robusto para múltiplos consumidores e tem melhor escalabilidade horizontal. Azure Service Bus é uma opção que foi dita ser utilizada durante minha entrevista tecnica, mas pode gerar uma dependencia com a microsoft ou sair caro sob alta demanda.

---