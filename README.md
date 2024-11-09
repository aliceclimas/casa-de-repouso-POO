# Serene 🏠
O Serene é um projeto de aplicação web desenvolvida para otimizar a organização e o gerenciamento em casas de repouso. o sistema centraliza informações importantes sobre os idosos, seus responsáveis e a equipe de funcionárias, proporcionando um ambiente eficiente e seguro para monitorar o dia a dia e facilitar a comunicação entre a equipe.

Projeto interdisciplinar desenvolvido para a disciplina Programação Orientada a Objetos.

## 💻 Requisitos
- Autenticação, autorização e registro;
- Cadastros básicos (CRUDs contendo relacionamentos de 1:1 e 1:N);
- Relacionamento de N:N (formulários ou relatórios);
- Pesquisas e filtros nos dados;

## 🔍 Visão Geral do Projeto
Serene permite o registro e a visualização de:
- <b>Idosos:</b> Armazena dados pessoais e de saúde para acompanhamento e cuidados personalizados.
- <b>Responsáveis:</b> Cadastra informações de contato e endereço, facilitando assim a comunicação em casos de necessidade.
- <b>Funcionárias</b>: Organiza a equipe, registrando informações das cuidadoras e suas respectivas alas de trabalho.
- <b>Alas:</b> Separa os idosos por alas para melhor organização e controle.
- <b>Medicações:</b> Controla o histórico de medicações dos idosos, facilitando o trabalho das cuidadoras.
- <b>Relatórios Diários:</b> Registra eventos e observações diárias para que a equipe esteja sempre informada sobre o andamento e as necessidades de cada idoso.

## 📄 Tecnologias Usadas
- C#
- Razor
- SQL
- Framework MVC
- Bootstrap


dotnet ef migrations add InitialCreate
dotnet ef database update