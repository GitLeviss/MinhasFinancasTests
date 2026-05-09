import { Locator, Page, expect } from '@playwright/test';

export class Validators {
  static async toHaveTextAsync(locator: Locator, text: string): Promise<void> {
    await expect(locator).toHaveText(text);
  }

  static async GetByTextAsync(page: Page, text: string): Promise<void> {
    await expect(page.getByText(text)).toBeVisible();
  }

  static async toBeVisibleAsync(locator: Locator): Promise<void> {
    await expect(locator).toBeVisible();
  }

  static async notToBeVisibleAsync(locator: Locator): Promise<void> {
    await expect(locator).not.toBeVisible();
  }

  static async toHaveCountAsync(locator: Locator, count: number): Promise<void> {
    await expect(locator).toHaveCount(count);
  }
}