﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinServUnitOfWork.Interface
{
   public interface IGoogleServices
    {
     // string SendEmail();
      bool GenerateUserTemplate(Guid UserGuid);
      bool GeneratePasswordTemplate(Guid UserGuid);

    }
}
