using System;
using System.Linq.Expressions;

namespace LightstoneApp.Domain.Core.Specification
{
    /// <summary>
    ///     A logic AND Specification
    /// </summary>
    /// <typeparam name="T">Type of entity that check this specification</typeparam>
    public sealed class AndSpecification<T>
        : CompositeSpecification<T>
        where T : class
    {
        #region Members

        private readonly ISpecification<T> _LeftSideSpecification;
        private readonly ISpecification<T> _RightSideSpecification;

        #endregion

        #region Public Constructor

        /// <summary>
        ///     Default constructor for AndSpecification
        /// </summary>
        /// <param name="leftSide">Left side specification</param>
        /// <param name="rightSide">Right side specification</param>
        public AndSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == null)
                throw new ArgumentNullException("leftSide");

            if (rightSide == null)
                throw new ArgumentNullException("rightSide");

            _LeftSideSpecification = leftSide;
            _RightSideSpecification = rightSide;
        }

        #endregion

        #region Composite Specification overrides

        /// <summary>
        ///     Left side specification
        /// </summary>
        public override ISpecification<T> LeftSideSpecification
        {
            get { return _LeftSideSpecification; }
        }

        /// <summary>
        ///     Right side specification
        /// </summary>
        public override ISpecification<T> RightSideSpecification
        {
            get { return _RightSideSpecification; }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.ISpecification{T}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.ISpecification{T}" />
        /// </returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = _LeftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = _RightSideSpecification.SatisfiedBy();

            return (left.And(right));
        }

        #endregion
    }
}