import { describe, it, beforeEach, afterEach } from 'vitest';
import { TestRun } from '@base/TestRun';
import { Validators } from '@base/Validators';
import { TransacoesPage } from './TransacoesPage';
import { TransacoesData } from './TransacoesData';

class TransacoesTests extends TestRun {
  public transacoesPage!: TransacoesPage;

  override async setupBeforeEach(): Promise<void> {
    await super.setupBeforeEach(); 
    this.transacoesPage = new TransacoesPage(this.page);
  }
}


const testSuite = new TransacoesTests();

describe.sequential('Suíte de Cadastro de Transações', () => {
  beforeEach(async () => {
    await testSuite.setupBeforeEach();    
    await testSuite.transacoesPage.navegarParaCadastro();
  });

  afterEach(async () => {
    await testSuite.teardownAfterEach();
  });

  it('1. Deve cadastrar uma nova pessoa com sucesso', async () => {
    const data = TransacoesData.transacaoValida;
    
    await testSuite.transacoesPage.clicarEmAdicionarTransacao();
    await testSuite.transacoesPage.preencherFormularioTransacao(data.descricao
      , data.valor
      , data.dataTransacao
      , data.tipoReceita
      , data.pessoa
      , data.categoriaReceita);
    await testSuite.transacoesPage.clicarEmSalvar();

    await Validators.GetByTextAsync(testSuite.page, 'Transação salva com sucesso!');
  });

  it('2. Deve consultar uma transação cadastrada com sucesso', async () => {
    const data = TransacoesData.transacaoValida;
    await Validators.toBeVisibleAsync(testSuite.page.locator(`//td[normalize-space(text())='${data.descricao}']`));
  });
  
  it('3. Não Deve cadastrar transação do tipo despesa em receita', async () => {
    const data = TransacoesData.transacaoValida;
    
    await testSuite.transacoesPage.clicarEmAdicionarTransacao();
    await testSuite.transacoesPage.preencherFormularioTransacao(data.descricao
      , data.valor
      , data.dataTransacao
      , data.tipoDespesa
      , data.pessoa
      , data.categoriaReceita);
    await testSuite.transacoesPage.clicarEmSalvar();

    await Validators.GetByTextAsync(testSuite.page, 'Erro ao salvar transação. Tente novamente.');
  });

  it('4. Não Deve cadastrar transação do tipo receita em despesa', async () => {
    const data = TransacoesData.transacaoValida;
    
    await testSuite.transacoesPage.clicarEmAdicionarTransacao();
    await testSuite.transacoesPage.preencherFormularioTransacao(data.descricao
      , data.valor
      , data.dataTransacao
      , data.tipoReceita
      , data.pessoa
      , data.categoriaDespesa);
    await testSuite.transacoesPage.clicarEmSalvar();

    await Validators.GetByTextAsync(testSuite.page, 'Erro ao salvar transação. Tente novamente.');
  });

  it('5. Não Deve cadastrar transação do tipo receita para pessoa menor de idade', async () => {
    const data = TransacoesData.transacaoValida;
    
    await testSuite.transacoesPage.clicarEmAdicionarTransacao();
    await testSuite.transacoesPage.preencherFormularioTransacao(data.descricao
      , data.valor
      , data.dataTransacao
      , data.tipoReceita
      , data.pessoaMenor
      , data.categoriaReceita);

    await Validators.toBeVisibleAsync(testSuite.page.locator('//p[normalize-space(text())=\'Menores só podem registrar despesas.\']'));
  });




});