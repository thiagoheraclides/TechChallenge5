# TechChallenge5

Instruções de build.

## Arquitetura do portal de investimento
![TechChallenge5 (1)](https://github.com/user-attachments/assets/9785952d-ccff-4847-aa32-e2b394396c1a)



## Banco de dados

Este projeto foi criado usando banco de dados MS-SQL Server.
A solução está configurada para criar e gerar o banco de dados ao iniciar a aplicação. Para isto basta apenas alterar no arquivo appsettings.json, a propriedade ConnectionStrings, item Default, com as configurações relativas ao seu ambiente.

"ConnectionStrings": {
  "Default": "Data Source=**servidor ms sql**;Initial Catalog=**banco de dados**;User ID=**usuário**;Password=**senha**;TrustServerCertificate=true;" 
}

## API

Projeto criado utilizando .NET 8.

## Testes
Os testes estão disponibilizados na Solution do projeto, em parte apartada aos binários da API.

## Observações Complementares

Utilizamos swagger para documentação dos métodos disponibilizados na API.

## Critérios de aceite

- Criar a API de cadastro de usuário para validar as documentações e confirmar via e-mail processo finalizado.
- **Criar a API para acompanhar ativos de investimentos**.
A API será composta de:
  - Pesquisar: Apresentar todos os **ativos** em andamentos ou contratados pelo usuário;
  - Contratar: Usuário enviar ordem e realizar a contratação.
  - Resgatar: O Sistema permitirá resgatar os ativos;
  - Pagamento: O Sistema permitirá acompanhar os aportes e realizar agendamento de compras de ativos;

