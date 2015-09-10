using System.Net.Mail;
using System.Text;
using AutoMapper;
using UserManagement.Domain.Entities.Commands.Email;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Email
{
    public class EmailMessageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<EmailMessage, MailMessage>()
                .ForMember(d => d.To, opt => opt.MapFrom(x => new MailAddressCollection {string.Join(",", x.ToAddresses)}))
                .ForMember(d => d.IsBodyHtml, opt => opt.MapFrom(x => true))
                .ForMember(d => d.BodyEncoding, opt => opt.MapFrom(x => Encoding.UTF8));
        }
    }
}