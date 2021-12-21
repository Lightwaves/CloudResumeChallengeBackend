using System;
using System.Net;


namespace CloudResumeChallengeBackend.Repository
{

    public class VisitorsRepository : BaseRepository
    {

        public VisitorsRepository(string cs) : base(cs)
        {


        }
        public uint GetTotalVisitors() {


            return QuerySingle<uint>("select count(*) from Visitors");
            
            
        
        
        }
        public void InsertVisitor(DateTime date, IPAddress ip, string useragent, short width, short height) {
            var parameters = new { visit_time = date, ip = ip, user_agent = useragent, width = width, height = height };
            Execute("insert into Visitors (visit_time, ip, user_agent, width, height) VALUES (@visit_time, @ip, @user_agent, @width, @height)", parameters);
        
        }
        
    }
}
