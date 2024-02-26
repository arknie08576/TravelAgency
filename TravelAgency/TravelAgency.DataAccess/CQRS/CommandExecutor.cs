using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.CQRS.Commands;

namespace TravelAgency.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly TravelAgencyContex contex;
        public CommandExecutor(TravelAgencyContex contex) {
            this.contex = contex;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.contex);
        }
    }
}
