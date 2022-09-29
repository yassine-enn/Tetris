using System.Collections;
using System.Collections.Generic;
using Unity = UnityEngine;
using TMPro;
using System;

public class Tetromino {
    // public static int X;
    // public static int Y;
    public static bool canMoveLeft = true;
    public static bool canMoveRight = true;
    public static bool canMoveDown = true;
    public static bool canRotate = true;
    public static int rotated = 0;  

    public static void CreatePiece(){
        Random rand = new Random();
        int piece = rand.Next(0,7);
        piece = 5;
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
        Game.Grid[0][4] = SquareColor.LIGHT_BLUE;
        Game.Grid[1][4] = SquareColor.LIGHT_BLUE;
        Game.Grid[2][4] = SquareColor.LIGHT_BLUE;
        Game.Grid[3][4] = SquareColor.LIGHT_BLUE;
    }
   public static void CreateJ(){
        Game.Grid[0][4] = SquareColor.DEEP_BLUE;
        Game.Grid[1][4] = SquareColor.DEEP_BLUE;
        Game.Grid[2][4] = SquareColor.DEEP_BLUE;
        Game.Grid[2][3] = SquareColor.DEEP_BLUE;
    }
   public static void CreateL(){
        Game.Grid[0][4] = SquareColor.ORANGE;
        Game.Grid[1][4] = SquareColor.ORANGE;
        Game.Grid[2][4] = SquareColor.ORANGE;
        Game.Grid[2][5] = SquareColor.ORANGE;
    }
   public static void CreateO(){
        Game.Grid[0][4] = SquareColor.YELLOW;
        Game.Grid[0][5] = SquareColor.YELLOW;
        Game.Grid[1][4] = SquareColor.YELLOW;
        Game.Grid[1][5] = SquareColor.YELLOW;
    }
   public static void CreateS(){
        Game.Grid[0][4] = SquareColor.GREEN;
        Game.Grid[0][5] = SquareColor.GREEN;
        Game.Grid[1][3] = SquareColor.GREEN;
        Game.Grid[1][4] = SquareColor.GREEN;
    }
    public static void CreateT(){
        // Game.Grid[0][4] = SquareColor.PURPLE;
        // Game.Grid[1][3] = SquareColor.PURPLE;
        // Game.Grid[1][4] = SquareColor.PURPLE;
        // Game.Grid[1][5] = SquareColor.PURPLE;
        if (rotated%4==0){
            Game.Grid[0][4] = SquareColor.PURPLE;
            Game.Grid[1][3] = SquareColor.PURPLE;
            Game.Grid[1][4] = SquareColor.PURPLE;
            Game.Grid[1][5] = SquareColor.PURPLE;
        }
        else if (rotated%4==1){
            Game.Grid[0][4] = SquareColor.PURPLE;
            Game.Grid[1][4] = SquareColor.PURPLE;
            Game.Grid[2][4] = SquareColor.PURPLE;
            Game.Grid[1][5] = SquareColor.PURPLE;
        }
        else if (rotated%4==2){
            Game.Grid[0][4] = SquareColor.PURPLE;
            Game.Grid[1][3] = SquareColor.PURPLE;
            Game.Grid[1][4] = SquareColor.PURPLE;
            Game.Grid[1][5] = SquareColor.PURPLE;
        }
        else if (rotated%4==3){
            Game.Grid[0][4] = SquareColor.PURPLE;
            Game.Grid[1][4] = SquareColor.PURPLE;
            Game.Grid[2][4] = SquareColor.PURPLE;
            Game.Grid[1][5] = SquareColor.PURPLE;
        }
    }
  public static void CreateZ(){
        // Game.Grid[0][3] = SquareColor.RED;
        // Game.Grid[0][4] = SquareColor.RED;
        // Game.Grid[1][4] = SquareColor.RED;
        // Game.Grid[1][5] = SquareColor.RED;
        if (rotated%4 == 0){
            Game.Grid[0][3] = SquareColor.RED;
            Game.Grid[0][4] = SquareColor.RED;
            Game.Grid[1][4] = SquareColor.RED;
            Game.Grid[1][5] = SquareColor.RED;
        }
        else if (rotated%4 == 1){
            Game.Grid[0][4] = SquareColor.RED;
            Game.Grid[1][4] = SquareColor.RED;
            Game.Grid[1][5] = SquareColor.RED;
            Game.Grid[2][5] = SquareColor.RED;
        }
        else if (rotated%4 == 2){
            Game.Grid[1][3] = SquareColor.RED;
            Game.Grid[1][4] = SquareColor.RED;
            Game.Grid[2][4] = SquareColor.RED;
            Game.Grid[2][5] = SquareColor.RED;
        }
        else if (rotated%4 == 3){
            Game.Grid[0][3] = SquareColor.RED;
            Game.Grid[1][3] = SquareColor.RED;
            Game.Grid[1][4] = SquareColor.RED;
            Game.Grid[2][4] = SquareColor.RED;
        }
    } 
    
}