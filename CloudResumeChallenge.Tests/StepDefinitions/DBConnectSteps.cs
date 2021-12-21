using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Npgsql;
using CloudResumeChallengeBackend.Repository;
using CloudResumeChallengeBackend.Util;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CloudResumeChallenge.Tests.StepDefinitions
{
    
    [Binding]
    public sealed class DBConnectSteps
    {
        
        VisitorsRepository repo = null;

        [Given (@"a connection string")]
        public void GivenConnectionString() {
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);
            var cs = System.Environment.GetEnvironmentVariable("ConnectionString");
            repo = new VisitorsRepository(cs);
            
        
        }


        [Then(@"I should successfully connect to a database")]
        public void ThenIShouldSuccessfullyConnectToADatabase()
        {
            
            Assert.True(repo.GetTotalVisitors() >= 0);
            
        }

    }
}
