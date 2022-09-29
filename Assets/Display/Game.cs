using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Game{
    public static bool isFalling = true;
    public static List<List<SquareColor>> Grid = new List<List<SquareColor>>(); // 1 piece qui tombe
    public static List<List<SquareColor>> Grid2 = new List<List<SquareColor>>(); // toutes les pieces qui se sont deja posées
    public static List<List<SquareColor>> Grid3 = new List<List<SquareColor>>(); // toutes les pieces Grid + Grid2

    //Grid 3 is the sum of Grid and Grid2
    public static void InitGrid3(){
        for(int i = 0; i < 22; i++){
        for(int j = 0; j < 10; j++){
            if (Grid2[i][j] != SquareColor.TRANSPARENT){
                Grid3[i][j] = Grid2[i][j];
            }
            if (Grid[i][j] != SquareColor.TRANSPARENT){
                Grid3[i][j] = Grid[i][j];
            }else{
                Grid3[i][j] = SquareColor.TRANSPARENT;
            }   
        }
    }
    }
    public static void InitGrid(){
        Grid = new List<List<SquareColor>>();
        for(int i = 0; i < 22; i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for(int j = 0; j < 10; j++){
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            Grid.Add(Ligne);
        }
    }

    public static void BuildGrid2(){
        for(int i = 0; i < 22; i++){
            for(int j=0; j<10; j++){
                if (Grid[i][j] != SquareColor.TRANSPARENT){
                    Grid2[i][j] = Grid[i][j];
                }else{
                    Grid2[i][j] = SquareColor.TRANSPARENT;
                }
            }
        }
    }
    }
    // public static void Init(){
    //     for (int i=0;i<22;i++){
    //         List<SquareColor> Ligne = new List<SquareColor>();
    //         for (int j = 0;j<10;j++){
    //             Ligne.Add(SquareColor.TRANSPARENT);
    //         }
    //         Grid.Add(Ligne);
    //         Grid2.Add(new List<SquareColor>(Ligne));
    //         Grid3.Add(new List<SquareColor>(Ligne));
    //     }
        
    // }

