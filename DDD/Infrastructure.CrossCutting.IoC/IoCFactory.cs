// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================

using LightstoneApp.Infrastructure.CrossCutting.IoC.Unity;

namespace LightstoneApp.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    ///     IoCFactory  implementation
    /// </summary>
    public sealed class IoCFactory
    {
        #region Singleton

        private static readonly IoCFactory instance = new IoCFactory();

        /// <summary>
        ///     Get singleton instance of IoCFactory
        /// </summary>
        public static IoCFactory Instance
        {
            get { return instance; }
        }

        #endregion

        #region Members

        private readonly IContainer _CurrentContainer;

        /// <summary>
        ///     Get current configured IContainer
        ///     <remarks>
        ///         At this moment only IoCUnityContainer existss
        ///     </remarks>
        /// </summary>
        public IContainer CurrentContainer
        {
            get { return _CurrentContainer; }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Only for singleton pattern, remove before field init IL anotation
        /// </summary>
        static IoCFactory()
        {
        }

        private IoCFactory()
        {
            _CurrentContainer = new IoCUnityContainer();
        }

        #endregion
    }
}