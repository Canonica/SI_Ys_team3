using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int id;
    public int actionPoint = 4;

    public Creature creature;
    public CreatureAttack creatureAtt;

    // Use this for initialization
    void Start () {
        creature = GetComponent<Creature>();
        creatureAtt = GetComponent<CreatureAttack>();
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
