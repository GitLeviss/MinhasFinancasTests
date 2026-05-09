import { describe, it, beforeEach, afterEach } from 'vitest';
import { TestRun } from '@base/TestRun';
import { CategoriaPage } from './CategoriaPage';
import { Validators } from '@base/Validators';
import { CategoriaData } from './CategoriaData';

class CategoriaTests extends TestRun {
  public categoriaPage!: CategoriaPage;

  override async setupBeforeEach(): Promise<void> {
    await super.setupBeforeEach(); 
    this.categoriaPage = new CategoriaPage(this.page);
  }
}


const testSuite = new CategoriaTests();

describe.sequential('Suíte de Cadastro de Categoria', () => {
  beforeEach(async () => {
    await testSuite.setupBeforeEach();    
    await testSuite.categoriaPage.navegarParaCadastro();
  });

  afterEach(async () => {
    await testSuite.teardownAfterEach();
  });

  it('1. Deve cadastrar uma nova categoria com sucesso', async () => {
    const data = CategoriaData.categoriaValida;
    
    await testSuite.categoriaPage.clicarEmAdicionarCategoria();
    await testSuite.categoriaPage.preencherFormulario(data.descricao, data.finalidadeDespesa);
    await testSuite.categoriaPage.clicarEmSalvar();

    await Validators.GetByTextAsync(testSuite.page, 'Categoria salva com sucesso!');
  });

  it('2. Deve consultar uma nova categoria cadastrada com sucesso', async () => {
    const data = CategoriaData.categoriaValida;
    await Validators.toBeVisibleAsync(testSuite.page.locator(`//td[normalize-space(text())='${data.descricao}']`));
  });
  

});