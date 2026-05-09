using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhasFinancas.Application.DTOs;
using MinhasFinancas.Application.Services;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Tests.Repositories;
using NSubstitute;
using Xunit;
using FluentAssertions;

namespace MinhasFinancas.Tests.Services;

public class TransacaoServiceTests
{
    [Fact]
    public async Task CreateAsync_TransacaoValida_DeveCriarComSucesso()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoa = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "João Silva",
            DataNascimento = DateTime.Now.AddYears(-25)
        };
        
        var categoria = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoa.Id).Returns(pessoa);
        unitOfWork.Categorias.GetByIdAsync(categoria.Id).Returns(categoria);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Salário Mensal",
            Valor = 5000,
            Tipo = Transacao.ETipo.Receita,
            Data = DateTime.Now,
            CategoriaId = categoria.Id,
            PessoaId = pessoa.Id
        };
        
        var result = await service.CreateAsync(dto);
        
        result.Should().NotBeNull();
        result.Descricao.Should().Be("Salário Mensal");
        result.Valor.Should().Be(5000);
        result.Tipo.Should().Be(Transacao.ETipo.Receita);
    }

    [Fact]
    public async Task CreateAsync_PessoaInexistente_DeveLancarExcecao()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var categoria = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };
        
        unitOfWork.Categorias.GetByIdAsync(categoria.Id).Returns(categoria);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Salário",
            Valor = 1000,
            Tipo = Transacao.ETipo.Receita,
            Data = DateTime.Now,
            CategoriaId = categoria.Id,
            PessoaId = Guid.NewGuid()
        };
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            async () => await service.CreateAsync(dto)
        );
        
        exception.Message.Should().Contain("Pessoa não encontrada");
    }

    [Fact]
    public async Task CreateAsync_CategoriaInexistente_DeveLancarExcecao()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoa = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "João Silva",
            DataNascimento = DateTime.Now.AddYears(-25)
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoa.Id).Returns(pessoa);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Salário",
            Valor = 1000,
            Tipo = Transacao.ETipo.Receita,
            Data = DateTime.Now,
            CategoriaId = Guid.NewGuid(),
            PessoaId = pessoa.Id
        };
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            async () => await service.CreateAsync(dto)
        );
        
        exception.Message.Should().Contain("Categoria não encontrada");
    }

    [Fact]
    public async Task GetAllAsync_DeveRetornarResult()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var result = await service.GetAllAsync();
        
        result.Should().NotBeNull();
        result.TotalCount.Should().Be(0);
        result.Page.Should().Be(1);
        result.PageSize.Should().Be(10);
    }

    [Fact]
    public async Task GetByIdAsync_TransacaoExistente_DeveRetornarTransacao()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var transacaoId = Guid.NewGuid();
        var transacao = new Transacao
        {
            Id = transacaoId,
            Descricao = "Aluguel",
            Valor = 1500,
            Tipo = Transacao.ETipo.Despesa,
            Data = DateTime.Now
        };
        
        unitOfWork.Transacoes.GetByIdAsync(transacaoId).Returns(transacao);
        
        var result = await service.GetByIdAsync(transacaoId);
        
        result.Should().NotBeNull();
        result.Id.Should().Be(transacaoId);
        result.Descricao.Should().Be("Aluguel");
        result.Valor.Should().Be(1500);
    }

    [Fact]
    public async Task GetByIdAsync_TransacaoInexistente_DeveRetornarNulo()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var result = await service.GetByIdAsync(Guid.NewGuid());
        
        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateAsync_MenorDeIdadeComReceita_DeveLancarExcecao()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoaMenor = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "João Silva",
            DataNascimento = DateTime.Now.AddYears(-15)
        };
        
        var categoriaReceita = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoaMenor.Id).Returns(pessoaMenor);
        unitOfWork.Categorias.GetByIdAsync(categoriaReceita.Id).Returns(categoriaReceita);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Salário",
            Valor = 1000,
            Tipo = Transacao.ETipo.Receita,
            Data = DateTime.Now,
            CategoriaId = categoriaReceita.Id,
            PessoaId = pessoaMenor.Id
        };
        
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            async () => await service.CreateAsync(dto)
        );
        
        exception.Message.Should().Contain("Menores de 18 anos não podem registrar receitas");
    }

    [Fact]
    public async Task CreateAsync_MenorDeIdadeComDespesa_DevePermitir()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoaMenor = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "João Silva",
            DataNascimento = DateTime.Now.AddYears(-15)
        };
        
        var categoriaDespesa = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Alimentação",
            Finalidade = Categoria.EFinalidade.Despesa
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoaMenor.Id).Returns(pessoaMenor);
        unitOfWork.Categorias.GetByIdAsync(categoriaDespesa.Id).Returns(categoriaDespesa);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Lanche",
            Valor = 50,
            Tipo = Transacao.ETipo.Despesa,
            Data = DateTime.Now,
            CategoriaId = categoriaDespesa.Id,
            PessoaId = pessoaMenor.Id
        };
        
        var result = await service.CreateAsync(dto);
        
        result.Should().NotBeNull();
        result.Descricao.Should().Be("Lanche");
        result.Valor.Should().Be(50);
    }

    [Fact]
    public async Task CreateAsync_DespesaEmCategoriaDeReceita_DeveLancarExcecao()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoaMaior = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "Maria Santos",
            DataNascimento = DateTime.Now.AddYears(-25)
        };
        
        var categoriaReceita = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoaMaior.Id).Returns(pessoaMaior);
        unitOfWork.Categorias.GetByIdAsync(categoriaReceita.Id).Returns(categoriaReceita);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Despesa Incorreta",
            Valor = 100,
            Tipo = Transacao.ETipo.Despesa,
            Data = DateTime.Now,
            CategoriaId = categoriaReceita.Id,
            PessoaId = pessoaMaior.Id
        };
        
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            async () => await service.CreateAsync(dto)
        );
        
        exception.Message.Should().Contain("Não é possível registrar despesa em categoria de receita");
    }

    [Fact]
    public async Task CreateAsync_ReceitaEmCategoriaDeDespesa_DeveLancarExcecao()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoaMaior = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "Maria Santos",
            DataNascimento = DateTime.Now.AddYears(-25)
        };
        
        var categoriaDespesa = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Alimentação",
            Finalidade = Categoria.EFinalidade.Despesa
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoaMaior.Id).Returns(pessoaMaior);
        unitOfWork.Categorias.GetByIdAsync(categoriaDespesa.Id).Returns(categoriaDespesa);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Receita Incorreta",
            Valor = 100,
            Tipo = Transacao.ETipo.Receita,
            Data = DateTime.Now,
            CategoriaId = categoriaDespesa.Id,
            PessoaId = pessoaMaior.Id
        };
        
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            async () => await service.CreateAsync(dto)
        );
        
        exception.Message.Should().Contain("Não é possível registrar receita em categoria de despesa");
    }

    [Fact]
    public async Task CreateAsync_ReceitaEmCategoriaAmbas_DevePermitir()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoaMaior = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "Maria Santos",
            DataNascimento = DateTime.Now.AddYears(-25)
        };
        
        var categoriaAmbas = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Outros",
            Finalidade = Categoria.EFinalidade.Ambas
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoaMaior.Id).Returns(pessoaMaior);
        unitOfWork.Categorias.GetByIdAsync(categoriaAmbas.Id).Returns(categoriaAmbas);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Bônus",
            Valor = 500,
            Tipo = Transacao.ETipo.Receita,
            Data = DateTime.Now,
            CategoriaId = categoriaAmbas.Id,
            PessoaId = pessoaMaior.Id
        };
        
        var result = await service.CreateAsync(dto);
        
        result.Should().NotBeNull();
        result.Descricao.Should().Be("Bônus");
        result.Valor.Should().Be(500);
    }

    [Fact]
    public async Task CreateAsync_DespesaEmCategoriaAmbas_DevePermitir()
    {
        var unitOfWork = MockUnitOfWork.Create();
        var service = new TransacaoService(unitOfWork);
        
        var pessoaMaior = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "Maria Santos",
            DataNascimento = DateTime.Now.AddYears(-25)
        };
        
        var categoriaAmbas = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Outros",
            Finalidade = Categoria.EFinalidade.Ambas
        };
        
        unitOfWork.Pessoas.GetByIdAsync(pessoaMaior.Id).Returns(pessoaMaior);
        unitOfWork.Categorias.GetByIdAsync(categoriaAmbas.Id).Returns(categoriaAmbas);
        
        var dto = new CreateTransacaoDto
        {
            Descricao = "Extra",
            Valor = 200,
            Tipo = Transacao.ETipo.Despesa,
            Data = DateTime.Now,
            CategoriaId = categoriaAmbas.Id,
            PessoaId = pessoaMaior.Id
        };
        
        var result = await service.CreateAsync(dto);
        
        result.Should().NotBeNull();
        result.Descricao.Should().Be("Extra");
        result.Valor.Should().Be(200);
    }
}