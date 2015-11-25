using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int id;
    public int actionPoint = 4;

    public int x;
    public int y;

    public CreatureAttack creatureAtt;
    public Creature creature;

    // Use this for initialization
    void Start()
    {
        creatureAtt = GetComponent<CreatureAttack>();
        creature = GetComponent<Creature>();
        PlayerManager.instance.addPlayer(this);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetId()
    {
        return id;
    }

    public void SetId(int Id)
    {
        id = Id;
    }
}
