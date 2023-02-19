# BaseApp

![.NET Core](https://img.shields.io/badge/dotnet%20version-net6.0-blue)  
[![codecov](https://codecov.io/gh/slipalison/BaseApp/branch/main/graph/badge.svg?token=oEv1sNpdD0)](https://codecov.io/gh/slipalison/BaseApp)  
[![.NET](https://github.com/slipalison/BaseApp/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/slipalison/BaseApp/actions/workflows/dotnet.yml)

## Como funciona❓❔❓
Aplicação para demonstração de aplicação asp.net com .net core 6.0.
Na solução você encontrar divisão de camadas respeitando o DDD, para projeto simples.
Para subir a aplicação basta executar o comando a baixo na pasta raiz do projeto, e acessar http://localhost:8080/swagger no seu navegador.
```  
docker-compose up  
```  
O docker-compose, irá subir um sql server, e uma Web API. A aplicação irá criar o banco e popular a tabela.

## A API

A API foi construída para atender 2 telas web:

1. Uma tela que lista as contas cadastradas
2. Uma tela para cadastrar uma conta nova

O cadastro deve respeitar essa logica:
- A conta que aceita lançamentos não pode ter contas filhas;
- A conta que não aceita lançamentos pode ser pai de outras contas;
- Os códigos não podem se repetir;
- As contas devem obrigatoriamente ser do mesmo tipo do seu pai (quando este existir);
- Deve-se permitir que o usuário inclua uma conta de código "1.2.9", filha da "1.2", mesmo que a maior filha dela seja a "1.2.3"
- Este serviço será chamado pelo frontend no momento da inclusão de uma conta quando o usuário selecionar a Conta Pai;
- Para o cenário em que o usuário está criando uma conta filha da conta “2.2”, a API deve sugerir o código “2.2.8” se a maior filha já cadastrada for a “2.2.7”. (Sempre use a lógica do maior + 1);
- O maior código possível é “999” independente do nível que você está. Então o código “1.2.999” é um código válido e “1.2.1000” não;
- Se a conta “1.2.999” já existe e a API foi chamada para sugerir o próximo código para o pai “1.2”ela deve:
    - Retornar que o pai agora deve ser o “1”;
    - Retornar o código do próximo filho deste novo pai.
- Se atente para criar uma lógica que consiga sugerir o novo pai "9" com o próximo filho "9.11" caso você tente buscar um código para o pai “9.999” em um plano de contas que já tenha os seguintes registros:


| Codigo | Nome |
|--|--|
| 9.9.998 | Conta x |
| 9.9.999 | Conta y |
| 9.10 | Conta z |


### O que encontrar dentro da API

Foi construídas 3 rotas:

- Uma rota GET para listar todos os cadastros da base.
- Uma Rota GET que retorna todas as Categorias, subcategorias e também da uma sugestão do proximo codigo viável.
- Uma rota para criar a conta, onde o codigo pode ser alterado independente do proximo codigo de sugestão.






## Cobertura Sunburst
![Grid](https://codecov.io/gh/slipalison/BaseApp/branch/main/graphs/sunburst.svg?token=oEv1sNpdD0)