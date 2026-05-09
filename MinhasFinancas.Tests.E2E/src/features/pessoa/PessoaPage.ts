import { Page } from 'playwright';
import { Actions } from '@base/Actions';
import { PessoaLocators } from './PessoaLocators';

export class PessoaPage {
  private readonly locators: PessoaLocators;

  constructor(private readonly page: Page) {
    this.locators = new PessoaLocators(this.page);
  }

  async navegarParaPessoas(): Promise<void> {
    await this.page.goto('http://localhost:5173/pessoas');
  }

  async clicarEmAdicionarPessoa(): Promise<void> {
    await Actions.clickAsync(this.locators.BtnAddPessoa);
  }


  async preencherFormulario(nome: string, idade: string): Promise<void> {    
    await Actions.fillAsync(this.locators.inputNome, nome);
    await Actions.fillAsync(this.locators.selectIdade, idade);
  }


  async clicarEmSalvar(): Promise<void> {
    await Actions.clickAsync(this.locators.btnSalvar);
  }

  async clicarEmEditar(nome: string): Promise<void> {
    await Actions.clickAsync(this.locators.btnEditar(nome));
  }
  async clicarEmExcluir(nome: string): Promise<void> {
    await Actions.clickAsync(this.locators.btnExcluir(nome));
    await Actions.clickAsync(this.locators.btnConfirmarExclusao);
  }


  get loc() {
    return this.locators;
  }
}