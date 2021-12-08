using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Npgsql;
using CloudResumeChallengeBackend.Repository;
namespace CloudResumeChallenge.Tests.StepDefinitions
{

    [Binding]
    public sealed class DBConnectSteps
    {
        VisitorsRepository repo = null;


        [Given (@"a connection string")]

        public void GivenConnectionString() { 
            
            
        
        }

    }
}
