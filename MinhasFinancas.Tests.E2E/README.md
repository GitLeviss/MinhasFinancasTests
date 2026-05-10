# MinhasFinancas.Tests.E2E

Projeto de testes E2E para o sistema MinhasFinancas usando Vitest e Playwright.

## 📋 Sobre

Suíte completa de testes automatizados que valida todo o fluxo do sistema MinhasFinancas (pessoas, categorias, transações e totais).

**Principais Padrões:**
- Page Object Model (POM)
- Padrão AAA (Arrange-Act-Assert)
- Classes base reutilizáveis
- Dados de teste centralizados

## 🚀 Início Rápido

### Pré-requisitos
- Node.js instalado
- Aplicação MinhasFinancas rodando em `http://localhost:5173`

### Instalação
```bash
npm install
```

### Executar Testes
```bash
# Todos os testes
npm run test:e2e

# Interface visual
npm run test:e2e:ui

# Modo watch
npm run test:e2e:watch

# Debug
npm run test:e2e:debug
```

## 📁 Estrutura

```
src/
├── base/                    # Classes base
│   ├── Actions.ts          # Métodos de ação
│   ├── TestRun.ts          # Setup/teardown
│   └── Validators.ts       # Asserções
└── features/               # Testes por funcionalidade
    ├── categoria/         # Testes de categorias
    ├── pessoa/            # Testes de pessoas
    ├── transacoes/        # Testes de transações
    └── totalPessoa/       # Testes de totais
```

## 🎯 Padrão Page Object Model

**Cada feature tem 4 arquivos:**
1. `*Locators.ts` - Seletores de elementos
2. `*Page.ts` - Métodos de interação com a página
3. `*Data.ts` - Dados de teste
4. `*.test.ts` - Casos de teste

## 📊 Testes Implementados

### 1. Pessoa
- ✅ Cadastro de pessoa
- ✅ Consulta de pessoa
- ✅ Edição de pessoa
- ✅ Exclusão de pessoa

### 2. Categoria
- ✅ Cadastro de categorias (receita/despesa)
- ✅ Consulta de categorias
- ✅ Edição de categorias
- ✅ Exclusão de categorias

### 3. Transações
- ✅ Cadastro de transação
- ✅ Consulta de transação
- ✅ Validação: despesa em receita ❌
- ✅ Validação: receita em despesa ❌
- ✅ Validação: receita para menor ❌
- ✅ Exclusão em cascata (pessoa → transações)

### 4. Totais por Pessoa
- ✅ Consulta de totais (receitas, despesas, saldo)

## 🔄 Ciclo de Vida dos Testes

```typescript
beforeAll()   // Setup inicial (cria dados base)
beforeEach()  // Inicializa browser e página
it()          // Executa teste (AAA)
afterEach()   // Fecha browser
```

## 🐛 Debug

```bash
# Interface visual
npm run test:e2e:ui

# VS Code (F5)
npm run test:e2e:debug
```

## 🛠 Tecnologias

- **Vitest** - Framework de testes
- **Playwright** - Automação de browsers
- **TypeScript** - Tipagem estática
- **Page Object Model** - Padrão de organização
