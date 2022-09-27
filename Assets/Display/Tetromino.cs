using System.Collections;
using System.Collections.Generic;
using Unity = UnityEngine;
using TMPro;
using System;

public class Tetromino {
    public static int positionX ;
    public static int positionY = 5;
    public static void CreatePiece(){
        Random rand = new Random();
        int piece = rand.Next(0,7);
        piece = 4;
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
        Game.Grid[0][positionY] = SquareColor.LIGHT_BLUE;
        Game.Grid[1][positionY] = SquareColor.LIGHT_BLUE;
        Game.Grid[2][positionY] = SquareColor.LIGHT_BLUE;
        Game.Grid[3][positionY] = SquareColor.LIGHT_BLUE;
    }
    public static void CreateJ(){
        Game.Grid[0][positionY] = SquareColor.DEEP_BLUE;
        Game.Grid[1][positionY] = SquareColor.DEEP_BLUE;
        Game.Grid[2][positionY] = SquareColor.DEEP_BLUE;
        Game.Grid[2][positionY-1] = SquareColor.DEEP_BLUE;
        positionX = positionY;
    }
    public static void CreateL(){
        Game.Grid[0][positionY] = SquareColor.ORANGE;
        Game.Grid[1][positionY] = SquareColor.ORANGE;
        Game.Grid[2][positionY] = SquareColor.ORANGE;
        Game.Grid[0][positionY-1] = SquareColor.ORANGE;
    }
    public static void CreateO(){
        Game.Grid[0][positionY] = SquareColor.YELLOW;
        Game.Grid[1][positionY] = SquareColor.YELLOW;
        Game.Grid[0][positionY-1] = SquareColor.YELLOW;
        Game.Grid[1][positionY-1] = SquareColor.YELLOW;
    }
    public static void CreateS(){
        Game.Grid[0][positionY] = SquareColor.GREEN;
        Game.Grid[1][positionY] = SquareColor.GREEN;
        Game.Grid[1][positionY-1] = SquareColor.GREEN;
        Game.Grid[2][positionY-1] = SquareColor.GREEN;
    }
    public static void CreateT(){
        Game.Grid[0][positionY] = SquareColor.PURPLE;
        Game.Grid[1][positionY] = SquareColor.PURPLE;
        Game.Grid[2][positionY] = SquareColor.PURPLE;
        Game.Grid[1][positionY-1] = SquareColor.PURPLE;
    }
    public static void CreateZ(){
        Game.Grid[0][positionY-1] = SquareColor.RED;
        Game.Grid[1][positionY-1] = SquareColor.RED;
        Game.Grid[1][positionY] = SquareColor.RED;
        Game.Grid[2][positionY] = SquareColor.RED;
        }
}