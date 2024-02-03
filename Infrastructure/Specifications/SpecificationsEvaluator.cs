using Core.Entities.BaseEntity;
using Core.Specifications.BaseSpecifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Specifications
{
    internal static class SpecificationsEvaluator
    {
        public static IQueryable<T> GetQuery<T>( IQueryable<T> query, ISpecifications<T> specs ) where T : Entity
        {
            if (specs.Criteria != null) 
                query = query.Where(specs.Criteria);

            if (specs.IsPageInationEnabled)
                query = query.Skip(specs.Skip).Take(specs.Take);

            if (specs.OrderByExpression != null)
                query = query.OrderBy(specs.OrderByExpression);

            if (specs.OrderByDescExpression != null)
                query = query.OrderByDescending(specs.OrderByDescExpression);

            query = specs.IncludeExpressions.Aggregate(query, (currentQuery, currentExpression) => currentQuery.Include(currentExpression));

            return query;
        }
    }
}
