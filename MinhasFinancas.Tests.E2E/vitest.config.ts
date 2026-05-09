import { defineConfig } from 'vitest/config';
import path from 'path';
import { fileURLToPath } from 'url';

const __dirname = path.dirname(fileURLToPath(import.meta.url));

export default defineConfig({
  test: {
    pool: 'threads', 
    poolOptions: {
      threads: {
        singleThread: true,
        minThreads: 1,
        maxThreads: 1 
      }
    },
    globalSetup: undefined,
    testTimeout: 60000,
  },
  resolve: {
    alias: {
      '@base': path.resolve(__dirname, './src/base'),
      '@base/*': path.resolve(__dirname, './src/base/*'),
      '@features': path.resolve(__dirname, './src/features'),
      '@features/*': path.resolve(__dirname, './src/features/*'),
    }
  }
});