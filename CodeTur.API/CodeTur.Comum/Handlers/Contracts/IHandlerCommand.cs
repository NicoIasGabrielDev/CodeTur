using CodeTur.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Handlers.Contracts
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
