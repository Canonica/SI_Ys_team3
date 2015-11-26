using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int id;
    public int actionPoint = 4;

    public Creature creature;
    public CreatureAttack creatureAtt;
    public ActiveAbility creatureActif;
    public PassiveAbility creaturePassif;

    // Use this for initialization
    void Start () {
        creature = GetComponent<Creature>();
        creatureAtt = GetComponent<CreatureAttack>();
        creatureActif = GetComponent<ActiveAbility>();
        creaturePassif = GetComponent<PassiveAbility>();
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
