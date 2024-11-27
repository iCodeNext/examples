using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core.Interfaces;

namespace Application.Infrastructure.Services.NotificationServices
{
    public class EmailService : INotificationService
    {
        public void Send()
        {
            Console.WriteLine("Sending Email....");
        }
    }
}
