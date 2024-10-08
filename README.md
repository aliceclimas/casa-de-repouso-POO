# Casa de Repouso 🏠
Este projeto é uma aplicação web para ajudar casas de repouso a terem um gerenciamento mais eficiente. Suas principais funcionalidades são cadastro de moradores do local e suas alas, funcionários (continuar escrevendo)

Projeto interdisciplinar desenvolvido para a disciplina Programação Orientada a Objetos.

## 💻 Requisitos
- Autenticação, autorização e registro;
- Cadastros básicos (CRUDs contendo relacionamentos de 1:1 e 1:N);
- Relacionamento de N:N (formulários ou relatórios);
- Pesquisas e filtros nos dados;

## ⚙️ Atualizações que poderiam ser feitas
- Validação do CPF
- Deixar todos os campos obrigatórios antes de enviar para o banco sem dar erro

# Banco de Dados
O digrama **entidade-relacionamento** do banco de dados é o seguinte:
<div align="center">
  <img src="https://github.com/user-attachments/assets/6fe2fad3-52de-4b77-9902-68ee36389966"/>
</div>

## Criar o Banco de Dados
Para criar o banco de dados rode a seguinte migração no terminal:
```
dotnet ef migrations add InitialCreate
```
E em seguida rode no terminal:
```
dotnet ef database update
```
