# MinhasFinancas.Tests.E2E

Projeto de testes E2E para o sistema MinhasFinancas, utilizando Vitest e Playwright.

## Pré-requisitos

- Node.js instalado
- Aplicação MinhasFinancas rodando em `http://localhost:3000`

## Instalação

```bash
npm install
```

## Scripts Disponíveis

### Executar testes E2E
```bash
npm run test:e2e
```
Executa todos os testes uma única vez.

### Executar testes com interface visual
```bash
npm run test:e2e:ui
```
Abre uma interface visual para executar e depurar os testes.

### Executar testes em modo watch
```bash
npm run test:e2e:watch
```
Executa os testes e fica monitorando alterações nos arquivos.

### Executar testes em modo debug
```bash
npm run test:e2e:debug
```
Inicia os testes com debugger ativo. Use o Chrome DevTools em `chrome://inspect` ou o VS Code com `F5`.
 +++++++ REPLACE

## Como Executar os Testes

1. **Primeiro, inicie a aplicação MinhasFinancas**:
   ```bash
   # Navegue até o diretório da API
   cd MinhasFinancas.API
   
   # Inicie a aplicação (dependendo da configuração)
   dotnet run
   # ou
   npm start
   ```

2. **Em outro terminal, execute os testes**:
   ```bash
   cd MinhasFinancas.Tests.E2E
   npm run test:e2e
   ```

## Estrutura do Projeto

```
MinhasFinancas.Tests.E2E/
├── src/
│   ├── base/               # Classes base reutilizáveis
│   │   ├── Actions.ts      # Métodos de ação (click, fill, select)
│   │   ├── TestRun.ts      # Classe base para setup/teardown
│   │   └── Validators.ts   # Asserções customizadas
│   └── features/           # Testes por funcionalidade
│       ├── Pessoa.test.ts  # Testes de cadastro de pessoa
│       ├── PessoaData.ts   # Dados de teste
│       ├── PessoaPage.ts   # Page Object
│       └── PessoaLocators.ts # Localizadores de elementos
├── package.json            # Dependências e scripts
├── tsconfig.json           # Configuração TypeScript
├── vitest.config.ts        # Configuração Vitest
└── README.md               # Este arquivo
```

## Testes Implementados

### Suíte de Cadastro de Pessoa

1. **Deve cadastrar uma nova pessoa com sucesso - AAA**
   - Navega para página de cadastro
   - Preenche formulário com dados válidos
   - Verifica mensagem de sucesso

2. **Deve exibir mensagem de erro ao cadastrar com dados inválidos - AAA**
   - Navega para página de cadastro
   - Preenche formulário com dados inválidos
   - Verifica mensagem de erro

## Solução de Problemas

### Erro: `net::ERR_CONNECTION_REFUSED`
**Causa**: A aplicação não está rodando na porta 3000.

**Solução**: Certifique-se de que a aplicação MinhasFinancas está rodando antes de executar os testes.

### Erro: `No test files found`
**Causa**: Os arquivos de teste não seguem a convenção de nomes do Vitest.

**Solução**: Os arquivos de teste devem ter a extensão `.test.ts` ou `.spec.ts`.

### Erro: TypeScript compilation errors
**Causa**: Problemas de configuração do TypeScript.

**Solução**: Execute `npx tsc --noEmit` para verificar erros de compilação.

## Tecnologias Utilizadas

- **Vitest**: Framework de testes
- **Playwright**: Automação de browsers
- **TypeScript**: Tipagem estática
- **Page Object Model**: Padrão de organização de testes

## Convenções de Código

- Padrão AAA (Arrange, Act, Assert) nos testes
- Page Object Model para organização
- Classes de utilitários reutilizáveis (Actions, Validators)
- Dados de teste centralizados (Data classes)

## 🐛 Debug de Testes

### 🚀 Começando Agora - Guia Rápido para VS Code

**📖 [COMO_DEBUGAR_VSCODE.md](COMO_DEBUGAR_VSCODE.md)** - Guia passo a passo detalhado

**Opção 1: Interface Visual (Mais Fácil)**
```bash
npm run test:e2e:ui
```

**Opção 2: Debug com Breakpoints no VS Code (Mais Poderoso)**
1. Abra `src/features/Pessoa.test.ts`
2. Clique na margem esquerda para adicionar breakpoint (ponto vermelho 🔴)
3. Pressione `Ctrl+Shift+D` para abrir Debug
4. Selecione "🔴 Debug Current Test File (Recomendado)"
5. Pressione `F5` para iniciar

### 📚 Documentação Completa

- **[COMO_DEBUGAR_VSCODE.md](COMO_DEBUGAR_VSCODE.md)** - Guia detalhado passo a passo para debug no VS Code
- **[DEBUG.md](DEBUG.md)** - Guia completo de debug com todas as opções

### Resumo dos Comandos de Debug

```bash
# Interface visual
npm run test:e2e:ui

# Debug com Chrome DevTools
npm run test:e2e:debug
# Abra chrome://inspect
# Clique em "Inspect" no processo Node.js
```

### Dicas Rápidas

- **Adicione `debugger;`** no código onde quer pausar
- **Use `test.only()`** para executar apenas um teste
- **Use `console.log()`** para ver valores no terminal
- **Use `page.pause()`** para pausar e inspecionar manualmente
 +++++++ REPLACE
 +++++++ REPLACE
