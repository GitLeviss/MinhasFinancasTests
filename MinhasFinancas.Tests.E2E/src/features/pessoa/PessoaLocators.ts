import { Page } from 'playwright';

export class PessoaLocators {
  constructor(private readonly page: Page) { }

  get BtnAddPessoa() { return this.page.locator('//button[normalize-space(text())=\'Adicionar Pessoa\']'); }
  get inputNome() { return this.page.locator('#nome'); }
  get selectIdade() { return this.page.locator('#dataNascimento'); }
  get btnSalvar() { return this.page.locator('//button[normalize-space(text())=\'Salvar\']'); }
  btnEditar(nome: string) {
    return this.page.locator(
      `//td[normalize-space(text())='${nome}']/..//button[normalize-space(text())='Editar']`
    );
  }
  btnExcluir(nome: string) {
    return this.page.locator(
      `//td[normalize-space(text())='${nome}']/..//button[normalize-space(text())='Deletar']`
    );
  }
  get btnConfirmarExclusao() { return this.page.locator('//button[normalize-space(text())=\'Confirmar\']'); }
  get msgSucesso() { return this.page.locator('.alert-success'); }
  get msgErro() { return this.page.locator('.alert-error'); }
}