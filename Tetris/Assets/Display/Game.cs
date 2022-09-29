using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Game{
    public static List<List<SquareColor>> Grid = new List<List<SquareColor>>(); // 1 piece qui tombe
    public static List<List<SquareColor>> Grid2 = new List<List<SquareColor>>(); // toutes les pieces qui se sont deja posées
    public static List<List<SquareColor>> Grid3 = new List<List<SquareColor>>(); // toutes les pieces Grid + Grid2

    public static void Init(){
        for (int i=0;i<22;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<10;j++){
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            Grid.Add(Ligne);
            Grid2.Add(new List<SquareColor>(Ligne));
            Grid3.Add(new List<SquareColor>(Ligne));
        }

    }
}
