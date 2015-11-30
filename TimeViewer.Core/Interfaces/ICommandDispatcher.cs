using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeViewer.Core.Interfaces
{
    public interface ICommandDispatcher
    {
        void Register(string key_, ICommand command_);
        O Execute<I, O>(string key_, I params_);
        O Execute<O>(string key_);

        bool CanExecute(string key_);
    }
}
