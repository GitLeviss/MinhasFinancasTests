import { Page } from 'playwright';

export class TransacoesLocators {
  constructor(private readonly page: Page) { }

  get BtnNovaTransacao() { return this.page.locator('//button[normalize-space(text())=\'Adicionar Transação\']'); }
  get inputDescricao() { return this.page.locator('#descricao'); }
  get inputValor() { return this.page.locator('#valor'); }
  get inputData() { return this.page.locator('#data'); }
  get selectTipo() { return this.page.locator('#tipo'); }
  get selectPessoa() { return this.page.locator('#pessoa-select'); }
  get selectCategoria() { return this.page.locator('#categoria-select'); }
  get btnSalvar() { return this.page.locator('//button[normalize-space(text())=\'Salvar\']'); }

}