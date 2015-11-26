using UnityEngine;
using System.Collections;

public class CreatureAttack : MonoBehaviour
{

    public PlayerScript player;
    public Creature creature;

    public bool readyAttack = false;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<PlayerScript>();
        creature = GetComponent<Creature>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadyAttack()
    {
        if (!creature.hasAttacked)
        {
            readyAttack = true;
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.forward, out hit, 1000.0f);
            MapManager.instance.ColorFrontCell(hit.transform.GetComponent<Cell>(), creature.orientation);
        }
    }

    public void OnAttack(Creature other)
    {
        if (!creature.hasAttacked && readyAttack)
        {
            RaycastHit hit;

            Ray ray = new Ray(transform.position, other.transform.position - transform.position);
            LongNeck longn = player.creaturePassif as LongNeck;
            if (longn)
            {
                ray = new Ray(transform.position + creature.orientation * MapManager.instance.cellSize + Vector3.forward * -2, Vector3.forward);
            }
            if (Mathf.Abs((other.transform.position - transform.position).magnitude) <= creature.autoRange * MapManager.instance.cellSize)
            {
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    if (hit.transform.gameObject.CompareTag("Creature"))
                    {
                        Debug.Log("Attaque !");
                        if (longn)
                        {
                            longn.ApplyAbility();
                        }
                        Attack(other, creature.autoRange > 1);
                        Physics.Raycast(transform.position, Vector3.forward, out hit, 1000.0f);
                        MapManager.instance.UnColorFrontCell(hit.transform.GetComponent<Cell>(), creature.orientation);
                        if (longn)
                        {
                            longn.UnApplyAbility();
                        }
                    }
                }
            }
        }
        readyAttack = false;
    }

    void Attack(Creature other, bool ranged)
    {
        if (creature.currentMovementPoint >= 0 && creature.maxMovementPoint > creature.currentMovementPoint)
        {
            creature.currentMovementPoint = 0;
            other.Hit(creature.damage, ranged);
            creature.hasAttacked = true;
        }
        else if (creature.maxMovementPoint == creature.currentMovementPoint)
        {
            other.Hit(creature.damage, ranged);
            creature.hasAttacked = true;
        }
        creature.damage = 3;

    }

    public bool CanAttack()
    {

        return true;
    }
}
