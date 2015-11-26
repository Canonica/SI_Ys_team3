using UnityEngine;
using System.Collections;

public class StunningVenom : ActiveAbility
{

	// Use this for initialization
	void Start ()
    {
        crea = GetComponent<Creature>();
        creatt = GetComponent<CreatureAttack>();

    }

    override public void ReadyAbility()
    {
        Debug.Log("yolo");
        RaycastHit hit1, hit2;
        if(Physics.Raycast(transform.position + crea.orientation * MapManager.instance.cellSize, Vector3.forward, out hit1, 1000f))
        {
            if(hit1.transform.CompareTag("Cell"))
            {
                MapManager.instance.ColorCell(hit1.transform.gameObject.GetComponent<Cell>());
            }
            if (Physics.Raycast(transform.position + crea.orientation * 2 * MapManager.instance.cellSize, Vector3.forward, out hit2, 1000f))
            {
                if (hit2.transform.CompareTag("Cell"))
                {
                    MapManager.instance.ColorCell(hit2.transform.gameObject.GetComponent<Cell>());
                }
            }
        }
        readyAbility = true;
    }

    override public void UnReadyAbility()
    {
        RaycastHit hit1, hit2;
        if (Physics.Raycast(transform.position + crea.orientation * MapManager.instance.cellSize, Vector3.forward, out hit1, 1000f))
        {
            if (hit1.transform.CompareTag("Cell"))
            {
                Debug.Log(hit1.transform.gameObject.name);
                MapManager.instance.UnColorCell(hit1.transform.gameObject.GetComponent<Cell>());
            }
            if (Physics.Raycast(transform.position + crea.orientation * 2 * MapManager.instance.cellSize, Vector3.forward, out hit2, 1000f))
            {
                if (hit2.transform.CompareTag("Cell"))
                {
                    Debug.Log(hit1.transform.gameObject.name);
                    MapManager.instance.UnColorCell(hit2.transform.gameObject.GetComponent<Cell>());
                }
            }
        }
        readyAbility = false;
    }

    override public void UseAbility(GameObject target)
    {
        UseAbility();
        target.GetComponent<Creature>().currentMovementPoint--;
    }

    override public void UseAbility()
    {
        base.UseAbility();
        UnReadyAbility();
    }
}
