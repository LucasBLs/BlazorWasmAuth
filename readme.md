# BlazorWasmAuth

![C#](https://img.shields.io/badge/C%23-12.0-purple?style=for-the-badge&logo=c-sharp)
![Blazor](https://img.shields.io/badge/Blazor-WASM-blueviolet?style=for-the-badge&logo=blazor)
![MudBlazor](https://img.shields.io/badge/MudBlazor-6.0.5-blue?style=for-the-badge&logo=mudblazor)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-success?style=for-the-badge&logo=nuget)
![Oracle](https://img.shields.io/badge/Oracle-19-red?style=for-the-badge&logo=oracle)
![MIT License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge&logo=mit)

## Descrição

BlazorWasmAuth é um projeto de estudo baseado em um curso, desenvolvido utilizando Blazor WebAssembly, .NET 8.0.6, e MudBlazor para componentes visuais. Este projeto tem como objetivo explorar autenticação e autorização em aplicações Blazor WASM, com integração ao Entity Framework Core e Oracle 19.

## Requisitos

- [.NET 8.0.6 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Oracle Database 19c](https://www.oracle.com/database/technologies/)

## Instalação

1. Clone o repositório:

    ```sh
    git clone https://github.com/LucasBLs/BlazorWasmAuth.git
    cd BlazorWasmAuth
    ```

2. Configure a string de conexão com o Oracle e URLs de frontend e backend no arquivo `appsettings.json` da API:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = exampleService)));Persist Security Info=True;User ID=username;Password=passwrod;Pooling=True;Connection Timeout=60;"
      },
      "FrontendUrl": "http://localhost:5194",
      "BackendUrl": "http://localhost:5253"
    }
    ```

3. Configure o URL do backend no arquivo `appsettings.json` do wwwroot:

    ```json
    {
      "BackendUrl": "http://localhost:5253"
    }
    ```

4. Execute as migrações do Entity Framework para criar o banco de dados:

    ```sh
    dotnet ef database update --project BlazorWasmAuth.Api
    ```

5. Execute o projeto:

    ```sh
    dotnet run --project BlazorWasmAuth.Api
    ```

## Uso

Após iniciar a aplicação, você pode acessar a interface Blazor WebAssembly e explorar as funcionalidades de autenticação e autorização.

## Observação

Para permitir o funcionamento correto do frontend Blazor WebAssembly e o backend ASP.NET Core, é necessário configurar o CORS no backend. Certifique-se de adicionar a configuração correta no método `AddCrossOrigin` da classe `BuilderExtension.cs` e utilizar o CORS no pipeline de requisição no `Program.cs`.

A autenticação da API utiliza o novo mapeamento de endpoints do Identity, que gera automaticamente os endpoints necessários. Para mais informações, consulte a [documentação oficial](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-8.0).

## Estrutura do Projeto

- **BlazorWasmAuth.Web**: Contém o projeto Blazor WebAssembly.
- **BlazorWasmAuth.Api**: Contém a API ASP.NET Core e a lógica de autenticação.
- **BlazorWasmAuth.Core**: Contém os modelos compartilhados entre o cliente e o servidor.

## Tecnologias Utilizadas

- **Blazor WebAssembly**: Framework para desenvolvimento de SPA com C#.
- **MudBlazor**: Biblioteca de componentes UI para Blazor.
- **Entity Framework Core**: ORM para acesso a dados.
- **Oracle 19**: Banco de dados relacional.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
