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

    public static int score = 0;
    
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
        Grids.InitGrid2();
        for (int i=0;i<22;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<10;j++){
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            Grids.Grid.Add(Ligne);
            Grids.Grid3.Add(new List<SquareColor>(Ligne));
        }
        Tetromino.CreatePiece();
        SetMoveRightFunction(MovementFunctions.MoveRight);
        SetMoveLeftFunction(MovementFunctions.MoveLeft);
        SetRushFunction(MovementFunctions.Rush);
        SetRotateFunction(MovementFunctions.RotateTetromino);
        Grids.InitGrid3();
        SetColors(Grids.Grid3);
        SetTickFunction(Tick);
        }
    public static void Tick(){
        Game.TouchColor();
        SetScore(score);
        for (int j=0;j<10;j++){
           for (int i=21;i>0;i--){
            if (Grids.Grid[21][j] != SquareColor.TRANSPARENT){
                Tetromino.canMoveDown = false;
                Tetromino.canMoveLeft = false;
                Tetromino.canMoveRight = false;
            }
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
        }
     if (!Tetromino.canMoveDown && !Tetromino.canMoveLeft && !Tetromino.canMoveRight){
            // Debug.Log("can move down" + Tetromino.canMoveDown);
            Grids.BuildGrid2();
            Grids.InitGrid3();
            Grids.InitGrid();
            SetColors(Grids.Grid3);
            Tetromino.canMoveDown = true;
            Tetromino.canMoveRight = true;  
            Tetromino.canMoveLeft = true;
            // Debug.Log("can move down :"+Tetromino.canMoveDown);
            Tetromino.CreatePiece();
            Grids.InitGrid3();   
     }
        Game.GameoverCheck();
        Game.DeleteLine();
        Grids.InitGrid3();
        SetColors(Grids.Grid3);
        // Debug.Log("canMoveDown"+Tetromino.canMoveDown);
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


