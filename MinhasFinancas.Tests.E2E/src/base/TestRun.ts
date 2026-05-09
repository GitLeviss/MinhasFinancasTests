import { Browser, BrowserContext, Page, chromium } from 'playwright';

export class TestRun {
  public browser!: Browser;
  public context!: BrowserContext;
  public page!: Page;

  public async setupBeforeEach(): Promise<void> {
    this.browser = await chromium.launch({ headless: false }); 
    this.context = await this.browser.newContext();
    this.page = await this.context.newPage();
  }

  public async teardownAfterEach(): Promise<void> {
    if (this.page) await this.page.close();
    if (this.context) await this.context.close();
    if (this.browser) await this.browser.close();
  }
}