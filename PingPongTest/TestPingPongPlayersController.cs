using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.Data;
using PingPong.Models.PingPong;
using System.Web.Http.Results;
using System.Net;

namespace PingPongTest
{
    [TestClass]
    public class TestPingPongPlayersController
    {
        [TestMethod]
        public void PostPlayer_ShouldReturnSamePlayer()
        {
            var controller = new PingPong.Models.PingPong.PingPongPlayersController(new TestPlayerAppContext());
            var player = GetDemoPlayer();
            var result = controller.PostPingPongPlayers(player) as CreatedAtRouteNegotiatedContentResult<PingPongPlayers>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Email, player.Email);
        }

        [TestMethod]
        public void PutPlayer_ShouldReturnStatusCode()
        {
            var controller = new PingPong.Models.PingPong.PingPongPlayersController(new TestPlayerAppContext());

            var player = GetDemoPlayer();

            var result = controller.PutPingPongPlayers(player.Id, player) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void GetPlayer_ShouldReturnSamePlayer()
        {
            var context = new TestPlayerAppContext();
            context.PingPongPlayers.Add(new PingPongPlayers { Id = 100, FirstName = "Michael1", LastName = "Aushana", Email = "michaelaushana@gmail.com", Age = 37, SkillLevelId = 1 });
            context.PingPongPlayers.Add(new PingPongPlayers { Id = 101, FirstName = "Michael2", LastName = "Aushana", Email = "michaelaushana@gmail.com", Age = 37, SkillLevelId = 1 });
            context.PingPongPlayers.Add(new PingPongPlayers { Id = 102, FirstName = "Michael3", LastName = "Aushana", Email = "michaelaushana@gmail.com", Age = 37, SkillLevelId = 1 });
            var controller = new PingPong.Models.PingPong.PingPongPlayersController(context);
            var result = controller.GetPingPongPlayers() as TestPlayerDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeletePlayer_ShouldReturnOK()
        {
            var context = new TestPlayerAppContext();
            var player = GetDemoPlayer();
            context.PingPongPlayers.Add(player);

            var controller = new PingPong.Models.PingPong.PingPongPlayersController(context);
            var result = controller.DeletePingPongPlayers(100) as OkNegotiatedContentResult<PingPongPlayers>;

            Assert.IsNotNull(result);
            Assert.AreEqual(player.Id, result.Content.Id);
        }

        PingPongPlayers GetDemoPlayer()
        {
            return new PingPongPlayers() { Id = 100, FirstName = "Michael", LastName = "Aushana", Email = "michaelaushana@gmail.com", Age = 37, SkillLevelId = 1 };
        }
    }
}
