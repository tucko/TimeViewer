using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Core
{
    //A module command concrete class with parameter and output type
    public class ModuleCommand<InType, OutType> : ICommand
    {
        //This delegate will point to a function
        private Func<InType, OutType> _paramAction;

        //Constructor receiving the delegate as parameter
        public ModuleCommand(Func<InType, OutType> paramAction_)
        {
            _paramAction = paramAction_;
        }

        //Execute the delegate
        public OutType Execute(InType param_)
        {
            if (_paramAction != null)
                return _paramAction.Invoke(param_);
            else
                return default(OutType);
        }
    }

    //A module command concrete class with only output type
    public class ModuleCommand<OutType> : ICommand
    {
        //This delegate will point to a function
        private Func<OutType> _action;

        //Constructor receiving the delegate as parameter
        public ModuleCommand(Func<OutType> action_)
        {
            _action = action_;
        }

        //Execute the delegate
        public OutType Execute()
        {
            if (_action != null)
                return _action.Invoke();
            else
                return default(OutType);
        }
    }
}
