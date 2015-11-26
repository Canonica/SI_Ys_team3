using UnityEngine;
using System.Collections;

public class LongNeck : PassiveAbility
{

    public bool canAttackThroughWall = true;

	// Use this for initialization
	void Start () {

        crea = GetComponent<Creature>();
        creatt = GetComponent<CreatureAttack>();
    }

    override public void ApplyAbility()
    {
        crea.damage--;
    }

    override public void UnApplyAbility()
    {
        crea.damage++;
    }
}
