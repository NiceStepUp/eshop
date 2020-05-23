using eshop.Persistence.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Core
{
    public interface IEmailService
    {
        Task SendEmailAsync(MessageDto message);
    }
}
