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

    public void ReadyAttack()
    {
        PlayerManager.instance.playerList[currentPlayer - 1].creatureAtt.ReadyAttack();
    }

    public void ChooseOrientation()
    {
        PlayerManager.instance.playerList[currentPlayer - 1].creature.ReadyOrientation();
    }

    public void EndTurn()
    {
        PlayerManager.instance.playerList[currentPlayer - 1].GetComponent<DragDrop>().canMove = false;
        PlayerManager.instance.playerList[currentPlayer - 1].creature.currentMovementPoint = PlayerManager.instance.playerList[currentPlayer - 1].creature.maxMovementPoint;
        PlayerManager.instance.playerList[currentPlayer - 1].creature.hasAttacked = false;
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
