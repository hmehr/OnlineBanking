using System;
using System.Linq.Expressions;

namespace INSE6260.OnlineBanking.Infrastructure.Specifications
{
    
    public abstract class SpecificationBase<TEntity> where TEntity : class
    {
        #region Operator Overrides

        /// <summary>
        ///  And operator
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this AND operation</param>
        /// <param name="rightSideSpecification">right operand in this AND operation</param>
        /// <returns>New specification</returns>
        public static SpecificationBase<TEntity> operator &(SpecificationBase<TEntity> leftSideSpecification, SpecificationBase<TEntity> rightSideSpecification)
        {
            return new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        /// Or operator
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this OR operation</param>
        /// <param name="rightSideSpecification">right operand in this OR operation</param>
        /// <returns>New specification </returns>
        public static SpecificationBase<TEntity> operator |(SpecificationBase<TEntity> leftSideSpecification, SpecificationBase<TEntity> rightSideSpecification)
        {
            return new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        /// Not specification
        /// </summary>
        /// <param name="specification">Specification to negate</param>
        /// <returns>New specification</returns>
        public static SpecificationBase<TEntity> operator !(SpecificationBase<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }

        /// <summary>
        /// Override operator false, only for support AND OR operators
        /// </summary>
        /// <param name="specification">Specification instance</param>
        /// <returns>See False operator in C#</returns>
        public static Boolean operator false(SpecificationBase<TEntity> specification)
        {
            return false;
        }

        /// <summary>
        /// Override operator True, only for support AND OR operators
        /// </summary>
        /// <param name="specification">Specification instance</param>
        /// <returns>See True operator in C#</returns>
        public static Boolean operator true(SpecificationBase<TEntity> specification)
        {
            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a boolean expression which determines whether the specification is satisfied.
        /// </summary>
        /// <returns>Expression that evaluates whether the specification satifies the expression.</returns>
        public abstract Expression<Func<TEntity, Boolean>> IsSatisfiedBy();

        #endregion
    }
}