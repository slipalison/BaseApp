# BaseApp

![.NET Core](https://img.shields.io/badge/dotnet%20version-net6.0-blue)    
[![codecov](https://codecov.io/gh/slipalison/BaseApp/branch/main/graph/badge.svg?token=oEv1sNpdD0)](https://codecov.io/gh/slipalison/BaseApp)    
[![.NET](https://github.com/slipalison/BaseApp/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/slipalison/BaseApp/actions/workflows/dotnet.yml)

## Como funciona❓❔❓
Aplicação para demonstração de aplicação asp.net com .net core 6.0.  
Na solução você encontrar divisão de camadas respeitando o DDD, para projeto simples.  
Para subir a aplicação basta executar o comando a baixo na pasta raiz do projeto, e acessar http://localhost:8080/swagger no seu navegador.  
``` docker-compose up ``` O docker-compose, irá subir um sql server, e uma Web API. A aplicação irá criar o banco e popular a tabela.

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
- Uma Rota GET que retorna todas as Categorias, subcategorias que seja possivel a criação de uma conta filha, e também da uma sugestão do proximo codigo viável.
- Uma rota para criar a conta, onde o codigo pode ser alterado independente do proximo codigo de sugestão.


# ❕❗❕ Pontos importantes ❕❗❕

> Eu fiz o código pensando em  limitar em 3 camadas "xxx,xxx,xxx", pensando em Categoria, Subcategoria e Item, não foi contemplado Subitem  em diante. Com isso gera uma complexidade maior por conta da limitação.
O código foi montado pensando em Logica e organização, e não em performance. Pois para performance nos temos um problema de sobrecarga de funcionalidade, por isso traz mais complexidade no código fazendo usar métodos recursivos.
Se padronizar a regra dessa forma "Todos Itens devem  estar atrelado a uma subcategoria, e a subcategoria deve estar associada a uma categoria".  Com isso podemos criar uma tabela em base para Categoria, Subcategoria e Itens, e com isso podemos ignorar o fator humano do usuário, tirando essa opção de escolher um código X. Ao meu ver a experiência seria mais amigável para o usuário final  pois o mesmo não precisaria se preocupar com essas informações.
Você tira toda a complexidade de código, irá ter mais velocidade (pensando isso em senário produtivo, onde tenha muitas chamadas para essa funcionalidade), sem falar que irá ter um custo menor de servidor.
O problema do negocio em si, é que a Categoria e Subcategorias podem ter comportamento de Item. Olhando o SOLID, CLEAN CODE/Architecture é muito importante deixar que cada coisa tenha apenas um comportamento, para facilita a manutenção.
Claro que, toda essa logica cai por terra caso o usuário final enxergue valor nessa função de escolher o código  do item cadastrado.


## Além 👌
> Foi criado uma web api simples usando apenas SQL Server. Mesmo assim, o código esta com cobertura de código como pode notar aqui: [![codecov](https://codecov.io/gh/slipalison/BaseApp/branch/main/graph/badge.svg?token=oEv1sNpdD0)](https://codecov.io/gh/slipalison/BaseApp), além disso foi criado uma pipeline para executar os testes automaticamente.
Foi criado teste unitários de Domínio, e testes integrados, passando o testes desde a requisição até o banco.  
Mesmo a aplicação sendo simples, podemos notar que existe padronização de respostas, esta preparado para logs para ser usado em ELK.
Todas as respostas estão com compressão para deixar o payload de resposta menor e com isso mais rápido para a ponta.



## Cobertura Sunburst
![Grid](https://codecov.io/gh/slipalison/BaseApp/branch/main/graphs/sunburst.svg?token=oEv1sNpdD0)