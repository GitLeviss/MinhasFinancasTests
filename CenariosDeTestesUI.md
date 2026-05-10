Minhas Finanças

Responsável: Levi Alves

Objetivo: Este documento tem como objetivo documentar detalhadamente os casos e cenários de testes encontrados para a aplicação Minhas Finanças.


Nivel de Teste: UI


Feature : Pessoas

CT01 – Deve Cadastrar uma Pessoa Com sucesso


Dado que estou na página de pessoas

Quando clico em “Adicionar Pessoas”

E Preencho formulário de registro

Então Sistema deve exibir pessoa cadastrada na tabela.

Status: OK


CT02 – Deve editar pessoa existente


Dado que estou na página de pessoas

Quando clico em “Editar” da pessoa existente

E Preencho formulário de edição

Então Sistema deve exibir pessoa com novos dados na tabela.

Status: OK


CT03 – Deve Deletar Pessoa existente


Dado que estou na página de pessoas

Quando clico em “Excluir” pessoa existente

E clico em “confirmar”  no modal de confirmação

Então Sistema deve remover pessoa excluída na tabela.

Status: OK


CT04 – Não Deve Cadastrar Pessoa com data de nascimento inválida


Dado que estou na página de pessoas

Quando clico em “Adicionar Pessoas”

E Preencho formulário de registro inserindo data inválida

E Clico em “Salvar”

Então Sistema deve exibir mensagem de erro indicando data de nascimento inválida.

Status: FALHOU


CT05 – Não Deve Cadastrar Pessoa com nome com caracteres especiais


Dado que estou na página de pessoas

Quando clico em “Adicionar Pessoas”

E Preencho formulário de registro inserindo nome com caracteres especiais

E Clico em “Salvar”

Então Sistema deve exibir mensagem de erro indicando nome inválido.

Status: FALHOU



CT06 – Deve Deletar Transações existentes quando pessoa vinculada for deletada


Dado que estou na página de pessoas

Quando clico em “Excluir” pessoa existente

E clico em “confirmar”  no modal de confirmação

Então Sistema deve remover pessoa excluída na tabela.

E deletar transações vinculadas a pessoa

Status: OK





Feature : Categorias


CT01 - Deve Cadastrar nova Categoria com sucesso


Dado que estou na página de Categorias

Quando clico em “Adicionar Categoria”

E Preencho formulário de categoria valida

E Clico em “Salvar”

Então Sistema deve exibir mensagem de sucesso “Categoria salva com sucesso!”

E exibir categoria na tela em tempo de execução.

Status: OK


CT02 - Deve Exibir Categorias páginadas com sucesso


Dado que estou na página de Categorias

Quando tenho mais de 8 categorias cadastradas

E clico na opção de 2° página

Então Sistema deve exibir próximas categorias na tela.

Status: OK


Feature : Transações


CT01 – Deve cadastrar transação do tipo receita em categoria de receita.


Dado que estou na página de transações

Quando clico em “Adicionar Transação”

E preencho formulário com dados válidos

E Clico em “Salvar”

Então sistema deve exibir mensagem de sucesso “Transação salva com sucesso!”

E exibir transação na tela em tempo de execução.

Status: OK



CT02 – Não Deve cadastrar transação do tipo despesa em categoria de receita.


Dado que estou na página de transações

Quando clico em “Adicionar Transação”

E preencho formulário com tipo “Despesa” e categoria “Receita”

E Clico em “Salvar”

Então sistema deve exibir mensagem de sucesso “Erro ao salvar transação. Tente novamente.”

Status: OK


CT03 – Não Deve cadastrar transação do tipo receita em categoria de despesa.


Dado que estou na página de transações

Quando clico em “Adicionar Transação”

E preencho formulário com tipo “Despesa” e categoria “Receita”

E Clico em “Salvar”

Então sistema deve exibir mensagem de sucesso “Erro ao salvar transação. Tente novamente.”

Status: OK


CT04 – Deve cadastrar transação do tipo receita em categoria de ambas


Dado que estou na página de transações

Quando clico em “Adicionar Transação”

E preencho formulário com dados válidos

E Clico em “Salvar”

Então sistema deve exibir mensagem de sucesso “Transação salva com sucesso!”

E exibir transação na tela em tempo de execução.

Status: OK


CT05 – Não Deve cadastrar transação do tipo receita quando pessoa tiver menos de 18 anos de idade.


Dado que estou na página de transações

Quando clico em “Adicionar Transação”

E preencho formulário com dados válidos, e vinculo a uma pessoa menor de idade

E Clico em “Salvar”

Então sistema deve exibir mensagem de sucesso “Menores de 18 anos não podem registrar receitas.”

Status: OK


Feature : Dashboard


CT01- Deve Exibir fluxo de transações corretamente e cards condizentes com fluxo


Dado que tenho transações de receitas e despesas realizadas

Quando navego ate a página de dashboard

Então sistema deve exibir cards e ultimas transações corretamente de acordo movimentações feitas pelo usuário

Status: OK


Feature : Relatórios


CT01- Deve Exibir relatório por pessoa corretamente


Dado que tenho movimentações realizadas

Quando navego ate a página de relatórios

Então sistema deve exibir tabela contendo nome, total receitas, total despeas e saldo atual da pessoa.

Status: OK

