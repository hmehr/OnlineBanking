﻿using System;
using System.Linq.Expressions;

namespace INSE6260.OnlineBanking.Infrastructure.Specifications
{
    
    public sealed class AndSpecification<TEntity> : CompositeSpecification<TEntity> where TEntity : class
    {
        #region Fields

        private readonly SpecificationBase<TEntity> _LeftSideSpecification;

        private readonly SpecificationBase<TEntity> _RightSideSpecification;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AndSpecification&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="leftSide">The left side.</param>
        /// <param name="rightSide">The right side.</param>
        /// <remarks></remarks>
        public AndSpecification(SpecificationBase<TEntity> leftSide, SpecificationBase<TEntity> rightSide)
        {
            if (leftSide == null)
            {
                throw new ArgumentNullException("leftSide");
            }

            if (rightSide == null)
            {
                throw new ArgumentNullException("rightSide");
            }

            _LeftSideSpecification = leftSide;
            _RightSideSpecification = rightSide;
        }

        #endregion

        #region Properties
        
        /// <summary>
        /// Left side specification
        /// </summary>
        public override SpecificationBase<TEntity> LeftSideSpecification
        {
            get { return _LeftSideSpecification; }
        }

        /// <summary>
        /// Right side specification
        /// </summary>
        public override SpecificationBase<TEntity> RightSideSpecification
        {
            get { return _RightSideSpecification; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a boolean expression which determines whether the specification is satisfied.
        /// </summary>
        /// <returns>Expression that evaluates whether the specification satifies the expression.</returns>
        public override Expression<Func<TEntity, Boolean>> IsSatisfiedBy()
        {
            Expression<Func<TEntity, Boolean>> left = _LeftSideSpecification.IsSatisfiedBy();
            Expression<Func<TEntity, Boolean>> right = _RightSideSpecification.IsSatisfiedBy();

            return (left.And(right));
        }

        #endregion
    }
}