﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public interface INotifiable
    {
        Task HandleNotification(Dictionary<string, object> message);
    }
}
