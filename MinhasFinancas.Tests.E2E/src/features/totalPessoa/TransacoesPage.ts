import { Page } from 'playwright';
import { Actions } from '@base/Actions';
import { TotalPessoaLocators } from './TotalPessoaLocators';

export class TotalPessoaPage {
    private readonly locators: TotalPessoaLocators;

    constructor(private readonly page: Page) {
        this.locators = new TotalPessoaLocators(this.page);
    }

    async navegarParaTotais(): Promise<void> {
        await this.page.goto('http://localhost:5173/totais');
    }


    get loc() {
        return this.locators;
    }
}