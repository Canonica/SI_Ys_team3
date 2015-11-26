using UnityEngine;
using System.Collections;

public class RockHard : PassiveAbility
{

    public static int BOOSTARMORFROMRANGE = 1;

	// Use this for initialization
	void Start () {

        crea = GetComponent<Creature>();
        creatt = GetComponent<CreatureAttack>();
    }

    override public void ApplyAbility()
    {
        crea.defense += BOOSTARMORFROMRANGE;
    }

    override public void UnApplyAbility()
    {
        crea.defense -= BOOSTARMORFROMRANGE;
    }
}
