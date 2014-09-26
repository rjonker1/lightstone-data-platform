using System;
using System.Globalization;
using System.ServiceModel;
using Common.Logging;
using Lace.Request;
using Lace.Source.Jis.JisServiceReference;

namespace Lace.Source.Jis.Builder
{
    public class SessionManager : IBuildSession
    {
        public SessionManagementResult SessionManagement { get; private set; }
        private readonly JisWsInterfaceSoapClient _jisClient;
        private readonly ILog _log;
        private readonly ILaceRequest _request;

        private static string SessionName
        {
            get
            {
                return string.Format("{0} {1} LIGHTSTONE SESSION",
                    DateTime.Now.DayOfWeek.ToString().ToUpper(),
                    DateTime.Now.ToString("ddMMyyyy"));
            }
        }

        public SessionManager(JisWsInterfaceSoapClient jisClient, ILog log, ILaceRequest request)
        {
            _jisClient = jisClient;
            _log = log;
            _request = request;
        }

        public IBuildSession Build()
        {
            _log.Info("Creating a Jis Session");

            if(_jisClient.State == CommunicationState.Closed)
                _jisClient.Open();

            CreateSession();

            if(SessionIsNotValid())
                _log.Error("An existing session could not be found or created");

            return this;
        }


        private void CreateSession()
        {
            SessionManagement = _jisClient.SessionManagementProcess((int) JisSessionType.LatestSession, SessionName,
                _request.User.UserName);

            if (SessionIsNotValid() || SessionIsExpired())
            {
                CreateNewSession();
            }
        }

        private void CreateNewSession()
        {
            SessionManagement = _jisClient.SessionManagementProcess((int)JisSessionType.NewSession, SessionName,
                    _request.User.UserName);
        }

        private bool SessionIsNotValid()
        {
            return SessionManagement == null || (SessionManagement != null && SessionManagement.Error);
        }

        private bool SessionIsExpired()
        {
            if (SessionManagement == null || SessionManagement.Error || string.IsNullOrEmpty(SessionManagement.Name))
                return true;

            var parts = SessionManagement.Name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
                return true;

            var partDate = parts[1];
            var date = DateTime.MinValue;
            DateTime.TryParseExact(partDate, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            return (DateTime.Now - date).Days > 1;
        }

        private enum JisSessionType
        {
            NewSession = 0,
            LatestSession = 3
        }

    }
}
