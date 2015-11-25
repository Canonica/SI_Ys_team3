using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState { menu, pause, playing, endOfGame };
    public GameState gamestate;


    public static GameManager instance = null;


    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(gamestate);
	}

    public void Start_Game()
    {
        PlayerManager.instance.playerList[TurnManager.instance.currentPlayer-1].GetComponent<DragDrop>().canMove = true;
    }
}
