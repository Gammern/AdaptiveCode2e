using System;
using System.Collections.Generic;
using System.Text;

namespace MyAccounting.Model
{
    public interface IAccountFactory
    {
        AccountBase CreateAccount(AccountType type);
    }
}
