import { Page } from 'playwright';

export class TotalPessoaLocators {
  constructor(private readonly page: Page) { }

  
  pessoa(nome: string, totalReceitas: string, totalDespesas: string, saldo: string) {
    return this.page.locator(
      `(//td[normalize-space(text())='${nome}']/..//td[normalize-space(text())='${totalReceitas}']/..//td[normalize-space(text())='${totalDespesas}']/..//td[normalize-space(text())='${saldo}'])[1]`
    );
  }
  

}