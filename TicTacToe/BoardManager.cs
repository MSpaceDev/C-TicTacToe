using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TicTacToe
{
	class BoardManager
	{
		public string[,] Board { get; set; }

		// Constructor
		public BoardManager()
		{
			CreateBoard();
		}

		private void CreateBoard()
		{
			Board = new string[3, 3]
			{ 
				{ "1", "2", "3" },
				{ "4", "5", "6" },
				{ "7", "8", "9" }
			};
		}

		// Redraws the board using 2D Board array
		public void DrawBoard()
		{
			Console.Clear();
			Console.WriteLine("       |       |       ");
			Console.WriteLine("   {0}   |   {1}   |   {2}", Board[0, 0], Board[0, 1], Board[0, 2]);
			Console.WriteLine("_______|_______|_______");
			Console.WriteLine("       |       |       ");
			Console.WriteLine("   {0}   |   {1}   |   {2}", Board[1, 0], Board[1, 1], Board[1, 2]);
			Console.WriteLine("_______|_______|_______");
			Console.WriteLine("       |       |       ");
			Console.WriteLine("   {0}   |   {1}   |   {2}", Board[2, 0], Board[2, 1], Board[2, 2]);
			Console.WriteLine("       |       |       ");
			Console.WriteLine("");
		}

		// Resets the board by running the constructor
		public void Reset()
		{
			CreateBoard();
		}

		// Checks if the board is full
		public bool IsBoardFull()
		{
			for (int i = 0; i <= 2; i++)
			{
				for (int j = 0; j <= 2; j++)
				{
					if (Board[i, j] != "O" && Board[i, j] != "X")
					{
						return false;
					}
				}
			}

			return true;
		}

		// Checks if a player has won
		public bool CheckWin(int[] index)
		{
			int x = index[0];
			int y = index[1];

			// Check vertical
			if (Board[0,y] == Board[1,y] && Board[1, y] == Board[2, y])
				return true;

			// Check horizontal
			if (Board[x,0] == Board[x,1] && Board[x, 1] == Board[x,2])
				return true;

			// Check diagonal 1
			if (x == y && Board[0,0] == Board[1,1] && Board[1, 1] == Board[2,2])
					return true;

			// Check diagonal 2
			if (x + y == 2 && Board[0,2] == Board[1,1] && Board[1, 1] == Board[2,0])
				return true;

			return false;
		}

		// Places a X or O at index given based on the player turn
		public void PlaceMove(int[] index, int playerTurn)
		{
			Board[index[0], index[1]] = playerTurn == 1 ? "X" : "O";
			DrawBoard();
		}

		// Checks if the spot at the index given has been played on
		public bool IsSameMove(int[] index)
		{
			if (Board[index[0], index[1]] == "X" || Board[index[0], index[1]] == "O")
				return true;

			return false;
		}
	}
}
