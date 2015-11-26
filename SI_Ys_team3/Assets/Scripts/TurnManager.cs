using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour {

    public static TurnManager instance = null;

    public List<int> playerIdList;
    public int currentPlayer;

    public int nbObTurns = 1;
    public BonusBehavior bonus1;
    public BonusBehavior bonus2;

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

    public void ReadyAbility()
    {
        if (PlayerManager.instance.playerList[currentPlayer - 1].creatureActif.useAbility)
        {
            PlayerManager.instance.playerList[currentPlayer - 1].creatureActif.UseAbility();
        }
        else
        {
            PlayerManager.instance.playerList[currentPlayer - 1].creatureActif.ReadyAbility();
        }

    }

    public void ReadyAttack()
    {
        PlayerManager.instance.playerList[currentPlayer - 1].creatureAtt.ReadyAttack();
    }

    public void ChooseOrientation()
    {
        PlayerManager.instance.playerList[currentPlayer - 1].creature.ReadyOrientation();
    }

    public void Unready()
    {
        PlayerScript pl = PlayerManager.instance.playerList[currentPlayer - 1];
        pl.creatureAtt.readyAttack = false;
        pl.creature.readyOrientation = false;
        pl.creatureActif.readyAbility = false;
    }

    public void EndTurn()
    {
        PlayerManager.instance.playerList[currentPlayer - 1].GetComponent<DragDrop>().canMove = false;
        PlayerManager.instance.playerList[currentPlayer - 1].creature.currentMovementPoint = PlayerManager.instance.playerList[currentPlayer - 1].creature.maxMovementPoint;
        PlayerManager.instance.playerList[currentPlayer - 1].creature.hasAttacked = false;
        if (currentPlayer == 2)
        {
            currentPlayer = 1;
            LDManager.instance.nbTurnsSinceLastChange++;
            MenuManager.instance.canvasQuickMenuP1.SetActive(true);
            MenuManager.instance.canvasQuickMenuP2.SetActive(false);

        }
        else if (currentPlayer == 1)
        {
            currentPlayer = 2;
            LDManager.instance.nbTurnsSinceLastChange++;
            MenuManager.instance.canvasQuickMenuP1.SetActive(false);
            MenuManager.instance.canvasQuickMenuP2.SetActive(true);
        }

        bonus1.IncreaseTurn();
        bonus2.IncreaseTurn();
        PlayerManager.instance.playerList[currentPlayer-1].GetComponent<DragDrop>().canMove = true;
    }
}
