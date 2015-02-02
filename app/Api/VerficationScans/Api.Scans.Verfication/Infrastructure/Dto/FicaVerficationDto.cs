using System;

namespace Api.Scans.Verfication.Infrastructure.Dto
{
    public class FicaVerficationResponseDto
    {
        public FicaVerficationResponseDto(long idNumber, Guid transactionToken, string initials, string surname,
            string cellNumer, string lifeStatus,
            DateTime? dateOfBirth, DateTime responseDate)
        {
            IdNumber = idNumber;
            TransactionToken = transactionToken;
            Initials = initials;
            Surname = surname;
            CellNumber = cellNumer;
            LifeStatus = lifeStatus;
            DateOfBirth = dateOfBirth;
            ResponseDate = responseDate;
        }

        public Guid TransactionToken { get; private set; }
        public long IdNumber { get; private set; }
        public string Initials { get; private set; }
        public string Surname { get; private set; }
        public string CellNumber { get; private set; }
        public string LifeStatus { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public DateTime ResponseDate { get; private set; }
    }

    public class FicaVerficationRequestDto
    {
        public FicaVerficationRequestDto()
        {

        }

        public FicaVerficationRequestDto(long idNumber, string userName, int ficaTransactionId, Guid transactionToken)
        {
            IdNumber = idNumber;
            Username = userName;
            FicaTransactionId = ficaTransactionId;
            TransactionToken = transactionToken;
        }

        public long IdNumber { get; private set; }
        public string Username { get; private set; }
        public int FicaTransactionId { get; private set; }
        public Guid TransactionToken { get; private set; }

        public DateTime RequestDate
        {
            get { return DateTime.UtcNow; }
        }
    }
}