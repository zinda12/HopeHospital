﻿using HospitalAPI;

namespace HospitalTests.HospitalAPITests.Setup
{
    public class BaseIntegrationTest : IClassFixture<TestDatabaseFactory<Startup>>
    {
        protected TestDatabaseFactory<Startup> Factory { get; }

        public BaseIntegrationTest(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
