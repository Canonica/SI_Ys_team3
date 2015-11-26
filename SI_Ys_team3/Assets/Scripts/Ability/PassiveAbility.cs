﻿using UnityEngine;
using System.Collections;
using System;

public class PassiveAbility : MonoBehaviour {

    public Creature crea;
    public CreatureAttack creatt;

    // Use this for initialization
    void Start()
    {
        crea = GetComponent<Creature>();
        creatt = GetComponent<CreatureAttack>();
    }

    public virtual void ApplyAbility()
    {

    }

    public virtual void UnApplyAbility()
    {

    }
}