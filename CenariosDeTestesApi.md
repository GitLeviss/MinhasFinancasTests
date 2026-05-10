Minhas Finanças

Responsável: Levi Alves

Objetivo: Este documento tem como objetivo documentar detalhadamente os casos e cenários de testes encontrados para a aplicação Minhas Finanças.


Nivel de Teste: API


Feature : Pessoas

CT01 – Deve Retornar Status 201 ao cadastrar pessoa


- Enviar requisição POST para “/api/v1/Pessoas” com o seguinte payload:

{

"dataNascimento": "2003-01-01",

"nome": "Pessoa Cadastro Postman"

}

Status: OK


CT02 – Deve Retornar Status 204 ao editar pessoa existente


- Enviar requisição PUT para “/api/v1/Pessoas/{id}” com o seguinte payload:

{

"dataNascimento": "2000-11-11",

"nome": "Pessoa Postman Editado"

}

Status: OK




CT03 – Deve Retornar Status 200 e dados da pessoa ao consultar pessoa pelo id


- Enviar requisição GET para “/api/v1/Pessoas/{id}” com id de pessoa existente

Status: OK


CT04 – Deve Retornar Status 200 e todas da pessoa ao consultar pessoas


- Enviar requisição GET para “/api/v1/Pessoas”

Status: OK



CT05 – Deve Retornar Status 204 ao excluir pessoa existente


- Enviar requisição DELETE para “/api/v1/Pessoas/{id}” com id de pessoa existente

Status: OK


CT06 – Deve Retornar Status 404 ao tentar cadastrar com data de nasc. inválida


- Enviar requisição POST para “/api/v1/Pessoas” com o seguinte payload:

{

"dataNascimento": "2003-13-13",

"nome": "Pessoa data invalida Postman"

}

Status: OK



CT07 – Deve Deletar Transações existentes quando pessoa vinculada for deletada


Dado que estou na página de pessoas

Quando clico em “Excluir” pessoa existente

E clico em “confirmar”  no modal de confirmação

Então Sistema deve remover pessoa excluída na tabela.

E deletar transações vinculadas a pessoa

Status: OK





Feature : Categorias


CT01 – Deve Retornar Status 201 ao cadastrar categoria


- Enviar requisição POST para “/api/v1/Pessoas” com o seguinte payload:

{

"descricao": "Postman Ambas",

"finalidade": 2

}

Ou

{

"descricao": "Postman Receita",

"finalidade": 1

}

Ou

{

"descricao": "Postman Despesa",

"finalidade": 0

}

Status: OK


CT02 - Deve Retornar Status 200 e quantidade de categorias conforme quantidades de paginas enviadas na requisição

- Enviar requisição GET para “/api/v1/Categorias?page=1&pageSize=5”

Status: OK


Feature : Transações


CT01 – Deve retornar status 201 ao cadastrar transação do tipo receita para categoria receita


Enviar Requisição POST para “/api/v1/Transacoes” com o seguinte payload:

{

"categoriaId": "{idCategoria}",

"data": "{dateTime.Now}",

"descricao": "Transação Teste Via Postman",

"pessoaId": "{idPessoaValido}",

"tipo": 1, -- Despesa, receita ou ambas

"valor": 200.00

}


Status: OK



CT02 – Deve Retornar status 500 e mensagem de erro “Não é possível registrar receita em categoria de despesa.” ao tentar cadastrar transação do tipo despesa em categoria de receita.

Enviar Requisição POST para “/api/v1/Transacoes” com o seguinte payload:

{

"categoriaId": "{idCategoria}", //Categoria deve ser

"data": "{dateTime.Now}",

"descricao": "Transação Teste Via Postman",

"pessoaId": "{idPessoaValido}",

"tipo": 1, -- Despesa, receita ou ambas

"valor": 200.00

}

Status: OK


CT02 – Deve Retornar status 500 e mensagem de erro “Não é possível registrar despesa em categoria de receita.” ao tentar cadastrar transação do tipo despesa em categoria de receita

Enviar Requisição POST para “/api/v1/Transacoes” com o seguinte payload:

{

"categoriaId": "{idCategoria}", //Categoria deve ser

"data": "{dateTime.Now}",

"descricao": "Transação Teste Via Postman",

"pessoaId": "{idPessoaValido}",

"tipo": 1, -- Despesa, receita ou ambas

"valor": 200.00

}

Status: OK


CT04 – Deve retornar status 201 ao cadastrar transação do tipo receita para categoria ambas


Enviar requisição POST para “/api/v1/Transacoes” com o seguinte payload:

{

"categoriaId": "{idCategoria}", //Categoria deve ser tipo tipo receita

"data": "1984-03-18T15:08:40.395Z",

"descricao": "Transação Teste ambas Postman",

"pessoaId": "{idPessoa}",

"tipo": 2, //categoria deve ser ambas

"valor": 200.00

}



Status: OK


CT05 – Deve retornar status 500 e mensagem de erro “Não é possível registrar despesa em categoria de receita.” Quando tentar cadastrar transação com pessoa tendo menos que 18 anos


Enviar requisição POST para “/api/v1/Transacoes” com o seguinte payload:

{

"categoriaId": "{idCategoria}", //Categoria deve ser receita

"data": "1984-03-18T15:08:40.395Z",

"descricao": "Teste receita menor de idade",

"pessoaId": "{idPessoa}", //Deve possuir menos de 18 anos de idade

"tipo": 0,

"valor": 200.00

}


Status: OK


Feature : Dashboard


CT01- Deve retornar status 200 ao consultar todas as transações e trazer array contendo todas  transações.

Enviar requisição GET para “/api/v1/Transacoes?page=1&pageSize=20”

Status: OK


CT02- Deve retornar status 200 ao consultar transação por id e traze dados da transação.

Enviar requisição GET para “/api/v1/Transacoes/{id}”

Status: OK



Feature : Relatórios


CT01- Deve retornar status 200 e array de total de transações por despesas ao consultar total por pessoa


Enviar requisição GET para “/api/v1/Totais/pessoas?Pessoa.Id={idPessoa}&page=1&pageSize=8”


Status: OK

