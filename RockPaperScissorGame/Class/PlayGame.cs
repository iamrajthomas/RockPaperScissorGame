// -----------------------------------------------------------
//  <copyright file="PlayGame.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Game Class Takes Care of Starting/Resuming Rock Paper Scissor
//  </summary>
//  -------------------------------------------------------------------------

namespace RockPaperScissorGame.Class
{
    using RockPaperScissorGame.Enum;
    using RockPaperScissorGame.Interface;
    using System;
    using System.Linq;

    public class PlayGame : IPlayGame
    {
        private readonly IReadAppConfigData _readAppConfigData = null;
        public PlayGame()
        {
            _readAppConfigData = new ReadAppConfigData();
        }

        /// <summary>
        /// Only Public Member responsible for starting the game
        /// </summary>
        public void Startup()
        {
            try
            {
                Console.WriteLine("================================ LET THE GAME START ================================\n");
                PlayRockPaperScissor();
                Console.WriteLine("================================= LET THE GAME END =================================\n");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n************* ERROR IN GAME *************\n {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Private PlayRockPaperScissor member for Game Logic
        /// </summary>
        private void PlayRockPaperScissor()
        {
            int PlayerScore = 0;
            int ComputerScore = 0;
            int MatchNumber = 1;
            int DefaultNumberOfMatches = 3;
            var TotalNumberOfMatches = _readAppConfigData.ReadValueByKey("TotalNumberOfMatches") != null ? Convert.ToInt32(_readAppConfigData.ReadValueByKey("TotalNumberOfMatches")) : DefaultNumberOfMatches;

            while (MatchNumber <= TotalNumberOfMatches)
            {
                Console.WriteLine(String.Format("{0}================================ Match : {1} ==========================================", MatchNumber > 1 ? "\n" : "", MatchNumber));
                Console.WriteLine(String.Format("Current Score of Player : {0} and Current Score of Computer : {1}", PlayerScore, ComputerScore));
                Console.WriteLine(String.Format("===================================================================================== "));

                string PlayerInputValueFormatter = PlayerData();

                Random rand = new Random();
                int ComputerInputValue = rand.Next(1, 4);

                Console.WriteLine(String.Format("Computer Chose Value: {0}", ComputerInputValue == 1 ? "Rock" : ComputerInputValue == 2 ? "Paper" : "Scissor"));

                Console.ForegroundColor = ConsoleColor.Green;
                switch (PlayerInputValueFormatter)
                {
                    case "R":
                        if (ComputerInputValue.Equals((int)GamePiece.Rock))
                        {
                            Console.WriteLine("This match is Draw.");
                        }
                        else if (ComputerInputValue.Equals((int)GamePiece.Paper))
                        {
                            Console.WriteLine("Player Wins.");
                            PlayerScore += 1;
                        }
                        else if (ComputerInputValue.Equals((int)GamePiece.Scissor))
                        {
                            Console.WriteLine("Computer Wins");
                            ComputerScore += 1;
                        }
                        break;

                    case "P":
                        if (ComputerInputValue.Equals((int)GamePiece.Rock))
                        {
                            Console.WriteLine("Player Wins.");
                            PlayerScore += 1;
                        }
                        else if (ComputerInputValue.Equals((int)GamePiece.Paper))
                        {
                            Console.WriteLine("This match is Draw.");
                        }
                        else if (ComputerInputValue.Equals((int)GamePiece.Scissor))
                        {
                            Console.WriteLine("Computer Wins");
                            ComputerScore += 1;
                        }
                        break;

                    case "S":
                        if (ComputerInputValue.Equals((int)GamePiece.Rock))
                        {
                            Console.WriteLine("Computer Wins");
                            ComputerScore += 1;
                        }
                        else if (ComputerInputValue.Equals((int)GamePiece.Paper))
                        {
                            Console.WriteLine("Player Wins.");
                            PlayerScore += 1;
                        }
                        else if (ComputerInputValue.Equals((int)GamePiece.Scissor))
                        {
                            Console.WriteLine("This match is Draw.");

                        }
                        break;

                    default:
                        Console.WriteLine("This is not handled in default block.");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                MatchNumber += 1;

                if (MatchNumber == TotalNumberOfMatches + 1)
                {
                    Console.WriteLine(String.Format("{0}======================== Final Score After Match : {1} ==================================", MatchNumber > 1 ? "\n" : "", MatchNumber - 1));
                    Console.WriteLine(String.Format("Current Score of Player : {0} and Current Score of Computer : {1}", PlayerScore, ComputerScore));
                    Console.WriteLine(String.Format("======================================================================================= "));

                    Console.ForegroundColor = ConsoleColor.Green;
                    if (PlayerScore > ComputerScore)
                    {
                        Console.WriteLine("\n\nFinal Result ========> Player won the match. \n");
                    }
                    else if (PlayerScore < ComputerScore)
                    {
                        Console.WriteLine("\n\nFinal Result ========> Computer won the match. \n");
                    }
                    else
                    {
                        Console.WriteLine("\n\nFinal Result ========> The Game is drawn. \n");
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("DO YOU WANT TO PLAY AGAIN (Y/N) ? ");
                    string PlayAgain = Console.ReadLine();

                    if (PlayAgain.ToUpper() == "Y")
                    {
                        PlayerScore = 0;
                        ComputerScore = 0;
                        MatchNumber = 1;
                        Console.Clear();
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            Console.WriteLine("========================================================================");
        }

        /// <summary>
        /// Private PlayerData member for Receiving Player Data with Recusion
        /// </summary>
        private string PlayerData()
        {
            string PlayerInputValue = string.Empty;
            string PlayerInputValueFormatter = string.Empty;
            Console.Write("Choose one from [ROCK, PAPER AND SCISSOR]: ");
            PlayerInputValue = Console.ReadLine();
            PlayerInputValueFormatter = !string.IsNullOrEmpty(PlayerInputValue) ? PlayerInputValue.ToUpper().First().ToString() : null;

            if (PlayerInputValueFormatter != "R" && PlayerInputValueFormatter != "P" && PlayerInputValueFormatter != "S")
            {
                PlayerInputValueFormatter = string.Empty;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player has given a wrong input. ");
                Console.ForegroundColor = ConsoleColor.Gray;

                PlayerInputValueFormatter = PlayerData();
            }

            return PlayerInputValueFormatter;
        }
    }
}
