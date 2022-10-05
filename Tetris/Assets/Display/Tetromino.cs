using System.Collections;
using System.Collections.Generic;
using Unity = UnityEngine;
using TMPro;
using System;

public class Tetromino {
    public static int X = 0;
    public static int Y=4;
    public static bool canMoveLeft = true; //These variables are used to prevent tetrominos from colliding with each other and the walls
    public static bool canMoveRight = true; 
    public static bool canMoveDown = true; 
    public static bool canRotate = true; 
    public static int count = 0; // This variable is used to find the center of the tetromino (used for rotation) e.g the center of the I tetromino is the 2nd square from the left
    public static int centerX = 0; //This variable contains the x coordinate of the center of the tetromino
    public static int centerY = 0; //This variable contains the y coordinate of the center of the tetromino


    public static SquareColor color = SquareColor.TRANSPARENT;

    public static void CreatePiece(){ //Creates a new piece at the top of the screen randomly
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
    public static void CreateI(){ //Creates an I piece
        Grids.Grid[X][Y] = SquareColor.LIGHT_BLUE;
        Grids.Grid[X+1][Y] = SquareColor.LIGHT_BLUE;
        Grids.Grid[X+2][Y] = SquareColor.LIGHT_BLUE;
        Grids.Grid[X+3][Y] = SquareColor.LIGHT_BLUE;
    }
   public static void CreateJ(){ //Creates a J piece
        Grids.Grid[X][Y] = SquareColor.DEEP_BLUE;
        Grids.Grid[X+1][Y] = SquareColor.DEEP_BLUE;
        Grids.Grid[X+2][Y] = SquareColor.DEEP_BLUE;
        Grids.Grid[X+2][Y-1] = SquareColor.DEEP_BLUE;
    }
   public static void CreateL(){ //Creates an L piece
        Grids.Grid[X][Y] = SquareColor.ORANGE;
        Grids.Grid[X+1][Y] = SquareColor.ORANGE;
        Grids.Grid[X+2][Y] = SquareColor.ORANGE;
        Grids.Grid[X+2][Y+1] = SquareColor.ORANGE;
    }
   public static void CreateO(){ //Creates an O piece
        Grids.Grid[X][Y] = SquareColor.YELLOW;
        Grids.Grid[X][Y+1] = SquareColor.YELLOW;
        Grids.Grid[X+1][Y] = SquareColor.YELLOW;
        Grids.Grid[X+1][Y+1] = SquareColor.YELLOW;
    }
   public static void CreateS(){ //Creates an S piece
        Grids.Grid[X][Y] = SquareColor.GREEN;
        Grids.Grid[X][Y+1] = SquareColor.GREEN;
        Grids.Grid[X+1][Y-1] = SquareColor.GREEN;
        Grids.Grid[X+1][Y] = SquareColor.GREEN;
    }
    public static void CreateT(){ //Creates a T piece
        Grids.Grid[X][Y] = SquareColor.PURPLE;
        Grids.Grid[X+1][Y-1] = SquareColor.PURPLE;
        Grids.Grid[X+1][Y] = SquareColor.PURPLE;
        Grids.Grid[X+1][Y+1] = SquareColor.PURPLE;
    }
  public static void CreateZ(){ //Creates a Z piece
        Grids.Grid[X][Y-1] = SquareColor.RED;
        Grids.Grid[X][Y] = SquareColor.RED;
        Grids.Grid[X+1][Y] = SquareColor.RED;
        Grids.Grid[X+1][Y+1] = SquareColor.RED;
    } 
}