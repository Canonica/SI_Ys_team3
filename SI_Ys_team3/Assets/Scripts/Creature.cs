using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

    public int maxHealth = 15;
    public int currentHealth;

    public int maxMovementPoint = 3;
    public int currentMovementPoint;


    public int autoRange = 1;

    public bool hasAttacked = false;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        currentMovementPoint = maxMovementPoint;
	}
	
	void Update () {
	    if(currentHealth <= 0)
        {
            Debug.Log("loose");
        }

        if(currentMovementPoint <= 0)
        {
           GetComponent<DragDrop>().canMove = false;
        }
	}
}
