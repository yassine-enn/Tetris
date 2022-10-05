using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class Game{
    public static void DeleteLine(){ //This function deletes a line when it is full, increases score and moves all the lines above it down
        for (int i=0;i<22;i++){
            bool isFull = true;
            for (int j=0;j<10;j++){
                if (Grids.Grid2[i][j] == SquareColor.TRANSPARENT){
                    isFull = false;
                    break;
                } 
                
            }
            if (isFull){
                    GridDisplay.score += 100;
                    for(int l=0;l<10;l++){
                        Grids.Grid2[i][l] = SquareColor.TRANSPARENT;
                    }
                    for (int k=i;k>0;k--){
                        for (int l=0;l<10;l++){
                            Grids.Grid2[k][l] = Grids.Grid2[k-1][l];
                        }
                    }
                }
                GridDisplay.SetScore(GridDisplay.score);
                Grids.InitGrid3();
                GridDisplay.SetColors(Grids.Grid3);
            }
        }
    
    public static void TouchColor(){ //This function prevents tetrominos from colliding with each other
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (Grids.Grid[i][j] != SquareColor.TRANSPARENT ){
                    if ( i==21 || Grids.Grid2[i+1][j] != SquareColor.TRANSPARENT){
                        Tetromino.canMoveDown = false;
                        Tetromino.canMoveLeft = false;
                        Tetromino.canMoveRight = false;
                    }
                }
            }
        }
    }
  
  public static void GameoverCheck(){ //This function checks if the game is over
        for (int i=0;i<10;i++){
            if (Grids.Grid2[0][i] != SquareColor.TRANSPARENT){
                Tetromino.canMoveDown = false;
                Tetromino.canMoveLeft = false;
                Tetromino.canMoveRight = false;
                GridDisplay.TriggerGameOver();
            }
        }
    }
}