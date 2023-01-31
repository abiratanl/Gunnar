using Gunnar.Contexts.SharedContext.UseCases.Contracts;

namespace Gunnar.Contexts.SharedContext.Repositories.Contracts;

public interface IBaseRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
{
}