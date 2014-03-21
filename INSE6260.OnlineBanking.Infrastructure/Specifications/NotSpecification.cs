using System;
using System.Linq;
using System.Linq.Expressions;

namespace INSE6260.OnlineBanking.Infrastructure.Specifications
{
    public sealed class NotSpecification<TEntity> : SpecificationBase<TEntity> where TEntity : class
    {
        #region Fields

        private readonly Expression<Func<TEntity, Boolean>> _OriginalCriteria;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="originalSpecification">The original specification.</param>
        /// <remarks></remarks>
        public NotSpecification(SpecificationBase<TEntity> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            _OriginalCriteria = originalSpecification.IsSatisfiedBy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="originalSpecification">The original specification.</param>
        /// <remarks></remarks>
        public NotSpecification(Expression<Func<TEntity, Boolean>> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            _OriginalCriteria = originalSpecification;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a boolean expression which determines whether the specification is satisfied.
        /// </summary>
        /// <returns>Expression that evaluates whether the specification satifies the expression.</returns>
        public override Expression<Func<TEntity, Boolean>> IsSatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, Boolean>>(Expression.Not(_OriginalCriteria.Body), _OriginalCriteria.Parameters.Single());
        }

        #endregion
    }
}