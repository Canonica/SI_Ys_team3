using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour {

    public static TurnManager instance = null;

    public List<int> playerIdList;
    public int currentPlayer;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
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
        //currentPlayer = currentPlayer % playerIdList.Count;
        if (currentPlayer == 2)
        {
            currentPlayer = 1;
        }
        else if (currentPlayer == 1)
        {
            currentPlayer = 2;
        }
    }
}
