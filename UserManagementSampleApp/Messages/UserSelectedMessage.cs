using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSampleApp.Messages
{
    public class UserSelectedMessage : ValueChangedMessage<int>
    {
        public UserSelectedMessage(int userId) : base(userId)
        {
        }
    }
}
