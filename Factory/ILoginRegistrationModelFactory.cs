﻿using HanifStore.Client.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public interface ILoginRegistrationModelFactory
    {
        public UserInformation userInformationModelFactory(Registration model , string userName); 
    }
}
