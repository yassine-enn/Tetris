using System.Collections;
using System.Collections.Generic;
using Unity = UnityEngine;
using TMPro;
using System;

public class Tetromino {
    public static void CreatePiece(){
        Random rand = new Random();
        int piece = rand.Next(0,7);
        switch(piece){
            case 0:
                CreateI();
                break;
            case 1:
                CreateJ();
                break;
            case 2:
                CreateL();
                break;
            case 3:
                CreateO();
                break;
            case 4:
                CreateS();
                break;
            case 5:
                CreateT();
                break;
            case 6:
                CreateZ();
                break;
        }
    }
    public static void CreateI(){
        Game.Grid[0][5] = SquareColor.LIGHT_BLUE;
        Game.Grid[1][5] = SquareColor.LIGHT_BLUE;
        Game.Grid[2][5] = SquareColor.LIGHT_BLUE;
        Game.Grid[3][5] = SquareColor.LIGHT_BLUE;
    }
    public static void CreateJ(){
        Game.Grid[0][5] = SquareColor.DEEP_BLUE;
        Game.Grid[1][5] = SquareColor.DEEP_BLUE;
        Game.Grid[2][5] = SquareColor.DEEP_BLUE;
        Game.Grid[2][4] = SquareColor.DEEP_BLUE;
    }
    public static void CreateL(){
        Game.Grid[0][5] = SquareColor.ORANGE;
        Game.Grid[1][5] = SquareColor.ORANGE;
        Game.Grid[2][5] = SquareColor.ORANGE;
        Game.Grid[0][4] = SquareColor.ORANGE;
    }
    public static void CreateO(){
        Game.Grid[0][5] = SquareColor.YELLOW;
        Game.Grid[1][5] = SquareColor.YELLOW;
        Game.Grid[0][4] = SquareColor.YELLOW;
        Game.Grid[1][4] = SquareColor.YELLOW;
    }
    public static void CreateS(){
        Game.Grid[0][5] = SquareColor.GREEN;
        Game.Grid[1][5] = SquareColor.GREEN;
        Game.Grid[1][4] = SquareColor.GREEN;
        Game.Grid[2][4] = SquareColor.GREEN;
    }
    public static void CreateT(){
        Game.Grid[0][5] = SquareColor.PURPLE;
        Game.Grid[1][5] = SquareColor.PURPLE;
        Game.Grid[2][5] = SquareColor.PURPLE;
        Game.Grid[1][4] = SquareColor.PURPLE;
    }
    public static void CreateZ(){
        Game.Grid[0][4] = SquareColor.RED;
        Game.Grid[1][4] = SquareColor.RED;
        Game.Grid[1][5] = SquareColor.RED;
        Game.Grid[2][5] = SquareColor.RED;
    }
}