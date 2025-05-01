## Sobre o projeto

O **Sistema de Banco de Dados de Doação de Sangue** é uma API desenvolvida com **ASP.NET Core 8**, projetada para gerenciar doações de sangue de forma eficiente e organizada. A aplicação utiliza o **FluentValidation** para garantir a integridade dos dados recebidos nas requisições.

A arquitetura foi construída em camadas bem definidas, promovendo a separação de responsabilidades, o que facilita a manutenção, testes e escalabilidade do sistema. Para garantir o baixo acoplamento entre as classes, foi adotada a **injeção de dependência** por meio de interfaces.

O banco de dados utilizado é o **SQL Server**, com mapeamento realizado via **Entity Framework Core**. Os testes de unidade foram implementados com a biblioteca **xUnit**, utilizando também o **FluentAssertions** para tornar as asserções mais legíveis e expressivas.

Além disso, foram aplicados princípios de **Clean Code**, contribuindo para a clareza e legibilidade do código, com foco em nomes significativos e estruturação limpa.
### Funcionalidades principais

- **Casastro de Doadores**: Permite registrar doadores com validações como idade mínima, peso adequado e e-mail único.
- **Consulta de Endereço via CEP**: Integração com API externa para preenchimento automático de endereço a partir do CEP informado.
- **Devolução de um livro**: Essa funcionalidade permite manter o controle entre a data que foi feito o empréstimo do livro e a data em que ele foi devolvido. Para isso, uma mensagem é exibida, dizendo se a devolução está em atraso ou se está em dias.
- **Controle de Estoque Sanguíneo**: Monitora os níveis de sangue por tipo, emitindo alertas quando o estoque atinge o mínimo necessário.
- **Histórico de Doações**: Permite consultar as doações feitas por cada doador, promovendo um acompanhamento individual. 

### Padrões e Práticas Utilizadas

- **CQRS (Command Query Responsibility Segregation)**
  
- **MediatR** para centralizar a comunicação entre comandos e manipuladores.

- **Result Pattern** para retornar respostas unificadas (sucesso ou falha) com mensagens e códigos de status adequados.

- **Repository Pattern** para isolar a lógica de persistência de dados.

- **Clean Architecture** com divisão em camadas: API, Application, Core, Infra e Tests.



### Requisitos

- Visual Studio versão 2022+ ou Visual Studio Code
- Windows 10+ ou Linux/MacOS com [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) instalado
- SQL Server

### Construído com

![.NET Badge](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge)  ![badge-windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white) ![visual-studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white) ![badge-sqlserver](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

![badge-swagger](http://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge)  

## Começando

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

- Visual Studio versão 2022+ ou Visual Studio Code
- Windows 10+ ou Linux/MacOS com [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) instalado
- Sql Server

### Instalação

1. Clone o repositório:
    ```sh
    git clone git@github.com:benicio227/BloodDonationSystem.git
    ```

2. Preencha as informações no arquivo `appsettings.json`
3. Execute a API
