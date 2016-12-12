using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChallongeCSharp.Tests
{
    [TestClass]
    public class TestChallongeController
    {
        [TestMethod]
        public void TestCreateParticipants()
        {
            string[] names = new string[] { "John", "Bob" ,"Sal", "Suzie","Trevor","Anna","Rico","Suave"};
            //System.Collections.ArrayList namesAL = new System.Collections.ArrayList(names);
            string[] seeds = new string[] { "4","3","2","1"};
            //System.Collections.ArrayList seedsAL = new System.Collections.ArrayList(seeds);

            
                ChallongeController challonge = new ChallongeController();

            challonge.CreateParticipants("testbulk", names);
            


            






        }
    }
}
