namespace PostgreSQL.CQRS.Base.Query;

public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
{
    Task<TResult> Handle(TQuery query);
}