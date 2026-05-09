import { describe, it, beforeEach, afterEach } from 'vitest';
import { TestRun } from '@base/TestRun';
import { PessoaPage } from './PessoaPage';
import { PessoaData } from './PessoaData';
import { Validators } from '@base/Validators';

class PessoaTests extends TestRun {
  public pessoaPage!: PessoaPage;

  override async setupBeforeEach(): Promise<void> {
    await super.setupBeforeEach(); 
    this.pessoaPage = new PessoaPage(this.page);
  }
}


const testSuite = new PessoaTests();

describe.sequential('Suíte de Cadastro de Pessoa', () => {
  beforeEach(async () => {
    await testSuite.setupBeforeEach();    
    await testSuite.pessoaPage.navegarParaCadastro();
  });

  afterEach(async () => {
    await testSuite.teardownAfterEach();
  });

  it('1. Deve cadastrar uma nova pessoa com sucesso', async () => {
    const data = PessoaData.pessoaValida;
    
    await testSuite.pessoaPage.clicarEmAdicionarPessoa();
    await testSuite.pessoaPage.preencherFormulario(data.nome, data.idade);
    await testSuite.pessoaPage.clicarEmSalvar();

    await Validators.GetByTextAsync(testSuite.page, 'Pessoa salva com sucesso!');
  });

  it('2. Deve consultar uma nova pessoa cadastrada com sucesso', async () => {
    const data = PessoaData.pessoaValida;
    await Validators.toBeVisibleAsync(testSuite.page.locator(`//td[normalize-space(text())='${data.nome}']`));
  });
  

  it('3. Deve editar uma nova pessoa com sucesso', async () => {
    const data = PessoaData.pessoaValidaEdicao;

    await testSuite.pessoaPage.clicarEmEditar(PessoaData.pessoaValida.nome);
    await testSuite.pessoaPage.preencherFormulario(data.nome, data.idade);
    await testSuite.pessoaPage.clicarEmSalvar();

    await Validators.GetByTextAsync(testSuite.page, 'Pessoa atualizada com sucesso!');
  });

  it('4. Deve excluir uma pessoa com sucesso', async () => {
    const data = PessoaData.pessoaValidaEdicao;
    await testSuite.pessoaPage.clicarEmExcluir(data.nome);
    await Validators.notToBeVisibleAsync(testSuite.page.locator(`//td[normalize-space(text())='${data.nome}']`));  
  });

});