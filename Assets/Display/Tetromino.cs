using System.Collections;
using System.Collections.Generic;
using Unity = UnityEngine;
using TMPro;
using System;

public class Tetromino {
    public static int X = 0;
    public static int Y=4;
    public static bool canMoveLeft = true;
    public static bool canMoveRight = true;
    public static bool canMoveDown = true;
    public static bool canRotate = true;
    public static int rotated = 0;

    public static int count = 0;
    public static int centerX = 0;
    public static int centerY = 0;


    public static SquareColor color = SquareColor.TRANSPARENT;

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
        Grids.Grid[X][Y] = SquareColor.LIGHT_BLUE;
        Grids.Grid[X+1][Y] = SquareColor.LIGHT_BLUE;
        Grids.Grid[X+2][Y] = SquareColor.LIGHT_BLUE;
        Grids.Grid[X+3][Y] = SquareColor.LIGHT_BLUE;
    }
   public static void CreateJ(){
        Grids.Grid[X][Y] = SquareColor.DEEP_BLUE;
        Grids.Grid[X+1][Y] = SquareColor.DEEP_BLUE;
        Grids.Grid[X+2][Y] = SquareColor.DEEP_BLUE;
        Grids.Grid[X+2][Y-1] = SquareColor.DEEP_BLUE;
    }
   public static void CreateL(){
        Grids.Grid[X][Y] = SquareColor.ORANGE;
        Grids.Grid[X+1][Y] = SquareColor.ORANGE;
        Grids.Grid[X+2][Y] = SquareColor.ORANGE;
        Grids.Grid[X+2][Y+1] = SquareColor.ORANGE;
    }
   public static void CreateO(){
        Grids.Grid[X][Y] = SquareColor.YELLOW;
        Grids.Grid[X][Y+1] = SquareColor.YELLOW;
        Grids.Grid[X+1][Y] = SquareColor.YELLOW;
        Grids.Grid[X+1][Y+1] = SquareColor.YELLOW;
    }
   public static void CreateS(){
        Grids.Grid[X][Y] = SquareColor.GREEN;
        Grids.Grid[X][Y+1] = SquareColor.GREEN;
        Grids.Grid[X+1][Y-1] = SquareColor.GREEN;
        Grids.Grid[X+1][Y] = SquareColor.GREEN;
    }
    public static void CreateT(){
        Grids.Grid[X][Y] = SquareColor.PURPLE;
        Grids.Grid[X+1][Y-1] = SquareColor.PURPLE;
        Grids.Grid[X+1][Y] = SquareColor.PURPLE;
        Grids.Grid[X+1][Y+1] = SquareColor.PURPLE;
    }
  public static void CreateZ(){
        Grids.Grid[X][Y-1] = SquareColor.RED;
        Grids.Grid[X][Y] = SquareColor.RED;
        Grids.Grid[X+1][Y] = SquareColor.RED;
        Grids.Grid[X+1][Y+1] = SquareColor.RED;
    } 
}