namespace INSE6260.OnlineBanking.Infrastructure.Specifications
{
    public abstract class CompositeSpecification<TEntity> : SpecificationBase<TEntity> where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Gets the left side specification for this composite element.
        /// </summary>
        /// <remarks></remarks>
        public abstract SpecificationBase<TEntity> LeftSideSpecification { get; }

        /// <summary>
        /// Gets the right side specification for this composite element.
        /// </summary>
        public abstract SpecificationBase<TEntity> RightSideSpecification { get; }

        #endregion
    }
}