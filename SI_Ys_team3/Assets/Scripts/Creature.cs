using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

    public int maxHealth = 15;
    private int currentHealth;

    public int maxMovementPoint = 3;
    private int currentMovementPoint;
    
    public int damage = 3;
    public int defense = 1;

    public int autoRange = 1;

    public bool hasAttacked = false;

    public PlayerScript player;
    public CreatureAttack creatureAtt;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<PlayerScript>();
        creatureAtt = GetComponent<CreatureAttack>();
        currentHealth = maxHealth;
        currentMovementPoint = maxMovementPoint;
	}
	
	void Update () {

        if(currentMovementPoint <= 0)
        {
            Debug.Log("stop move");
        }
	}

    public void Hit(int damage)
    {
        if(damage != 0)
        {
            currentHealth -= damage * 1 / defense;
        }
        if (currentHealth <= 0)
        {
            Debug.Log("loose");
        }
    }
}
