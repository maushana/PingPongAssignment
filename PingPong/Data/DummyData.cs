using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PingPong.Models.PingPong;

namespace PingPong.Data
{
    public class DummyData
    {
        public static List<PingPongSkillLevel> getSkillLevels()
        {
            List<PingPongSkillLevel> skillLevels = new List<PingPongSkillLevel>()
            {
                new PingPongSkillLevel()
                {
                    SkillLevel="Beginner"
                },
                new PingPongSkillLevel()
                {
                    SkillLevel="Intermediate"
                },
                new PingPongSkillLevel()
                {
                    SkillLevel="Advanced"
                },
                new PingPongSkillLevel()
                {
                    SkillLevel="Expert"
                }
            };

            return skillLevels;
        }

        public static List<PingPongPlayers> getPingPongPlayers(PingPongContext context)
        {
            List<PingPongPlayers> players = new List<PingPongPlayers>()
            {
                new PingPongPlayers()
                {
                    FirstName = "Michael",
                    LastName = "Aushana",
                    Age = 42,
                    Email = "michaelaushana@gmail.com",
                    SkillLevelId = context.SkillLevels.Find(1).Id
                },
                new PingPongPlayers()
                {
                    FirstName = "Rob",
                    LastName = "White",
                    Age = 35,
                    Email = "robwhite@gmail.com",
                    SkillLevelId = context.SkillLevels.Find(2).Id
                },
                new PingPongPlayers()
                {
                    FirstName = "Jon",
                    LastName = "Smith",
                    Age = 32,
                    Email = "jonsmith@gmail.com",
                    SkillLevelId = context.SkillLevels.Find(3).Id
                }
            };

            return players;
        }
    }
}