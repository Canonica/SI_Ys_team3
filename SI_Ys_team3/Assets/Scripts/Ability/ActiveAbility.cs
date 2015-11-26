using UnityEngine;
using System.Collections;

public class ActiveAbility : MonoBehaviour {

    public Creature crea;
    public CreatureAttack creatt;
    public bool readyAbility = false;
    public bool useAbility = false;

	// Use this for initialization
	void Start () {
	}

    public virtual void ReadyAbility()
    {
        Debug.Log("Ready Ability : " + name);
    }

    public virtual void UnReadyAbility()
    {
        Debug.Log("Unready Ability : " + name);
    }

    public virtual void UseAbility(GameObject target)
    {
        UseAbility();
    }

    public virtual void UseAbility()
    {
        Debug.Log("Active Ability : " + name);
        crea.hasAttacked = true;
    }
}
