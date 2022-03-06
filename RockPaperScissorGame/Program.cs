//  -------------------------------------------------------------------------
//  <copyright file="Program.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Main Entry Point For Rock Paper Scissor Game
//  </summary>
//  -------------------------------------------------------------------------

namespace RockPaperScissorGame
{
    using RockPaperScissorGame.Class;
    public class Program
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        static void Main(string[] args)
        {
            new PlayGame().Startup();
        }
    }
}
