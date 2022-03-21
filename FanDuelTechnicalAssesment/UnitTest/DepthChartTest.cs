using System;
using FanDuel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FanDuel.Enums;

namespace FanDuelTest
{
    [TestClass]
    public class DepthChartTest
    {
        private Team _testTeam;
        private Seed _seed;

        [TestInitialize]
        public void Init()
        {
            _seed = new Seed();
        }

        [TestMethod]
        public void GetPlayerDepth_ShouldReturnNegative()
        {
            _testTeam = _seed.SeedTestDataForAddingPlayer();
            var result = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.QB, Seed.KyleTrask);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void AddPlayerWithPositionDepth_ShouldReturnFalse()
        {
            _testTeam = _seed.SeedTestDataForAddingPlayer();

            var result = _testTeam.CurrentDepthChart.AddPlayer(Position.QB, Seed.KyleTrask, 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddPlayerWithPositionDepth_ShouldReturnTrue()
        {
            _testTeam = _seed.SeedTestDataForAddingPlayer();

            var result = _testTeam.CurrentDepthChart.AddPlayer(Position.QB, Seed.TomBrady, 0);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void AddPlayerWithPositionDepth_ShouldAddAtPositionDepth()
        {
            _testTeam = _seed.SeedTestDataForAddingPlayer();

            _testTeam.CurrentDepthChart.AddPlayer(Position.QB, Seed.TomBrady, 0);
            _testTeam.CurrentDepthChart.AddPlayer(Position.QB, Seed.KyleTrask, 1);

            var result = _testTeam.CurrentDepthChart.AddPlayer(Position.QB, Seed.BlaineGabbert, 1);
            Assert.IsTrue(result);

            var depth = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.QB, Seed.BlaineGabbert);
            Assert.AreEqual(1, depth);

            depth = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.QB, Seed.KyleTrask);
            Assert.AreEqual(2, depth);
        }

        [TestMethod]
        public void AddPlayerWitouthPositionDepth_ShouldAddAtTheEnd()
        {
            _testTeam = _seed.SeedTestDataForAddingPlayer();

            _testTeam.CurrentDepthChart.AddPlayer(Position.LWR, Seed.MikeEvans);
            _testTeam.CurrentDepthChart.AddPlayer(Position.LWR, Seed.JaelonDarden);

            var depth = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.LWR, Seed.MikeEvans);
            Assert.AreEqual(0, depth);

            depth = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.LWR, Seed.JaelonDarden);
            Assert.AreEqual(1, depth);
        }

        [TestMethod]
        public void RemovePlayer_ShouldReturnEmptyList()
        {
            _testTeam = _seed.SeedTestDataForRemovingPlayer();

            var result = _testTeam.CurrentDepthChart.RemovePlayer(Position.LWR, Seed.TomBrady);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void RemovePlayer_ShouldReturnListWithPlayer()
        {
            _testTeam = _seed.SeedTestDataForRemovingPlayer();

            var result = _testTeam.CurrentDepthChart.RemovePlayer(Position.QB, Seed.TomBrady);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(Seed.TomBrady, result[0]);
        }

        [TestMethod]
        public void RemovePlayer_ShouldMoveUpOtherPlayers()
        {
            _testTeam = _seed.SeedTestDataForRemovingPlayer();
            var depth = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.QB, Seed.TomBrady);
            Assert.AreEqual(0, depth);

            _testTeam.CurrentDepthChart.RemovePlayer(Position.QB, Seed.TomBrady);

            depth = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.QB, Seed.BlaineGabbert);
            Assert.AreEqual(0, depth);

            depth = _testTeam.CurrentDepthChart.GetPlayerDepth(Position.QB, Seed.KyleTrask);
            Assert.AreEqual(1, depth);
        }

        [TestMethod]
        public void GetBackup_ShouldReturnEmptyList()
        {
            _testTeam = _seed.SeedTestDataForGetBackup();

            var result = _testTeam.CurrentDepthChart.GetBackups(Position.QB, Seed.KyleTrask);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetBackup_ShouldReturnListWithTwoPlayers()
        {
            _testTeam = _seed.SeedTestDataForGetBackup();

            var result = _testTeam.CurrentDepthChart.GetBackups(Position.QB, Seed.TomBrady);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(Seed.BlaineGabbert, result[0]);
            Assert.AreEqual(Seed.KyleTrask, result[1]);
        }
    }
}
