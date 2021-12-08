using Dapper;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;

namespace CloudResumeChallengeBackend.Repository
{

    public class VisitorsRepository : BaseRepository
    {

        public VisitorsRepository(string cs) : base(cs)
        {
            
        }
        public uint GetTotalVisitors() {


            return base.QuerySingle<uint>("select sum(count(*)) from Visitors");
        
        
        }
    }
}
