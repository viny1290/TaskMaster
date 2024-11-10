# TaskMaster - Gerenciamento de Tarefas e Reuniões

O **TaskMaster** é um sistema de gerenciamento de tarefas e reuniões desenvolvido em C#. O sistema permite que usuários com diferentes níveis de acesso (junior, pleno, sênior) gerenciem suas tarefas e reuniões, com funcionalidades para enviar tarefas para revisão, alterar senhas, e visualizar reuniões marcadas.

## Funcionalidades

- **Login e autenticação de usuários**: Usuários podem fazer login com seu nome e senha.
- **Gerenciamento de tarefas**: Dependendo do cargo do usuário, ele pode ver suas tarefas, enviar tarefas para revisão e fazer alterações nas mesmas.
- **Gerenciamento de reuniões**: Os usuários podem visualizar, adicionar e remover reuniões.
- **Alteração de senha**: Usuários podem alterar suas senhas de acesso.

## Estrutura do Código

### 1. **MenuLoginIn.cs**
   O `MenuLoginIn.cs` é responsável pela tela de login e autenticação do usuário. Ele valida as credenciais inseridas e direciona o usuário para o menu correspondente ao seu cargo.

### 2. **MenuAuthentication.cs**
   O `MenuAuthentication.cs` lida com a lógica de interação do usuário após o login. Ele permite visualizar e gerenciar tarefas e reuniões, dependendo do cargo do usuário.

### 3. **User.cs**
   A classe `User.cs` define as propriedades e comportamentos de um usuário, como nome, senha, cargo e tipo. Ela também gerencia as reuniões e tarefas atribuídas ao usuário.

### 4. **Meeting.cs**
   O `Meeting.cs` define as propriedades de uma reunião, como nome, data e descrição, e inclui métodos para adicionar, visualizar e excluir reuniões.

### 5. **Notice.cs**
   A classe `Notice.cs` define tarefas, contendo nome, prazo e grupo responsável, além de métodos para gerenciar o status e o envio de tarefas para revisão.

# Como Usar

Login: Ao executar o projeto, o usuário será solicitado a inserir seu nome e senha para acessar o sistema.

Menu Principal: Após o login, o sistema exibirá um menu com as opções disponíveis de acordo com o cargo do usuário:

Usuário Júnior pode ver suas reuniões e atualizar tarefas.

Usuário Pleno pode, além das funcionalidades do Júnior, criar e excluir reuniões.

Usuário Sênior pode, além das funcionalidades do Pleno, criar e excluir usuários, e enviar tarefas para revisão.
Gerenciamento de Reuniões:

O usuário pode visualizar suas reuniões agendadas e adicionar novas reuniões.
Reuniões passadas são removidas automaticamente.

Alteração de Senha:

O usuário pode alterar sua senha após fornecer a senha atual correta.

Estrutura de Arquivos

Menus/

MenuLoginIn.cs: Lida com o login e autenticação do usuário.

MenuAuthentication.cs: Lida com a interação do usuário após o login, incluindo gerenciamento de tarefas e reuniões.

Models/

User.cs: Representa um usuário no sistema e gerencia suas reuniões e tarefas.

Meeting.cs: Define a estrutura de uma reunião.

Notice.cs: Define a estrutura de uma tarefa e seu status.

Tecnologias Usadas

C#: Linguagem principal para o desenvolvimento do sistema.

.NET Core: Plataforma de desenvolvimento para a criação do console application.

Visual Studio Code: Editor de código utilizado no desenvolvimento.

Desenvolvido por Vinícius de Vasconcelos Nascimento.

### Descrição do `README`:

1. **Introdução**: Uma breve descrição sobre o propósito do sistema `TaskMaster`.
2. **Funcionalidades**: Detalhes sobre as funcionalidades oferecidas pelo sistema.
3. **Estrutura do Código**: Explica a estrutura das principais classes do sistema (`MenuLoginIn.cs`, `MenuAuthentication.cs`, `User.cs`, `Meeting.cs`, `Notice.cs`).
4. **Execução**: Passo a passo sobre como executar o projeto.
5. **Como Usar**: Orientações sobre como utilizar as funcionalidades principais do sistema.
6. **Estrutura de Arquivos**: Detalhes sobre a organização do código no repositório.
7. **Tecnologias Usadas**: Lista das tecnologias e ferramentas utilizadas.
