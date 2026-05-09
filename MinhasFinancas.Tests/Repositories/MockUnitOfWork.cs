using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces;
using NSubstitute;

namespace MinhasFinancas.Tests.Repositories;

public static class MockUnitOfWork
{
    public static IUnitOfWork Create()
    {
        var unitOfWork = Substitute.For<IUnitOfWork>();
        
        var pessoaRepo = CreatePessoaRepository();
        var categoriaRepo = CreateCategoriaRepository();
        var transacaoRepo = CreateTransacaoRepository();
        
        // Configurar retorno padrão para GetPagedAsync nos repositórios vazios
        var emptyPagedResult = new MinhasFinancas.Domain.ValueObjects.PagedResult<object>
        {
            Items = System.Linq.Enumerable.Empty<object>(),
            TotalCount = 0,
            Page = 1,
            PageSize = 10
        };
        
        pessoaRepo.GetPagedAsync(Arg.Any<MinhasFinancas.Domain.ValueObjects.PagedRequest>(), Arg.Any<MinhasFinancas.Domain.Interfaces.ISpecification<Pessoa, object>>())
            .Returns(Task.FromResult(emptyPagedResult));
        
        categoriaRepo.GetPagedAsync(Arg.Any<MinhasFinancas.Domain.ValueObjects.PagedRequest>(), Arg.Any<MinhasFinancas.Domain.Interfaces.ISpecification<Categoria, object>>())
            .Returns(Task.FromResult(emptyPagedResult));
        
        transacaoRepo.GetPagedAsync(Arg.Any<MinhasFinancas.Domain.ValueObjects.PagedRequest>(), Arg.Any<MinhasFinancas.Domain.Interfaces.ISpecification<Transacao, object>>())
            .Returns(Task.FromResult(emptyPagedResult));
        
        unitOfWork.Pessoas.Returns(pessoaRepo);
        unitOfWork.Categorias.Returns(categoriaRepo);
        unitOfWork.Transacoes.Returns(transacaoRepo);
        
        unitOfWork.SaveChangesAsync().Returns(1);
        
        unitOfWork.BeginTransactionAsync().Returns(Task.CompletedTask);
        unitOfWork.CommitAsync().Returns(Task.CompletedTask);
        unitOfWork.RollbackAsync().Returns(Task.CompletedTask);
        
        unitOfWork.WhenForAnyArgs(x => x.Dispose()).Do(x => { });
        
        return unitOfWork;
    }

    public static IPessoaRepository CreatePessoaRepository()
    {
        var repository = Substitute.For<IPessoaRepository>();
        var pessoas = new List<Pessoa>();
        
        repository.GetByIdAsync(Arg.Any<Guid>())
            .Returns(callInfo => pessoas.FirstOrDefault(p => p.Id == callInfo.Arg<Guid>()));
        
        repository.GetAllAsync()
            .Returns(pessoa => Task.FromResult((IEnumerable<Pessoa>)pessoas));
        
        repository.AddAsync(Arg.Any<Pessoa>())
            .Returns(callInfo =>
            {
                var pessoa = callInfo.Arg<Pessoa>();
                pessoas.Add(pessoa);
                return Task.CompletedTask;
            });
        
        repository.UpdateAsync(Arg.Any<Pessoa>())
            .Returns(callInfo =>
            {
                var pessoa = callInfo.Arg<Pessoa>();
                var index = pessoas.FindIndex(p => p.Id == pessoa.Id);
                if (index >= 0)
                {
                    pessoas[index] = pessoa;
                }
                return Task.CompletedTask;
            });
        
        repository.DeleteAsync(Arg.Any<Guid>())
            .Returns(callInfo =>
            {
                var id = callInfo.Arg<Guid>();
                pessoas.RemoveAll(p => p.Id == id);
                return Task.CompletedTask;
            });
        
        repository.GetPagedAsync(Arg.Any<MinhasFinancas.Domain.ValueObjects.PagedRequest>(), Arg.Any<MinhasFinancas.Domain.Interfaces.ISpecification<Pessoa, object>>())
            .Returns(callInfo =>
            {
                var spec = callInfo.Arg<MinhasFinancas.Domain.Interfaces.ISpecification<Pessoa, object>>();
                var results = pessoas.AsQueryable();
                
                if (spec.Where != null)
                {
                    results = results.Where(spec.Where);
                }
                
                if (spec.OrderBy != null)
                {
                    results = spec.OrderByDescending
                        ? results.OrderByDescending(spec.OrderBy)
                        : results.OrderBy(spec.OrderBy);
                }
                
                var pageRequest = callInfo.Arg<MinhasFinancas.Domain.ValueObjects.PagedRequest>();
                var page = pageRequest?.Page ?? 1;
                var pageSize = pageRequest?.PageSize ?? 10;
                var totalCount = results.Count();
                var items = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                
                var pagedResult = new MinhasFinancas.Domain.ValueObjects.PagedResult<object>
                {
                    Items = items.Cast<object>(),
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize
                };
                
                return Task.FromResult(pagedResult);
            });
        
        return repository;
    }

    public static ICategoriaRepository CreateCategoriaRepository()
    {
        var repository = Substitute.For<ICategoriaRepository>();
        var categorias = new List<Categoria>();
        
        repository.GetByIdAsync(Arg.Any<Guid>())
            .Returns(callInfo => categorias.FirstOrDefault(c => c.Id == callInfo.Arg<Guid>()));
        
        repository.GetAllAsync()
            .Returns(categoria => Task.FromResult((IEnumerable<Categoria>)categorias));
        
        repository.AddAsync(Arg.Any<Categoria>())
            .Returns(callInfo =>
            {
                var categoria = callInfo.Arg<Categoria>();
                categorias.Add(categoria);
                return Task.CompletedTask;
            });
        
        repository.UpdateAsync(Arg.Any<Categoria>())
            .Returns(callInfo =>
            {
                var categoria = callInfo.Arg<Categoria>();
                var index = categorias.FindIndex(c => c.Id == categoria.Id);
                if (index >= 0)
                {
                    categorias[index] = categoria;
                }
                return Task.CompletedTask;
            });
        
        repository.DeleteAsync(Arg.Any<Guid>())
            .Returns(callInfo =>
            {
                var id = callInfo.Arg<Guid>();
                categorias.RemoveAll(c => c.Id == id);
                return Task.CompletedTask;
            });
        
        repository.GetPagedAsync(Arg.Any<MinhasFinancas.Domain.ValueObjects.PagedRequest>(), Arg.Any<MinhasFinancas.Domain.Interfaces.ISpecification<Categoria, object>>())
            .Returns(callInfo =>
            {
                var spec = callInfo.Arg<MinhasFinancas.Domain.Interfaces.ISpecification<Categoria, object>>();
                var results = categorias.AsQueryable();
                
                if (spec.Where != null)
                {
                    results = results.Where(spec.Where);
                }
                
                if (spec.OrderBy != null)
                {
                    results = spec.OrderByDescending
                        ? results.OrderByDescending(spec.OrderBy)
                        : results.OrderBy(spec.OrderBy);
                }
                
                var pageRequest = callInfo.Arg<MinhasFinancas.Domain.ValueObjects.PagedRequest>();
                var page = pageRequest?.Page ?? 1;
                var pageSize = pageRequest?.PageSize ?? 10;
                var totalCount = results.Count();
                var items = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                
                var pagedResult = new MinhasFinancas.Domain.ValueObjects.PagedResult<object>
                {
                    Items = items.Cast<object>(),
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize
                };
                
                return Task.FromResult(pagedResult);
            });
        
        return repository;
    }

    public static ITransacaoRepository CreateTransacaoRepository()
    {
        var repository = Substitute.For<ITransacaoRepository>();
        var transacoes = new List<Transacao>();
        
        repository.GetByIdAsync(Arg.Any<Guid>())
            .Returns(callInfo => transacoes.FirstOrDefault(t => t.Id == callInfo.Arg<Guid>()));
        
        repository.GetAllAsync()
            .Returns(transacao => Task.FromResult((IEnumerable<Transacao>)transacoes));
        
        repository.AddAsync(Arg.Any<Transacao>())
            .Returns(callInfo =>
            {
                var transacao = callInfo.Arg<Transacao>();
                transacoes.Add(transacao);
                return Task.CompletedTask;
            });
        
        repository.UpdateAsync(Arg.Any<Transacao>())
            .Returns(callInfo =>
            {
                var transacao = callInfo.Arg<Transacao>();
                var index = transacoes.FindIndex(t => t.Id == transacao.Id);
                if (index >= 0)
                {
                    transacoes[index] = transacao;
                }
                return Task.CompletedTask;
            });
        
        repository.DeleteAsync(Arg.Any<Guid>())
            .Returns(callInfo =>
            {
                var id = callInfo.Arg<Guid>();
                transacoes.RemoveAll(t => t.Id == id);
                return Task.CompletedTask;
            });
        
        repository.GetPagedAsync(Arg.Any<MinhasFinancas.Domain.ValueObjects.PagedRequest>(), Arg.Any<MinhasFinancas.Domain.Interfaces.ISpecification<Transacao, object>>())
            .Returns(callInfo =>
            {
                var spec = callInfo.Arg<MinhasFinancas.Domain.Interfaces.ISpecification<Transacao, object>>();
                var results = transacoes.AsQueryable();
                
                if (spec.Where != null)
                {
                    results = results.Where(spec.Where);
                }
                
                if (spec.OrderBy != null)
                {
                    results = spec.OrderByDescending
                        ? results.OrderByDescending(spec.OrderBy)
                        : results.OrderBy(spec.OrderBy);
                }
                
                var pageRequest = callInfo.Arg<MinhasFinancas.Domain.ValueObjects.PagedRequest>();
                var page = pageRequest?.Page ?? 1;
                var pageSize = pageRequest?.PageSize ?? 10;
                var totalCount = results.Count();
                var items = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                
                var pagedResult = new MinhasFinancas.Domain.ValueObjects.PagedResult<object>
                {
                    Items = items.Cast<object>(),
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize
                };
                
                return Task.FromResult(pagedResult);
            });
        
        return repository;
    }

    public static IUnitOfWork CreateWithTestData()
    {
        var unitOfWork = Substitute.For<IUnitOfWork>();
        
        var pessoaMaior = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "João Silva",
            DataNascimento = DateTime.Now.AddYears(-25)
        };
        
        var pessoaMenor = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = "Maria Santos",
            DataNascimento = DateTime.Now.AddYears(-15)
        };
        
        var categoriaReceita = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };
        
        var categoriaDespesa = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Alimentação",
            Finalidade = Categoria.EFinalidade.Despesa
        };
        
        var categoriaAmbas = new Categoria
        {
            Id = Guid.NewGuid(),
            Descricao = "Outros",
            Finalidade = Categoria.EFinalidade.Ambas
        };
        
        var transacao1 = new Transacao
        {
            Id = Guid.NewGuid(),
            Descricao = "Transação 1",
            Valor = 1000,
            Tipo = Transacao.ETipo.Receita,
            Data = DateTime.Now
        };
        
        var transacao2 = new Transacao
        {
            Id = Guid.NewGuid(),
            Descricao = "Transação 2",
            Valor = 500,
            Tipo = Transacao.ETipo.Despesa,
            Data = DateTime.Now
        };
        
        var pessoaRepo = CreatePessoaRepository();
        var pessoas = new List<Pessoa> { pessoaMaior, pessoaMenor };
        pessoaRepo.GetByIdAsync(Arg.Any<Guid>())
            .Returns(callInfo => pessoas.FirstOrDefault(p => p.Id == callInfo.Arg<Guid>()));
        pessoaRepo.GetAllAsync().Returns(Task.FromResult((IEnumerable<Pessoa>)pessoas));
        
        var categoriaRepo = CreateCategoriaRepository();
        var categorias = new List<Categoria> { categoriaReceita, categoriaDespesa, categoriaAmbas };
        categoriaRepo.GetByIdAsync(Arg.Any<Guid>())
            .Returns(callInfo => categorias.FirstOrDefault(c => c.Id == callInfo.Arg<Guid>()));
        categoriaRepo.GetAllAsync().Returns(Task.FromResult((IEnumerable<Categoria>)categorias));
        
        var transacaoRepo = CreateTransacaoRepository();
        var transacoes = new List<Transacao> { transacao1, transacao2 };
        transacaoRepo.GetByIdAsync(Arg.Any<Guid>())
            .Returns(callInfo => transacoes.FirstOrDefault(t => t.Id == callInfo.Arg<Guid>()));
        transacaoRepo.GetAllAsync().Returns(Task.FromResult((IEnumerable<Transacao>)transacoes));
        
        // Configurar GetPagedAsync para retornar os dados de teste
        transacaoRepo.GetPagedAsync(Arg.Any<MinhasFinancas.Domain.ValueObjects.PagedRequest>(), Arg.Any<MinhasFinancas.Domain.Interfaces.ISpecification<Transacao, object>>())
            .Returns(callInfo =>
            {
                var spec = callInfo.Arg<MinhasFinancas.Domain.Interfaces.ISpecification<Transacao, object>>();
                var results = transacoes.AsQueryable();
                
                if (spec.Where != null)
                {
                    results = results.Where(spec.Where);
                }
                
                if (spec.OrderBy != null)
                {
                    results = spec.OrderByDescending
                        ? results.OrderByDescending(spec.OrderBy)
                        : results.OrderBy(spec.OrderBy);
                }
                
                var pageRequest = callInfo.Arg<MinhasFinancas.Domain.ValueObjects.PagedRequest>();
                var page = pageRequest?.Page ?? 1;
                var pageSize = pageRequest?.PageSize ?? 10;
                var totalCount = results.Count();
                var items = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                
                var pagedResult = new MinhasFinancas.Domain.ValueObjects.PagedResult<object>
                {
                    Items = items.Cast<object>(),
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize
                };
                
                return Task.FromResult(pagedResult);
            });
        
        unitOfWork.Pessoas.Returns(pessoaRepo);
        unitOfWork.Categorias.Returns(categoriaRepo);
        unitOfWork.Transacoes.Returns(transacaoRepo);
        unitOfWork.SaveChangesAsync().Returns(1);
        
        return unitOfWork;
    }
}