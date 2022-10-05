using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Grids{
    public static bool isFalling = true;
    public static List<List<SquareColor>> Grid = new List<List<SquareColor>>(); /// Grid for the current piece to fall on
    public static List<List<SquareColor>> Grid2 = new List<List<SquareColor>>(); /// Grid for the pieces that are already on the board
    public static List<List<SquareColor>> Grid3 = new List<List<SquareColor>>(); /// Grid for the pieces that are already on the board and the current piece
    //Grid 3 is the superposition of Grid and Grid2
    public static void InitGrid3(){ /// Initializes Grid3
        for (int i=0;i<GridDisplay.height;i++){
            for (int j=0;j<GridDisplay.width;j++){
                if (Grid[i][j] != SquareColor.TRANSPARENT){
                    Grid3[i][j] = Grid[i][j];
                }
                else{
                    Grid3[i][j] = Grid2[i][j];
                }
            }
        }
    }
    public static void InitGrid(){ /// Initializes Grid
        Grid = new List<List<SquareColor>>();
        for(int i = 0; i < GridDisplay.height; i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for(int j = 0; j < GridDisplay.width; j++){
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            Grid.Add(Ligne);
        }
    }
    public static void InitGrid2(){ /// Initializes Grid2
        Grid2 = new List<List<SquareColor>>();
        for(int i = 0; i < GridDisplay.height; i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for(int j = 0; j < GridDisplay.width; j++){
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            Grid2.Add(Ligne);
        }
    }
    public static void BuildGrid2(){ // adds a piece to Grid2 when it is done falling
        for(int i = 0; i<GridDisplay.height; i++){
            for(int j=0; j<GridDisplay.width; j++){
                if (Grid[i][j] != SquareColor.TRANSPARENT){
                    Grid2[i][j] = Grid[i][j];
                }
                if (Grid2[i][j] == SquareColor.TRANSPARENT && Grid[i][j] == SquareColor.TRANSPARENT){
                    Grid2[i][j] = SquareColor.TRANSPARENT;
                }
                }
            }
        }
    }
