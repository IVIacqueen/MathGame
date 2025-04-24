﻿/*
 * Math Game Task for C# Academy
 * Need to use the 4 basic operations + (Addition), - (Substraction), * (Multiplication), / (Division)
 * Only use integers
 * Division can only result in integers and go from 0 to 100
 * Users should be presented with a menu to choose an operation
 * You should record previous games in a list 
 *      Should be an option in the menu for the user to visualize a history of previous games
 *      Once the program is closed the history is deleted (No database)
 */

using MathGame;

UserInterface userInterface = new UserInterface();
userInterface.MainMenu();

