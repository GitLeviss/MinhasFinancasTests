import { Page } from 'playwright';
import { Actions } from '@base/Actions';
import { TransacoesLocators } from './TransacoesLocators';
import { TransacoesData } from './TransacoesData';

export class TransacoesPage {
    private readonly locators: TransacoesLocators;
    private readonly data: TransacoesData;

    constructor(private readonly page: Page) {
        this.locators = new TransacoesLocators(this.page);
        this.data = new TransacoesData();
    }

    async navegarParaCadastro(): Promise<void> {
        await this.page.goto('http://localhost:5173/transacoes');
    }

    async clicarEmAdicionarTransacao(): Promise<void> {
        await Actions.clickAsync(this.locators.BtnNovaTransacao);
    }


    async preencherFormularioTransacao(descricao: string
        , valor: string
        , data: string
        , tipo: string
        , pessoa: string
        , categoria: string): Promise<void> {
        await Actions.fillAsync(this.locators.inputDescricao, descricao);
        await Actions.fillAsync(this.locators.inputValor, valor);
        await Actions.fillAsync(this.locators.inputData, data);
        await Actions.selectOptionAsync(this.locators.selectTipo, tipo);
        await Actions.fillAsync(this.locators.selectPessoa, pessoa);
        await Actions.clickAsync(this.locators.pessoa(pessoa));
        await Actions.fillAsync(this.locators.selectCategoria, categoria);
        await Actions.clickAsync(this.locators.categoria(categoria));
    }


    async clicarEmSalvar(): Promise<void> {
        await Actions.clickAsync(this.locators.btnSalvar);
    }



    get loc() {
        return this.locators;
    }
}