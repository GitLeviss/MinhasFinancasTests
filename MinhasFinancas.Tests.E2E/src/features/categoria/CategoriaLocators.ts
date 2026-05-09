import { Page } from 'playwright';

export class CategoriaLocators {
    constructor(private readonly page: Page) { }

    get btnAddCategoria() {
        return this.page.locator('//button[normalize-space(text())=\'Adicionar Categoria\']'
        );
    }
    get descricao() {
        return this.page.locator('#descricao');
    }

    get selectFinalidade() {
        return this.page.locator('#finalidade');
    }

    get btnSalvar() {
        return this.page.locator('//button[normalize-space(text())=\'Salvar\']');
    }

    //Categoria salva com sucesso!
}