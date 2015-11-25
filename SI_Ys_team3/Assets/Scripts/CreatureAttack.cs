using UnityEngine;
using System.Collections;

public class CreatureAttack : MonoBehaviour {

    public PlayerScript player;
    public Creature creature;

	// Use this for initialization
	void Start () {
        player = GetComponent<PlayerScript>();
        creature = GetComponent<Creature>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnAttack(Creature other)
    {
        if(!creature.hasAttacked)
        {
            RaycastHit hit;

            Ray ray = new Ray(transform.position,other.transform.position - transform.position);
            if (Mathf.Abs((other.transform.position - transform.position).magnitude) <= creature.autoRange * MapManager.instance.cellSize)
            {
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    if(hit.transform.gameObject.CompareTag("Creature"))
                    {
                        Attack(other);
                    }
                }
            }
        }
    }

    void Attack(Creature other)
    {
        other.Hit(creature.damage);
        creature.hasAttacked = true;
    }
}
