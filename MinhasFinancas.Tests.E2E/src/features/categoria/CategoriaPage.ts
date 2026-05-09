import { Page } from 'playwright';
import { Actions } from '@base/Actions';
import { CategoriaLocators } from './CategoriaLocators';

export class CategoriaPage {
  private readonly locators: CategoriaLocators;

  constructor(private readonly page: Page) {
    this.locators = new CategoriaLocators(this.page);
  }

  async navegarParaCadastro(): Promise<void> {
    await this.page.goto('http://localhost:5173/categorias');
  }

  async clicarEmAdicionarCategoria(): Promise<void> {
    await Actions.clickAsync(this.locators.btnAddCategoria);
  }


  async preencherFormulario(descricao: string, finalidade: string): Promise<void> {    
    await Actions.fillAsync(this.locators.descricao, descricao);
    await Actions.selectOptionAsync(this.locators.selectFinalidade, finalidade);
  }


  async clicarEmSalvar(): Promise<void> {
    await Actions.clickAsync(this.locators.btnSalvar);
  }


  get loc() {
    return this.locators;
  }
}