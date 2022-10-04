using System.Collections;
using System.Collections.Generic;  
using UnityEngine;
using TMPro;

public class MovementFunctions {
    public delegate void TickFunction ();
    public delegate void RotateFunction ();
    public delegate void MoveFunction ();
    public delegate void RushFunction ();
    public static void MoveRight(){
            for (int i=0;i<22;i++){
            for (int j=0;j<9;j++){
                if (j<8 && Grids.Grid[i][j] != SquareColor.TRANSPARENT && Grids.Grid2[i][j+1] != SquareColor.TRANSPARENT){
                    Tetromino.canMoveLeft = true;
                    Tetromino.canMoveRight = false;
                }else{
                    Tetromino.canMoveLeft = true;
                }
                }
            }
           for (int i=0;i<22;i++){
            if (Grids.Grid[i][9] != SquareColor.TRANSPARENT){
                Tetromino.canMoveRight = false;
                Tetromino.canMoveLeft = true;
            }
           }
           if (Tetromino.canMoveRight){
           for (int i=0;i<22;i++){
            for (int j=9;j>0;j--){
                Grids.Grid[i][j] = Grids.Grid[i][j-1];
            }
            Grids.Grid[i][0] = SquareColor.TRANSPARENT;
        }
        Grids.InitGrid3();   
        GridDisplay.SetColors(Grids.Grid3);
    }
    }

     public static void MoveLeft(){
        for (int i=0;i<22;i++){
            for (int j=0;j<9;j++){
                if (j>=1 && Grids.Grid[i][j] != SquareColor.TRANSPARENT && Grids.Grid2[i][j-1] != SquareColor.TRANSPARENT){
                    Tetromino.canMoveLeft = false;
                    Tetromino.canMoveRight = true;
                }else{
                    Tetromino.canMoveRight = true;
                }
                }
            }
        for (int i=0;i<22;i++){
            if (Grids.Grid[i][0]!= SquareColor.TRANSPARENT){
                Tetromino.canMoveLeft = false;
                Tetromino.canMoveRight = true;
            }
        }
        if (Tetromino.canMoveLeft){
        for (int i=0;i<22;i++){
            for (int j=0;j<9;j++){
                Grids.Grid[i][j] = Grids.Grid[i][j+1];
            }
            Grids.Grid[i][9] = SquareColor.TRANSPARENT;
        }
        Grids.InitGrid3();
        GridDisplay.SetColors(Grids.Grid3);
    }
}

      public static void RotateTetromino(){
        //create a new list of coordinates
        List<Vector2> newCoordinates = new List<Vector2>();
        //if a square is colored in the grid put its coordinates in the new list
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (Grids.Grid[i][j] != SquareColor.TRANSPARENT){
                    Tetromino.count += 1;
                    Tetromino.color = Grids.Grid[i][j];
                    if (Tetromino.count == 2 && Tetromino.color==SquareColor.LIGHT_BLUE){
                        Tetromino.centerX = i;
                        Tetromino.centerY = j;
                    }
                    if (Tetromino.count == 4 && Tetromino.color == SquareColor.GREEN){
                        Tetromino.centerX = i;
                        Tetromino.centerY = j;
                    }
                    if (Tetromino.color == SquareColor.YELLOW){
                        return;
                    }
                    if (Tetromino.count ==3){
                        Tetromino.centerX = i;
                        Tetromino.centerY = j;
                    }
                }
            }
        }
        //for each square in the list, calculate its new coordinates
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (Grids.Grid[i][j] != SquareColor.TRANSPARENT){
                    Vector2 newCoordinate = new Vector2();
                    newCoordinate.x = Tetromino.centerX - (j - Tetromino.centerY);
                    newCoordinate.y = Tetromino.centerY + (i - Tetromino.centerX);
                    newCoordinates.Add(newCoordinate);
                }
            }
        }
        //check if the new coordinates are in the grid
        for (int i=0;i<newCoordinates.Count;i++){
            if (newCoordinates[i].x < 0 || newCoordinates[i].x > 21 || newCoordinates[i].y < 0 || newCoordinates[i].y > 9){
                return;
            }
        }
        //check if the new coordinates are not already occupied
        for (int i=0;i<newCoordinates.Count;i++){
            if (Grids.Grid2[(int)newCoordinates[i].x][(int)newCoordinates[i].y] != SquareColor.TRANSPARENT){
                return;
            }
        }
        //if the new coordinates are valid, change the grid
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (Grids.Grid[i][j] != SquareColor.TRANSPARENT){
                    Grids.Grid[i][j] = SquareColor.TRANSPARENT;
                }
            }
        }
        for (int i=0;i<newCoordinates.Count;i++){
            Grids.Grid[(int)newCoordinates[i].x][(int)newCoordinates[i].y] = Tetromino.color;
        }
        Tetromino.count = 0;
    }

     public static void Rush(){
    for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (i<21 && Grids.Grid[i][j] != SquareColor.TRANSPARENT && Grids.Grid2[i+1][j] != SquareColor.TRANSPARENT){
                    Tetromino.canMoveDown = false;
                    }
            }
        }
       for (int j=0;j<10;j++){
           if (Grids.Grid[21][j] != SquareColor.TRANSPARENT){
               Game.DeleteLine();
               Tetromino.canMoveDown = false;
               Tetromino.canMoveLeft = false;
               Tetromino.canMoveRight = false;
           }
           }

        if (Tetromino.canMoveDown){
          for (int i=21;i>0;i--){
            Grids.Grid[i] = Grids.Grid[i-1];
        }
        List<SquareColor> Ligne = new List<SquareColor>();
        for (int j = 0;j<10;j++){
            Ligne.Add(SquareColor.TRANSPARENT);
        }
        Grids.Grid[0] = Ligne;
        Grids.InitGrid3();
        GridDisplay.SetColors(Grids.Grid3);
    }
}
// public static void Rush(){
//     GridDisplay.SetTickTime(0.1f);
// }

}
