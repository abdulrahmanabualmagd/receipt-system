using Core.Models;
using System.Linq.Expressions;

namespace Core.Specifications.BaseSpecifications
{
    public interface ISpecifications<T> where T : Entity
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> IncludeExpressions { get; }
        Expression<Func<T, object>> OrderByExpression { get; }
        Expression<Func<T, object>> OrderByDescExpression { get; }
        int Take { get; set; }
        int Skip { get; set; }
        bool IsPageInationEnabled { get; set; }
    }
}
