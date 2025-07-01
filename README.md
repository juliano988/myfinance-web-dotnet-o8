# MyFinance Web - Sistema de Controle Financeiro

Sistema web para controle financeiro desenvolvido em ASP.NET Core 9.0, permitindo o gerenciamento de planos de conta e transações financeiras.

## 📋 Descrição do Projeto

O MyFinance Web é uma aplicação web desenvolvida para auxiliar no controle de finanças pessoais ou empresariais. O sistema permite:

- **Gerenciamento de Planos de Conta**: Cadastro e manutenção de contas financeiras (receitas e despesas)
- **Controle de Transações**: Registro e acompanhamento de movimentações financeiras
- **Interface Web Intuitiva**: Interface responsiva desenvolvida com Bootstrap

## 🏗️ Arquitetura Utilizada

O projeto segue uma arquitetura em camadas (Layered Architecture) com separação clara de responsabilidades:

```
📁 src/myfinance-web-dotnet-o8/
├── 📁 Controllers/          # Controladores MVC
├── 📁 Domain/              # Entidades de domínio
├── 📁 Infrastructure/      # Acesso a dados (Entity Framework)
├── 📁 Services/            # Lógica de negócio
├── 📁 Models/              # ViewModels
├── 📁 Views/               # Views Razor
└── 📁 wwwroot/             # Arquivos estáticos
```

### Camadas da Aplicação:

- **Presentation Layer**: Controllers e Views (MVC)
- **Service Layer**: Serviços de negócio (PlanoContaService, TransacaoService)
- **Domain Layer**: Entidades de domínio (PlanoConta, Transacao)
- **Infrastructure Layer**: Contexto do Entity Framework e acesso a dados

## 🛠️ Tecnologias Utilizadas

### Backend
- **ASP.NET Core 9.0** - Framework web
- **Entity Framework Core 9.0.5** - ORM para acesso a dados
- **Entity Framework 6.5.1** - Framework adicional para compatibilidade
- **SQL Server** - Banco de dados relacional

### Frontend
- **HTML5/CSS3** - Estrutura e estilização
- **Bootstrap** - Framework CSS responsivo
- **jQuery** - Biblioteca JavaScript
- **Razor Views** - Motor de template do ASP.NET

### Ferramentas de Desenvolvimento
- **Visual Studio Code** - IDE
- **SQL Server Management Studio** - Gerenciamento do banco de dados

## ⚙️ Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) ou SQL Server Express
- [Visual Studio Code](https://code.visualstudio.com/) (recomendado)

## 🚀 Como Configurar e Executar o Projeto

### 1. Clone o Repositório
```bash
git clone [url-do-repositorio]
cd myfinance-web-dotnet-o8
```

### 2. Configurar o Banco de Dados

#### 2.1. Criar o Banco de Dados
Execute o script SQL localizado em `src/myfinance-web-dotnet-o8/docs/myfinance.sql` no SQL Server Management Studio ou execute via linha de comando:

```sql
-- O script criará o banco 'myfinance' e as tabelas necessárias
```

#### 2.2. Configurar a String de Conexão
Edite o arquivo `MyFinanceDbContext.cs` e ajuste a string de conexão conforme seu ambiente:

```csharp
var connectionString = @"Server=SEU_SERVIDOR;Database=myfinance;Trusted_Connection=True;TrustServerCertificate=True";
```

### 3. Restaurar Dependências
```bash
cd src/myfinance-web-dotnet-o8
dotnet restore
```

### 4. Compilar o Projeto
```bash
dotnet build
```

### 5. Executar a Aplicação
```bash
dotnet run
```

Ou use o VS Code com as tasks configuradas:
- `Ctrl+Shift+P` → `Tasks: Run Task` → `build` (para compilar)
- `Ctrl+Shift+P` → `Tasks: Run Task` → `watch` (para executar com hot reload)

### 6. Acessar a Aplicação
Abra o navegador e acesse: `https://localhost:5001` ou `http://localhost:5000`

## 📱 Funcionalidades

### Plano de Contas
- ✅ Listar planos de conta
- ✅ Cadastrar novo plano de conta
- ✅ Editar plano de conta existente
- ✅ Excluir plano de conta

### Transações
- ✅ Listar transações
- ✅ Cadastrar nova transação
- ✅ Editar transação existente
- ✅ Excluir transação
- ✅ Associar transação ao plano de conta

## 📊 Estrutura do Banco de Dados

### Tabela: planoconta
| Campo | Tipo | Descrição |
|-------|------|-----------|
| id | int (PK) | Identificador único |
| nome | varchar(50) | Nome do plano de conta |
| tipo | char(1) | Tipo da conta (R-Receita, D-Despesa) |

### Tabela: transacao
| Campo | Tipo | Descrição |
|-------|------|-----------|
| id | int (PK) | Identificador único |
| historico | varchar(200) | Descrição da transação |
| data | datetime | Data da transação |
| valor | decimal(18,2) | Valor da transação |
| planoconta_id | int (FK) | Referência ao plano de conta |

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 👨‍💻 Autor

Desenvolvido como projeto educacional utilizando ASP.NET Core 9.0

---

**Nota**: Este projeto foi desenvolvido para fins educacionais e demonstração das tecnologias ASP.NET Core, Entity Framework e SQL Server.