using System.Collections;
using System.Collections.Generic;  
using UnityEngine;
using TMPro;

public class MovementFunctions {
    public delegate void TickFunction ();
    public delegate void RotateFunction ();
    public delegate void MoveFunction ();
    public delegate void RushFunction ();
    public static void MoveRight(){ // Moves the current piece to the right by translating the grid to the left
            Game.TouchColor();
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

     public static void MoveLeft(){ //Moves the current piece to the left by translating the grid to the right
        Game.TouchColor();
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
        //for each square in the list, calculate its new coordinates newXBrickCenter = xPivot + x1 = xPivot + yPivot - yBrickCenter where pivot is the top left corner of the grid and brick center is tetrominocenter
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (Grids.Grid[i][j] != SquareColor.TRANSPARENT){
                    int newX = Tetromino.centerX + Tetromino.centerY - j;
                    int newY = Tetromino.centerY - Tetromino.centerX + i;
                    if (newX<0 || newX>21 || newY<0 || newY>9){
                        Debug.Log("Can't rotate1");
                        return;
                    }
                    if (Grids.Grid2[newX][newY] != SquareColor.TRANSPARENT){
                        Debug.Log("Can't rotate2");
                        return;
                    }
                    newCoordinates.Add(new Vector2(newX,newY));
                }
            }
        }
        //clear the grid
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                Grids.Grid[i][j] = SquareColor.TRANSPARENT;
            }
        }
        //put the new coordinates in the grid
        for (int i=0;i<newCoordinates.Count;i++){
            Grids.Grid[(int)newCoordinates[i].x][(int)newCoordinates[i].y] = Tetromino.color;
        }
        Grids.InitGrid3();
        GridDisplay.SetColors(Grids.Grid3);
        Tetromino.count = 0;
      }
       

     public static void Rush(){ //Moves the current piece down by translating the grid up
    Game.TouchColor();
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
}
