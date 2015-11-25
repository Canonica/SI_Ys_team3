using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance = null;
    

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public List<PlayerScript> playerList;

    public GameObject prefab;

    // Use this for initialization
    void Start () {
        playerList = new List<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addPlayer(PlayerScript player)
    {
        playerList.Add(player);
    }

    public void InstanciatePlayer(GameObject spawner)
    {
        GameObject instance = Instantiate(prefab) as GameObject;
        instance.GetComponent<PlayerScript>().SetId(playerList.Count + 1);
        instance.transform.position = spawner.transform.position;
        instance.transform.position = new Vector3(0, 0, -2) + instance.transform.position;
        TurnManager.instance.playerIdList.Add(playerList.Count + 1);
    }
}
