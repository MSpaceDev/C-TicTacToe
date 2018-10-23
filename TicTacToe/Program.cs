using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TicTacToe
{
	class Program
	{
		static BoardManager board;
		static int playerTurn;

		static void Main(string[] args)
		{
			playerTurn = 1;

			// Create new board
			board = new BoardManager();

			// Loop continuously until player has won
			while (true)
			{
				board.DrawBoard();

				// Loop until player has entered a legal value
				string input = GetInput();
				int[] index = new int[2];
				while (!PlacedMove(input, out index)) {
					input = GetInput();
					continue;
				}

				if (board.CheckWin(index))
				{
					Console.WriteLine("\nPlayer {0} has won the game!\nPress any key to reset.", playerTurn);
					Reset();
					continue;
				} else if (board.IsBoardFull())
				{
					Console.WriteLine("\nBoard is full.\nPress any key to reset.");
					Reset();
					continue;
				}

				// Switch between player 1 and 2
				playerTurn = playerTurn == 1 ? 2 : 1;
			}
		}

		private static string GetInput()
		{
			Console.Write("Player {0}: Choose your field! ", playerTurn);
			return Console.ReadLine();
		}

		private static void Reset()
		{
			Console.ReadKey();
			playerTurn = 1;
			board.Reset();
		}

		private static bool PlacedMove(string input, out int[] index)
		{
			int value;
			bool parse = int.TryParse(input, out value);

			value = parse ? value : 0;
			index = GetIndex(value);

			// Error checking for input
			if (value == 0)
				Console.WriteLine("Enter numbers only!\n");
			else if (value > 9 || value < 0)
				Console.WriteLine("Only enter a value between 1 and 9!\n");
			else if (board.IsSameMove(index))
				Console.WriteLine("Only enter a square that has not been played in!\n");
			else
			{
				// If there is no error with the input, place the move
				board.PlaceMove(index, playerTurn);
				return true;
			}

			return false;
		}

		// Converts the input 1-9 to an array of indices for the 2D array
		private static int[] GetIndex(int value)
		{
			int[] indices = new int[2];
			int counter = 0;

			for (int i = 0; i <= 2; i++)
			{
				for (int j = 0; j <= 2; j++)
				{
					counter++;
					if (counter == value)
					{
						indices = new int[2] { i, j };
						break;
					}
				}
			}
			
			return indices;
		}
	}
}
