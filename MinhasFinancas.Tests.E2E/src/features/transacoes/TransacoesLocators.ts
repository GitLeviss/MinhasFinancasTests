import { Page } from 'playwright';

export class TransacoesLocators {
  constructor(private readonly page: Page) { }

  get BtnNovaTransacao() { return this.page.locator('//button[normalize-space(text())=\'Adicionar Transação\']'); }
  get inputDescricao() { return this.page.locator('#descricao'); }
  get inputValor() { return this.page.locator('#valor'); }
  get inputData() { return this.page.locator('#data'); }
  get selectTipo() { return this.page.locator('#tipo'); }
  get selectPessoa() { return this.page.locator('#pessoa-select'); }
  get pessoaTeste() { return this.page.locator('//div[normalize-space(text())=\'Pessoa Teste\']'); }
  pessoa(nome: string) {
    return this.page.locator(
      `//div[normalize-space(text())=\'${nome}\']`
    );
  }
  get selectCategoria() { return this.page.locator('#categoria-select'); }
   categoria(tipo: string) {
    return this.page.locator(
      `//div[normalize-space(text())=\'${tipo}\']`
    );
  }
  get categoriaAlimentacao() { return this.page.locator('//div[normalize-space(text())=\'Alimentação\']'); }
  get categoriaSalario() { return this.page.locator('//div[normalize-space(text())=\'Salário\']'); }
  get btnSalvar() { return this.page.locator('//button[normalize-space(text())=\'Salvar\']'); }

}