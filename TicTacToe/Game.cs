﻿using System;
using System.Linq;

public class Game {
	char[] _board = {
    	'1', '2', '3',
    	'4', '5', '6',
    	'7', '8', '9'
    };
	char[] _playerSymbols = { 'X', 'O' };
    int _currentPlayer;

    public void Run() {
        int flag = 0;

        while (true) {
			Console.Clear();
            Console.WriteLine("Player1: {0} and Player2: {1}", _playerSymbols[0], _playerSymbols[1]);
			Console.WriteLine();
            Console.WriteLine("Player {0}'s turn", _currentPlayer + 1);
			Console.WriteLine();

			DrawBoard(_board);
            
			var choice = int.Parse(Console.ReadLine());
			while (choice > 9 || choice < 0) {
				Console.WriteLine("That is an invalid number, please try again: ");
				choice = int.Parse(Console.ReadLine()) - 1;
			}
			if (!_playerSymbols.Contains(_board[choice])) {
				_board[choice] = _playerSymbols[_currentPlayer];
			} else {
				Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, _board[choice]);
				Console.WriteLine();
			}
			flag = CheckGameOver(_board);
            if (flag != 0)
                break;
            
            _currentPlayer = _currentPlayer == 0 ? 1 : 0;
        }

		Console.Clear();
		DrawBoard(_board);
		if (flag == 1) {
			Console.WriteLine("Player {0} has won", _currentPlayer + 1);
		} else {
			Console.WriteLine("Draw");
		}
		Console.ReadLine();
	}

	void DrawBoard(char[] board) {
		Console.WriteLine("   |   |  ");
		Console.WriteLine(" {0} | {1} | {2}", board[0], board[1], board[2]);
		Console.WriteLine("___|___|___");
		Console.WriteLine("   |   |  ");
		Console.WriteLine(" {0} | {1} | {2}", board[3], board[4], board[5]);
		Console.WriteLine("___|___|___");
		Console.WriteLine("   |   |  ");
		Console.WriteLine(" {0} | {1} | {2}", board[6], board[7], board[8]);
		Console.WriteLine("   |   |  ");
	}

	private int CheckGameOver(char[] board) {
		// Check rows
		if (AllEqual(board[0], board[1], board[2]) || 
			AllEqual(board[3], board[4], board[5]) || 
			AllEqual(board[6], board[7], board[8])) 
			return 1;

		// Check columns
		if (AllEqual(board[0], board[3], board[6]) ||
			AllEqual(board[1], board[4], board[7]) ||
			AllEqual(board[2], board[5], board[8]))
			return 1;

		// Check Diagonals
		if (AllEqual(board[0], board[4], board[8]) ||
			AllEqual(board[2], board[3], board[6]))
			return 1;

		// Check For Draw
		return board.Any(c => !_playerSymbols.Contains(c)) ? 0 : -1;
	}

	private bool AllEqual(int a, int b, int c) {
		return a == b && b == c;
	}
}

