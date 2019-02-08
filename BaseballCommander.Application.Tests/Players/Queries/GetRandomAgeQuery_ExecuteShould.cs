using System;
using BaseballCommander.Application.Players.Queries.GetRandomAge;
using BaseballCommander.Domain.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseballCommander.Application.Tests.Players.Queries
{
    [TestClass]
    public class GetRandomAgeQuery_ExecuteShould : BaseTest
    {
        private readonly GetRandomAgeQuery _randomAgeQuery;

        public GetRandomAgeQuery_ExecuteShould()
        {
            _randomAgeQuery = new GetRandomAgeQuery();
        }

        [TestMethod]
        public void ReturnBetween17And19WhenHighSchool()
        {
            try
            {
                var age = _randomAgeQuery.Execute(PlayerStatus.HighSchool);
                Assert.IsTrue(age >= 17 && age <= 19, $"Age is: {age}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ReturnBetween18And23WhenCollege()
        {
            try
            {
                var age = _randomAgeQuery.Execute(PlayerStatus.College);
                Assert.IsTrue(age >= 18 && age <= 23, $"Age is: {age}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ReturnBetween18And36WhenFreeAgent()
        {
            try
            {
                var age = _randomAgeQuery.Execute(PlayerStatus.FreeAgent);
                Assert.IsTrue(age >= 18 && age <= 36, $"Age is: {age}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ReturnExceptionWhenAcquired()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var age = _randomAgeQuery.Execute(PlayerStatus.Acquired);
            });
        }
    }
}