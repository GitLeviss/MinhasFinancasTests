import { describe, it, beforeEach, afterEach } from 'vitest';
import { TestRun } from '@base/TestRun';
import { Validators } from '@base/Validators';
import { TotalPessoaLocators } from './TotalPessoaLocators';
import { TotalPessoaPage } from './TransacoesPage';

class TotalPessoaTests extends TestRun {
  public totalPessoaPage!: TotalPessoaPage;

  override async setupBeforeEach(): Promise<void> {
    await super.setupBeforeEach(); 
    this.totalPessoaPage = new TotalPessoaPage(this.page);
  }
}


const testSuite = new TotalPessoaTests();

describe.sequential('Suíte de total por pessoas', () => {
  beforeEach(async () => {
    await testSuite.setupBeforeEach();    
    await testSuite.totalPessoaPage.navegarParaTotais();
  });

  afterEach(async () => {
    await testSuite.teardownAfterEach();
  });

  it('1. Deve consultar total pessoa com sucesso', async () => {   
    
    await Validators.toBeVisibleAsync(testSuite.totalPessoaPage.loc.pessoa('Maria Santos'
        , 'R$ 500.00'
        , 'R$ 0.00'
        , 'R$ 500.00'));
  });

 




});