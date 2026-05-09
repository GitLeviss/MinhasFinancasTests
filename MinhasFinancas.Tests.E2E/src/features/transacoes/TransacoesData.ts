export class TransacoesData {
    static readonly transacaoValida = {
        descricao: 'Transação Teste Automatizado ' + Math.floor(Math.random() * 9999),
        valor: '100.00',
        dataTransacao: '2024-06-01',
        tipo: 'despesa',
        pessoa: 'Pessoa Teste',
        categoriaReceita: 'Alimentação'
    };

}
