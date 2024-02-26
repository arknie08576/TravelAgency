using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.CQRS.Queries;

namespace TravelAgency.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly TravelAgencyContex contex;
        public QueryExecutor(TravelAgencyContex contex)
        {
            this.contex = contex;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(contex);
        }
    }
}
