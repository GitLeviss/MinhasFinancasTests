export class TransacoesData {
    static readonly transacaoValida = {
        descricao: 'Transação Teste Automatizado ' + Math.floor(Math.random() * 9999),
        valor: '100.00',
        dataTransacao: new Date().toISOString().split('T')[0],
        tipoDespesa: 'despesa',
        tipoReceita: 'receita',
        pessoa: 'Pessoa Teste',
        pessoaMenor: 'Teste Menor Idade',
        categoriaReceita: 'Salário',
        categoriaDespesa: 'Alimentação'
    };

}
