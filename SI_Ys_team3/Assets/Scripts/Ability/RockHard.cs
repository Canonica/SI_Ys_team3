﻿using UnityEngine;
using System.Collections;

public class RockHard : PassiveAbility
{

	// Use this for initialization
	void Start () {

        crea = GetComponent<Creature>();
        creatt = GetComponent<CreatureAttack>();
    }

    override public void ApplyAbility()
    {
        
    }
}
