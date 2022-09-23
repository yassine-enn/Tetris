using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public delegate void TickFunction ();
public delegate void RotateFunction ();

public delegate void MoveFunction ();

public delegate void RushFunction ();

public class _GridDisplay : MonoBehaviour
{
    List<_Square> squares = new List<_Square>();
    public int width = 10;
    public int height = 22;

    public float squareSize = 0.3f;
    public float tick = 1.0f;

    public TickFunction Tick = null;
    public RotateFunction Rotate = null;
    public MoveFunction MoveLeft  = null;
    public MoveFunction MoveRight  = null;

    public RushFunction Rush = null;


    public GameObject gameOver = null;
    public TextMeshProUGUI score = null;

    private Coroutine tickCoroutine = null;

    private const float cornerTop = 4.15f;
    private const float cornerLeft = -2.23f;

    public GameObject squarePrefab = null;
    // Start is called before the first frame update
    void Start() 
    {
        Create();
    }

    // Update is called once per frame
    void Update() 
    {
        this.tickCoroutine = StartCoroutine(LaunchTicks());
    }

    void Create(){   //create the grid
        GameObject parent = new GameObject();
        parent.name = "Grid";
        for(int y = 0; y < this.height; y++){
            for(int x = 0; x < this.width; x++){
                GameObject go = GameObject.Instantiate(squarePrefab);
                go.transform.position = new Vector3(cornerLeft + x*squareSize,cornerTop -y*squareSize,0 );
                go.transform.localScale = new Vector3(squareSize,squareSize,1);
                go.name= $"Cell-{x}-{y}";
                go.transform.SetParent(parent.transform);
                squares.Add(go.GetComponent<_Square>());
            }
        }
    }

    public void SetScore(int score){ //TODO: make it work with the score
        if(this.score){
            this.score.SetText($"{score}");
        }
    }

    public void TriggerGameOver(){ //TODO: make it work with the game over
        this.gameOver.SetActive(true);
        this.StopCoroutine(this.tickCoroutine);
    }

    public void SetColors(List<List<SquareColor>> colors){ //colors[y][x] = color of the square at x,y position in the grid 
        if(colors.Count != this.height){
            throw new System.FormatException("Provided grid does not have the right number of lines.");
        }
        for(int y = 0; y < colors.Count; y++){
            if(colors[y].Count != this.width){
                throw new System.FormatException($"Line {y} of provided grid does not have the right number of columns.");
            }
            for(int x = 0; x < colors[y].Count; x++){
                squares[y*this.width + x].color = colors[y][x];
            }
        }
    }

    void OnRotate(){ //called when the user presses the rotate button
        if(this.Rotate != null){
            this.Rotate();
        }
    }

    void OnMoveLeft(){ //called when the user presses the move left button
        if(this.MoveLeft != null){
            this.MoveLeft();
        }
    }

    void OnMoveRight(){ //called when the user presses the move right button
        if(this.MoveRight != null){
            this.MoveRight();
        }
    }

    void OnRush(){ //called when the user presses the rush button
      if(this.Rush != null){
            this.Rush();
        }
    }


    IEnumerator LaunchTicks(){ //called every frame
        yield return new WaitForSeconds(tick);
        if(Tick != null){
            Tick();
        }
    }
}