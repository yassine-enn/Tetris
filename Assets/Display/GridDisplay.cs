using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// Afficher une pièce aléatoire parmis les pièces du Tetris en haut au centre de la grille au début du jeu (la grille fait 10x22 cases), en précisant les couleurs de chaque case de la grille, puis à chaque fois qu'une pièce touche le sol.
// Paramétrer une fonction de Tick de manière à ce qu'elle soit appelée automatiquement à chaque tick, ce qui permettra de déplacer les pièces dans le temps vers le bas
// Paramétrer des fonctions MoveRight et MoveLeft pour permettre de déplacer la pièce latéralement
// Gérer les collisions avec:
// Les bords
// Les pièces déjà posées en bas
// Gérer les rotations de la pièce en paramétrant la fonction Rotate
// Faire descendre la pièce tout en bas en paramétrant la fonction Rush
// Mettre à jour le score si une ligne est complétée, et la retirer de la grille (ce qui fait descendre le reste des éléments)
// Déclencher l'évènement "Game Over" si une pièce touche le haut de la grille en se posant au sol.
public class GridDisplay : MonoBehaviour
{
    // Hauteur de la grille en nombre de cases
    public int height = 22;
    // Largeur de la grille en nombre de cases
    public int width = 10;
    
    
    // Cette fonction se lance au lancement du jeu, avant le premier affichage.
    public static void Initialize(){
        //Complétez cette fonction de manière à appeler le code qui initialise votre jeu.
        // TODO : Appelez SetTickFunction en lui passant en argument une fonction ne prenant pas d'argument et renvoyant Void.
        //        Cette fonction sera exécutée à chaque tick du jeu, c'est à dire, initialement, toutes les secondes.
        //        Vous pouvez utiliser toutes les méthodes statiques ci-dessous pour mettre à jour l'état du jeu.
        // TODO : Appelez SetMoveLeftFunction, SetMoveRightFunction, SetRotateFunction, SetRushFunction pour enregistrer 
        //        quelle fonction sera appelée lorsqu'on appuie sur les flèches directionnelles gauche, droite, la barre d'espace
        //        et la flèche du bas du clavier.
        //
        // /!\ Ceci est la seule fonction du fichier que vous avez besoin de compléter, le reste se trouvant dans vos propres classes!
        // changer la couleur de la case en haut au centre de la grille
        for (int i=0;i<22;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<10;j++){
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            Game.Grid.Add(Ligne);
        }
        SetColors(Game.Grid);
        Tetromino.CreatePiece();
        SetMoveRightFunction(MoveRight);
        SetMoveLeftFunction(MoveLeft);
        SetRushFunction(Rush);
        SetRotateFunction(Rotate);
        SetTickFunction(Test);
    }
    public static void Test(){
        for (int j=0;j<10;j++){
            if (Game.Grid[21][j] != SquareColor.TRANSPARENT){
                Tetromino.canMoveDown = false;
                Tetromino.canMoveLeft = false;
                Tetromino.canMoveRight = false;
            }
        }
        if (Tetromino.canMoveDown){
        for (int i=21;i>0;i--){
            Game.Grid[i] = Game.Grid[i-1];
        }
        List<SquareColor> Ligne = new List<SquareColor>();
        for (int j = 0;j<10;j++){
            Ligne.Add(SquareColor.TRANSPARENT);
        }
        Game.Grid[0] = Ligne;
        SetColors(Game.Grid);
    }
    public static void deleteligne(){
        for (int i=0;i<22;i--){
            bool ligne = true;
            for (int j=0;j<10;j++){
                if (Game.Grid[i][j] == SquareColor.TRANSPARENT){
                    ligne = false;
                }
            }
            if (ligne){
                for (int k=i;k>0;k--){
                    Game.Grid[k] = Game.Grid[k-1];
                }
                List<SquareColor> Ligne = new List<SquareColor>();
                for (int j = 0;j<10;j++){
                    Ligne.Add(SquareColor.TRANSPARENT);
                }
                Game.Grid[0] = Ligne;
                SetColors(Game.Grid);
            }
        }
    }
    public static void update score(){
        int score = 0;
        for (int i=0;i<22;i++){
            bool ligne = true;
            for (int j=0;j<10;j++){
                if (Game.Grid[i][j] == SquareColor.TRANSPARENT){
                    ligne = false;
                }
            }
            if (ligne){
                score += 100;
            }
        }
        SetScore(score);
    }
    // Paramètre la fonction devant être appelée à chaque tick. 
    // C'est ici que le gros de la logique temporelle de votre jeu aura lieu! 
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetTickFunction(TickFunction function){
        _grid.Tick = function;
    }
    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace 
    // pour faire tourner la pièce dans le sens horaire.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRotateFunction(RotateFunction function){ 
        _grid.Rotate = function;
    }
    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de gauche 
    // pour bouger la pièce vers la gauche.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveLeftFunction(MoveFunction function){  
        _grid.MoveLeft = function;
    }
    public static void MoveRight(){
        //    bool canMoveRight = true;
           for (int i=0;i<22;i++){
            if (Game.Grid[i][9] != SquareColor.TRANSPARENT){
                Tetromino.canMoveRight = false;
                Tetromino.canMoveLeft = true;
            }
           }
           if (Tetromino.canMoveRight){
           for (int i=0;i<22;i++){
            for (int j=9;j>0;j--){
                Game.Grid[i][j] = Game.Grid[i][j-1];
            }
            Game.Grid[i][0] = SquareColor.TRANSPARENT;
        }
        SetColors(Game.Grid);
    }
    }
    public static void MoveLeft(){
        for (int i=0;i<22;i++){
            if (Game.Grid[i][0]!= SquareColor.TRANSPARENT){
                Tetromino.canMoveLeft = false;
                Tetromino.canMoveRight = true;
            }
        }
        if (Tetromino.canMoveLeft){
        for (int i=0;i<22;i++){
            for (int j=0;j<9;j++){
                Game.Grid[i][j] = Game.Grid[i][j+1];
            }
            Game.Grid[i][9] = SquareColor.TRANSPARENT;
        }
        SetColors(Game.Grid);
    }
    }
    public static void Rush(){
       for (int j=0;j<10;j++){
           if (Game.Grid[21][j] != SquareColor.TRANSPARENT){
               Tetromino.canMoveDown = false;
               Tetromino.canMoveLeft = false;
               Tetromino.canMoveRight = false;
           }
       }
        if (Tetromino.canMoveDown){
          for (int i=21;i>0;i--){
            Game.Grid[i] = Game.Grid[i-1];
        }
        List<SquareColor> Ligne = new List<SquareColor>();
        for (int j = 0;j<10;j++){
            Ligne.Add(SquareColor.TRANSPARENT);
        }
        Game.Grid[0] = Ligne;
        SetColors(Game.Grid);
    }
    }
    public static void Rotate(){
        //rotation point is the center of the piece
        //rotation is clockwise
        //rotation is done by switching the values of the squares
        //find the rotation point
        int rotationPointX = 0;
        int rotationPointY = 0;
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (Game.Grid[i][j] != SquareColor.TRANSPARENT){
                    rotationPointX = j;
                    rotationPointY = i;
                }
            }
        }
        //find the squares to switch
        List<int> x = new List<int>();
        List<int> y = new List<int>();
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                if (Game.Grid[i][j] != SquareColor.TRANSPARENT){
                    x.Add(j);
                    y.Add(i);
                }
            }
        }
        //switch the squares
        for (int i=0;i<x.Count;i++){
            int temp = x[i];
            x[i] = y[i];
            y[i] = temp;
        }
        for (int i=0;i<x.Count;i++){
            x[i] = x[i] - rotationPointX;
            y[i] = y[i] - rotationPointY;
        }
        for (int i=0;i<x.Count;i++){
            int temp = x[i];
            x[i] = -y[i];
            y[i] = temp;
        }
        for (int i=0;i<x.Count;i++){
            x[i] = x[i] + rotationPointX;
            y[i] = y[i] + rotationPointY;
        }
        //check if the squares are in the grid
        for (int i=0;i<x.Count;i++){
            if (x[i] < 0 || x[i] > 9 || y[i] < 0 || y[i] > 21){
                Tetromino.canRotate = false;
            }
        }
        //check if the squares are empty
        for (int i=0;i<x.Count;i++){
            if (Game.Grid[y[i]][x[i]] != SquareColor.TRANSPARENT){
                Tetromino.canRotate = false;
            }
        }
        if (Tetromino.canRotate){
        for (int i=0;i<22;i++){
            for (int j=0;j<10;j++){
                Game.Grid[i][j] = SquareColor.TRANSPARENT;
            }
        }
        for (int i=0;i<x.Count;i++){
            Game.Grid[y[i]][x[i]] = SquareColor.RED;
        }
        SetColors(Game.Grid);
 }
    }
    
    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de droite 
    // pour bouger la pièce vers la droite.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveRightFunction(MoveFunction function){
        _grid.MoveRight = function;
    }
    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace
    // pour faire descendre la pièce tout en bas.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRushFunction(RushFunction function){
        _grid.Rush = function;
    }
    // Modifie l'intervale de rendu du jeu. A modifier pour modifier la difficulté en cours de partie.
    public static void SetTickTime(float seconds){
        _grid.tick = seconds;
    }
    // Modifie toutes les couleurs de chaque case de la grille.
    // Cette fonction doit prendre en argument un tableau de LIGNES, de haut vers le bas, contenant 
    // des couleurs de case allant de gauche vers la droite.
    // Vous appellerez a priori cette fonction une fois par TickFunction, une fois le nouvel état de la grille
    // calculé.
    public static void SetColors(List<List<SquareColor>> colors){
        _grid.SetColors(colors);
    }
    // Modifie visuellement le score de l'utilisateur en bas à droite.
    public static void SetScore(int score){
        _grid.SetScore(score);
    }
    // Déclenche visuellement le GameOver et arrête le jeu.
    public static void TriggerGameOver(){
        _grid.TriggerGameOver();
    }
  
/// Les lignes au delà de celle-ci ne vous concernent pas.
    private static _GridDisplay _grid = null;
    void Awake() 
    {
        _grid = GameObject.FindObjectOfType<_GridDisplay>();
        _grid.height = height;
        _grid.width = width;
    }
    void Start(){ 
        Initialize();
    }
}


