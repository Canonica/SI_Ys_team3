using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour {

    public static TurnManager instance = null;

    public List<int> playerIdList;
    public int currentPlayer;

    public int nbObTurns = 1;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        playerIdList = new List<int>();
        currentPlayer = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EndTurn()
    {
        PlayerManager.instance.playerList[currentPlayer - 1].GetComponent<DragDrop>().canMove = false;
        if (currentPlayer == 2)
        {
            currentPlayer = 1;
            nbObTurns++;
            
        }
        else if (currentPlayer == 1)
        {
            currentPlayer = 2;
        }
        PlayerManager.instance.playerList[currentPlayer-1].GetComponent<DragDrop>().canMove = true;
    }
}
