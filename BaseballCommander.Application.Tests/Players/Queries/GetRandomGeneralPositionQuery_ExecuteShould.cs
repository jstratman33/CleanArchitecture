using System.Collections.Generic;
using System.Linq;
using BaseballCommander.Application.Players.Queries.GetRandomGeneralPosition;
using BaseballCommander.Domain.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseballCommander.Application.Tests.Players.Queries
{
    [TestClass]
    public class GetRandomGeneralPositionQuery_ExecuteShould
    {
        private readonly GetRandomGeneralPositionQuery _query;

        public GetRandomGeneralPositionQuery_ExecuteShould()
        {
            _query = new GetRandomGeneralPositionQuery();
        }

        [TestMethod]
        public void GeneratePositionsWithinMarginOfError()
        {
            const double marginOfError = 0.05;
            const double totalRuns = 10000;
            const double pitcherProbability = 0.52;
            const double catcherProbability = 0.08;
            const double positionProbability = 0.4;

            var positionList = new List<GeneralPosition>();
            for (var i = 0; i < totalRuns; ++i)
            {
                positionList.Add(_query.Execute());
            }

            var pitcherPct = positionList.Count(x => x == GeneralPosition.Pitcher) / totalRuns;
            var catcherPct = positionList.Count(x => x == GeneralPosition.Catcher) / totalRuns;
            var positionPct = positionList.Count(x => x == GeneralPosition.Position) / totalRuns;
            Assert.IsTrue(pitcherPct >= pitcherProbability - marginOfError && pitcherPct <= pitcherProbability + marginOfError, $"Pitcher percentage: {pitcherPct}");
            Assert.IsTrue(catcherPct >= catcherProbability - marginOfError && catcherPct <= catcherProbability + marginOfError, $"Catcher: percentage: {catcherPct}");
            Assert.IsTrue(positionPct >= positionProbability - marginOfError && positionPct <= positionProbability + marginOfError, $"Position percentage: {positionPct}");
        }
    }
}