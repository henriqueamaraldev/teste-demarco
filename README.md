# 🚀 Sistema de Gerenciamento de Clientes

Sistema full-stack para gerenciamento de clientes com API .NET Core e frontend Angular.

## 📋 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- **Docker Desktop** - Para o banco de dados MongoDB
- **.NET 9.0 SDK** - Para a API
- **Node.js 18+** - Para o frontend Angular
- **Visual Studio 2022** ou **VS Code** - Para desenvolvimento

## 🏗️ Arquitetura

``` md
📁 Projeto
├── 📁 boilerplate_back/     # API .NET Core
│   ├── 📁 Api/              # Controllers e configuração
│   ├── 📁 Application/      # Serviços e DTOs
│   ├── 📁 Domain/           # Entidades
│   └── 📁 Infrastructure/   # MongoDB e configurações
└── 📁 boilerplate_front/    # Frontend Angular
    ├── 📁 src/app/          # Componentes e serviços
    └── 📁 src/environments/ # Configurações de ambiente
```

## 🚀 Como Executar

### 1. 📦 Configurar o Banco de Dados (MongoDB)

Primeiro, inicie o MongoDB usando Docker Compose:

```bash
# Navegue para a pasta do backend
cd boilerplate_back

# Execute o docker-compose para subir o MongoDB
docker-compose up -d
```

Isso irá:

- ✅ Criar um container MongoDB na porta `27017`
- ✅ Configurar o banco `ClientesDB`
- ✅ Criar volumes persistentes para os dados

### 2. 🔧 Executar a API (.NET Core)

```bash
# Navegue para a pasta da API
cd boilerplate_back/Api

# Execute a API com o perfil HTTPS
dotnet run --launch-profile https
```

A API estará disponível em:

- 🔒 **HTTPS**: `https://localhost:7048`
- 📊 **Swagger**: `https://localhost:7048` (documentação da API)

### 3. 🎨 Executar o Frontend (Angular)

```bash
# Navegue para a pasta do frontend
cd boilerplate_front

# Instale as dependências (primeira vez)
npm install

# Execute o servidor de desenvolvimento
ng serve
```

O frontend estará disponível em:

- 🌐 **Aplicação**: `http://localhost:4200`

## 🎯 Funcionalidades

### ✅ Implementadas

- **📋 Listagem de Clientes** - Com paginação
- **➕ Criação de Clientes** - Modal com validação
- **🔍 Filtros** - Por nome e email
- **📄 Paginação** - Navegação entre páginas
- **🎨 Interface Moderna** - Design responsivo com Tailwind CSS

### 🔄 Endpoints da API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/api/cliente` | Lista clientes com paginação |
| `POST` | `/api/cliente` | Cria novo cliente |
| `GET` | `/api/cliente/{id}` | Obtém cliente por ID |
| `GET` | `/api/cliente/all` | Lista todos os clientes (sem paginação) |

## 🛠️ Tecnologias Utilizadas

### Backend Stack

- **.NET 9.0** - Framework principal
- **MongoDB** - Banco de dados NoSQL
- **Swagger/OpenAPI** - Documentação da API
- **Docker** - Containerização

### Frontend Stack

- **Angular 18** - Framework SPA
- **PrimeNG** - Componentes UI
- **Tailwind CSS** - Estilização
- **Axios** - Cliente HTTP

## 📁 Estrutura do Projeto

### Backend (`boilerplate_back/`)

``` md
Api/
├── Controllers/          # Controllers da API
├── Middlewares/          # Middlewares customizados
└── Program.cs           # Configuração da aplicação

Application/
├── Services/            # Lógica de negócio
└── Dtos/               # Data Transfer Objects

Domain/
└── Entities/           # Entidades do domínio

Infrastructure/
├── Database/           # Configuração do MongoDB
└── Config/            # Configurações de infraestrutura
```

### Frontend (`boilerplate_front/`)

``` md
src/app/
├── components/         # Componentes reutilizáveis
├── core/
│   ├── models/        # Modelos de dados
│   └── services/      # Serviços da aplicação
├── pages/             # Páginas da aplicação
└── primeng/           # Configurações do PrimeNG
```

## 🔧 Configurações

### Variáveis de Ambiente

#### Backend

- **MongoDB Connection**: `mongodb://localhost:27017`
- **Database Name**: `ClientesDB`
- **Porta HTTPS**: `7048`
- **Porta HTTP**: `5279`

#### Frontend

- **API URL**: `https://localhost:7048/api`
- **Porta**: `4200`

## 🐛 Solução de Problemas

### Problema: API não conecta ao MongoDB

```bash
# Verifique se o MongoDB está rodando
docker ps

# Se não estiver, reinicie o container
cd boilerplate_back
docker-compose restart
```

### Problema: Erro de CORS no frontend

- ✅ CORS já está configurado no backend
- Verifique se a API está rodando na porta `7048`

### Problema: Certificado SSL inválido

- Clique em "Avançado" no navegador
- Selecione "Prosseguir para localhost"

## 📝 Desenvolvimento

### Adicionando Novos Clientes

1. Clique no botão "Novo Cliente"
2. Preencha nome e email
3. Clique em "Criar Cliente"
4. O cliente aparecerá na lista automaticamente

### Navegando pela Lista

- Use os controles de paginação na parte inferior
- Altere o número de itens por página (5, 10, 25, 50)
- Navegue entre as páginas usando os botões
  
---

## 🆘 Suporte

Se encontrar algum problema:

1. Verifique se todos os pré-requisitos estão instalados
2. Confirme se o MongoDB está rodando (`docker ps`)
3. Verifique os logs no console do navegador (F12)
4. Confirme se a API está acessível em `https://localhost:7048`

**Happy Coding! 🎉**
