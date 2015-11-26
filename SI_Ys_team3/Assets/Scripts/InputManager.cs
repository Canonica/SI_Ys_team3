using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public static InputManager instance = null;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
	    
        


	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (PlayerManager.instance.playerList.Count > 0 && Physics.Raycast(ray, out hit, 1000.0f))
            {
                PlayerScript pl = PlayerManager.instance.playerList[TurnManager.instance.currentPlayer - 1];
                GameObject other = hit.transform.gameObject;

                if (pl.GetComponent<DragDrop>().canMove)
                {
                    if (!pl.creatureAtt.readyAttack && !pl.creature.readyOrientation && !MenuManager.instance.canvasQuickMenu.activeInHierarchy && other.CompareTag("Cell"))
                    {
                        if (Vector3.Distance(pl.transform.position, other.transform.position + new Vector3(0, 0, -2)) == MapManager.instance.cellSize && pl.creature.currentMovementPoint > 0)
                        {
                            if (Physics.Raycast(pl.transform.position, other.transform.position + new Vector3(0, 0, -2) - pl.transform.position, out hit, MapManager.instance.cellSize))
                            {
                                Debug.Log(hit.transform.tag);
                            }
                            else
                            {
                                Debug.Log(Vector3.Distance(pl.transform.position, other.transform.position));
                                pl.transform.position = other.transform.position;
                                pl.transform.position = new Vector3(0, 0, -2) + pl.transform.position;
                                pl.creature.currentMovementPoint--;
                                pl.GetComponentInChildren<TextMesh>().text = pl.creature.currentMovementPoint.ToString();
                            }

                        }

                    }
                }
                if(!pl.GetComponent<Creature>().hasAttacked)
                {
                    Physics.Raycast(pl.transform.position, pl.creature.orientation, out hit, MapManager.instance.cellSize);
                    /*if (other.CompareTag("Creature") && other.name != pl.gameObject.name)
                    {
                        pl.creatureAtt.OnAttack(other.GetComponent<Creature>());
                    }*/
                    if (hit.transform && hit.transform.CompareTag("Creature") && hit.transform.name != pl.gameObject.name)
                    {
                        pl.creatureAtt.OnAttack(other.GetComponent<Creature>());
                    }
                    else if (other.CompareTag("Creature") && other.name == pl.gameObject.name)
                    {
                        if (pl.creatureAtt.readyAttack)
                        {
                            RaycastHit hit2;
                            Physics.Raycast(pl.transform.position, Vector3.forward, out hit2, 1000.0f);
                            MapManager.instance.UnColorFrontCell(hit2.transform.GetComponent<Cell>(), pl.creature.orientation);
                            pl.creatureAtt.readyAttack = false;
                        }
                        else
                        {
                            MenuManager.instance.Toggle_QuickMenu(other.transform.position);
                        }
                    }
                }
                else if (other.CompareTag("Creature") && other.name == pl.gameObject.name)
                {
                    MenuManager.instance.Toggle_QuickMenu(other.transform.position);
                }

                if (pl.creature.readyOrientation && other.CompareTag("Cell"))
                {
                    if (Vector3.Distance(pl.transform.position, other.transform.position + new Vector3(0, 0, -2)) == MapManager.instance.cellSize)
                    {
                        Vector3 direction = other.transform.position - pl.transform.position;
                        pl.creature.SetOrientation(direction.normalized);
                    } 
                }
                else if(pl.creature.readyOrientation && other.CompareTag("Creature") && other.name != pl.gameObject.name)
                {
                    if (Vector3.Distance(pl.transform.position, other.transform.position) == MapManager.instance.cellSize)
                    {
                        Vector3 direction = other.transform.position - pl.transform.position;
                        pl.creature.SetOrientation(direction.normalized);
                    }
                }
            }
        }

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            Debug.Log("Z");
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Q");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("E");
        }
    }
}
