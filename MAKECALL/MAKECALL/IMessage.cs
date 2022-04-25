using System;
using System.Collections.Generic;
using System.Text;

namespace MAKECALL
{
    public interface IMessage
    {
        void Longtime(string message);
        void ShortTime(string message);
    }
}
