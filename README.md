# ControleEstoque

Projeto desenvolvido em **C#** para controle de movimentações de estoque, permitindo registrar entradas e saídas de mercadorias e consultar a quantidade final disponível de cada produto.

O projeto utiliza **Programação Orientada a Objetos (POO)** e **testes unitários com xUnit** para garantir o correto funcionamento das regras de negócio.

## 📋 Sobre o projeto

O sistema permite realizar movimentações de estoque dos produtos cadastrados a partir dos dados fornecidos em JSON.

Cada movimentação possui:

* Um número identificador único;
* Uma descrição para identificar o tipo da movimentação realizada;
* O produto movimentado;
* A quantidade movimentada;
* O tipo da movimentação, podendo ser **entrada** ou **saída**.

Ao finalizar uma movimentação, o sistema calcula e apresenta a **quantidade final disponível em estoque** para o produto movimentado.

## ⚙️ Funcionalidades

* Cadastro e identificação dos produtos;
* Registro de movimentações de estoque;
* Entrada de mercadorias;
* Saída de mercadorias;
* Identificação única de cada movimentação;
* Descrição do tipo de movimentação;
* Atualização da quantidade em estoque;
* Consulta da quantidade final do produto movimentado;
* Validação das regras de negócio por meio de testes unitários.

## 🛠️ Tecnologias utilizadas

* C#
* .NET
* Programação Orientada a Objetos (POO)
* xUnit
* Testes unitários
* JSON

```

## 🚀 Como executar o projeto

### 1. Clone o repositório

Clone o projeto utilizando:

```bash
git clone URL_DO_REPOSITORIO
```

Depois, entre na pasta do projeto:

```bash
cd DesafioTarget2
```

### 2. Execute a aplicação

Entre na pasta `ControleEstoque`:

```bash
cd ControleEstoque
```

Execute o projeto com:

```bash
dotnet run
```

A aplicação será compilada e executada diretamente pelo terminal.

## 🧪 Como executar os testes

Para executar os testes unitários, entre na pasta:

```bash
cd ControleEstoque.Tests
```

Execute:

```bash
dotnet test
```

O comando irá compilar o projeto de testes e executar todos os testes automatizados utilizando **xUnit**.

## ✅ Testes unitários

Os testes automatizados têm como objetivo validar as principais regras do controle de estoque, incluindo:

* Registro de movimentações de entrada;
* Registro de movimentações de saída;
* Atualização da quantidade do estoque;
* Cálculo da quantidade final após uma entrada;
* Cálculo da quantidade final após uma saída;
* Identificação única das movimentações;
* Validação do produto movimentado;
* Validação das regras de negócio relacionadas às movimentações.

## 📦 Movimentações de estoque

As movimentações podem ser classificadas em:

### Entrada

Representa o recebimento de mercadorias no depósito.

Exemplo:

```text
Estoque atual: 100
Entrada: +20
Estoque final: 120
```

### Saída

Representa a retirada de mercadorias do depósito.

Exemplo:

```text
Estoque atual: 100
Saída: -30
Estoque final: 70
```

## 🎯 Objetivo

O objetivo do projeto é desenvolver uma solução em **C#** capaz de controlar movimentações de estoque de forma organizada e confiável, aplicando conceitos de **Programação Orientada a Objetos**, separação de responsabilidades e **testes unitários automatizados**.

A aplicação busca garantir que as movimentações sejam corretamente registradas e que o estoque final dos produtos seja atualizado de acordo com as entradas e saídas realizadas.

## 👩‍💻 Execução rápida

### Aplicação

```bash
cd ControleEstoque
dotnet run
```

### Testes

```bash
cd ControleEstoque.Tests
dotnet test
```
