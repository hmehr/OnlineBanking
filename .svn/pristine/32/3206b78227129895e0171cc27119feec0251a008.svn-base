using System;
using System.Linq.Expressions;

namespace INSE6260.OnlineBanking.Infrastructure.Specifications
{
   public sealed class AdHocSpecification<TEntity> : SpecificationBase<TEntity> where TEntity : class
    {
        #region Fields

        private readonly Expression<Func<TEntity, Boolean>> _MatchingCriteria;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdHocSpecification{TEntity}"/> class.
        /// </summary>
        /// <param name="matchingCriteria">The matching criteria.</param>
        /// <remarks></remarks>
        public AdHocSpecification(Expression<Func<TEntity, Boolean>> matchingCriteria)
        {
            if (matchingCriteria == null)
            {
                throw new ArgumentNullException("matchingCriteria");
            }

            _MatchingCriteria = matchingCriteria;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a boolean expression which determines whether the specification is satisfied.
        /// </summary>
        /// <returns>Expression that evaluates whether the specification satifies the expression.</returns>
        public override Expression<Func<TEntity, Boolean>> IsSatisfiedBy()
        {
            return _MatchingCriteria;
        }

        #endregion
    }
}