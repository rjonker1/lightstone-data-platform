using System;
using System.Collections.Generic;
using LightstoneApp.Application.PackageBuilderModule.Seedwork.Resources;

namespace LightstoneApp.Application.PackageBuilderModule.Seedwork
{
    /// <summary>
    /// The custom exception for validation errors
    /// </summary>
    public class ApplicationValidationErrorsException : Exception
    {
        #region Properties

        private readonly IEnumerable<string> _validationErrors;

        /// <summary>
        /// Get or set the validation errors messages
        /// </summary>
        public IEnumerable<string> ValidationErrors
        {
            get { return _validationErrors; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create new instance of Application validation errors exception
        /// </summary>
        /// <param name="validationErrors">The collection of validation errors</param>
        public ApplicationValidationErrorsException(IEnumerable<string> validationErrors) : base(Messages.exception_ApplicationValidationExceptionDefaultMessage)
        {
            _validationErrors = validationErrors;
        }

        #endregion
    }
}