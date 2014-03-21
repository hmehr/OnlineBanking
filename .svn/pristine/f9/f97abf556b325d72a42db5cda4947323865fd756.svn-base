using System;
using System.Linq.Expressions;

namespace INSE6260.OnlineBanking.Infrastructure.Specifications
{
    public sealed class TrueSpecification<TEntity> : SpecificationBase<TEntity> where TEntity : class
    {
        #region Methods

        /// <summary>
        /// Returns a boolean expression which determines whether the specification is satisfied.
        /// </summary>
        /// <returns>Expression that evaluates whether the specification satifies the expression.</returns>
        public override Expression<Func<TEntity, Boolean>> IsSatisfiedBy()
        {
            Boolean result = true;
            Expression<Func<TEntity, Boolean>> trueExpression = t => result;

            return trueExpression;
        }

        #endregion
    }
}