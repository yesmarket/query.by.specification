using System;
using System.Linq.Expressions;

namespace query.@by.specification.Specification
{
    public class NotSpecification<T> : BaseSpecification<T>
    {
        public NotSpecification(ISpecification<T> inner)
        {
            Inner = inner;
        }

        public ISpecification<T> Inner { get; set; }

        public override Expression<Func<T, bool>> GetPredicate()
        {
            var negated = Expression.Not(Inner.GetPredicate().Body);
            return Expression.Lambda<Func<T, bool>>(negated, Inner.GetPredicate().Parameters);
        }
    }
}