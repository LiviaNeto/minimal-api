# API de Registro de Veículos com Minimal APIs e JWT

Este repositório contém uma API desenvolvida utilizando Minimal APIs no .NET, permitindo o registro e gerenciamento de veículos, juntamente com a gestão de administradores por meio de autenticação JWT. A API oferece funcionalidades para criar, listar, atualizar e excluir veículos, além de permitir autenticação de administradores com permissões baseadas em JWT.

## Funcionalidades

- **Cadastro de Veículos:** Registra novos veículos.
- **Listagem de Veículos:** Exibe todos os veículos cadastrados, com suporte a paginação.
- **Pesquisa de Veículo po Id:** Consulta os dados de um veículo específico.
- **Atualização de Veículos:** Permite a atualização de informações de veículos existentes.
- **Exclusão de Veículos:** Exclui veículos do registro.
- **Administração com Autenticação JWT:** Gerencia administradores com autenticação JWT, oferecendo permissões específicas para operações de CRUD (Criar, Ler, Atualizar, Excluir).

## Tecnologias Utilizadas

- **.NET 6/7:** Framework de desenvolvimento utilizado para a construção da API.
- **Minimal APIs:** Abordagem para a construção de APIs com configuração simplificada.
- **JWT (JSON Web Token):** Para autenticação e autorização de administradores.
- **Swagger:** Ferramenta para documentação e testes interativos da API.
- **Entity Framework Core:** ORM utilizado para o gerenciamento de banco de dados.
- **Banco de Dados MySql:** Para o armazenamento de dados de veículos e administradores.
- **MSTest:** Framework utilizado para escrever testes automatizados para garantir a confiabilidade da API.
