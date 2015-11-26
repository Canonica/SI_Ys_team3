using UnityEngine;
using System.Collections;

public class Demolition : ActiveAbility
{

    public static int DAMAGEDONE = 5;
    public static int DAMAGETAKEN = 2;

	// Use this for initialization
	void Start ()
    {
        crea = GetComponent<Creature>();
        creatt = GetComponent<CreatureAttack>();

        useAbility = true;

	}

    override public void UseAbility()
    {
        Debug.Log("lol");
        RaycastHit[] hits = Physics.RaycastAll(transform.position, crea.orientation, MapManager.instance.cellSize);
        Debug.Log("XD");
        if (hits.Length > 0 && crea.currentMovementPoint > 0)
        {
            Debug.Log("PTDR");
            bool walls = false;
            foreach(RaycastHit hit in hits)
            {
                if(hit.transform.CompareTag("Wall"))
                {
                    walls = true;
                }
            }
            if (!walls)
                return;

            Debug.Log("HOLALA");
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.CompareTag("Wall"))
                {
                    hit.transform.gameObject.SetActive(false);
                }
                else if(hit.transform.CompareTag("Creature") && name != hit.transform.name)
                {
                    hit.transform.gameObject.GetComponent<Creature>().Hit(DAMAGEDONE);
                }
            }

            Debug.Log("YUP");
            crea.Hit(DAMAGETAKEN);
            crea.currentMovementPoint--;

        }

        TurnManager.instance.EndTurn();
    }
}
