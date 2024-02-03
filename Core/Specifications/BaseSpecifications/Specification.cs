using Core.Entities.BaseEntity;
using System.Linq.Expressions;

namespace Core.Specifications.BaseSpecifications
{
    public class Specifications<T> : ISpecifications<T> where T : Entity
    {
        #region Ctor and Criteria Setter
        public Specifications() { }
        public Specifications(Expression<Func<T, bool>> cretieria)
            => Criteria = cretieria;
        #endregion

        #region Interface Implmentation
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; private set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderByExpression { get; private set; }
        public Expression<Func<T, object>> OrderByDescExpression { get; private set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPageInationEnabled { get; set; }
        #endregion

        #region Property Setters
        protected void AddInclude(Expression<Func<T, object>> includeExpressions)
            => IncludeExpressions.Add(includeExpressions);

        protected void AddOrderBy(Expression<Func<T, object>> orderByExrepssion)
            => OrderByExpression = orderByExrepssion;

        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
            => OrderByDescExpression = orderByDescExpression;

        protected void ApplyingPagination(int skip, int take)
        {
            IsPageInationEnabled = true;
            Skip = skip;
            Take = take;
        }
        #endregion
    }
}
