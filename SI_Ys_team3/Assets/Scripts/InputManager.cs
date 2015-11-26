using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    public static InputManager instance = null;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {




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
                    if (!pl.creatureActif.readyAbility && !pl.creatureAtt.readyAttack && !pl.creature.readyOrientation && other.CompareTag("Cell"))
                    {
                        if (Vector3.Distance(pl.transform.position, other.transform.position + new Vector3(0, 0, -2)) == MapManager.instance.cellSize && pl.creature.currentMovementPoint > 0)
                        {
                            if (Physics.Raycast(pl.transform.position, other.transform.position + new Vector3(0, 0, -2) - pl.transform.position, out hit, MapManager.instance.cellSize))
                            {
                                //Debug.Log(hit.transform.tag);
                            }
                            else
                            {
                                Physics.Raycast(pl.transform.position, Vector3.forward, out hit, 1000.0f);
                                other.GetComponent<Cell>().isOccupied = true;
                                if(hit.transform && hit.transform.CompareTag("Cell"))
                                {
                                    hit.transform.GetComponent<Cell>().isOccupied = false;
                                }
                                else
                                {
                                    Debug.Log("pas cell");
                                }
                                pl.transform.position = other.transform.position;
                                pl.transform.position = new Vector3(0, 0, -2) + pl.transform.position;
                                pl.creature.currentMovementPoint--;
                                pl.GetComponentInChildren<TextMesh>().text = pl.creature.currentMovementPoint.ToString();
                            }

                        }

                    }
                }
                if (!pl.GetComponent<Creature>().hasAttacked)
                {
                    Physics.Raycast(pl.transform.position + pl.creature.orientation * MapManager.instance.cellSize, Vector3.forward, out hit, 1000.0f);
                    if (other.CompareTag("Creature") && other.name != pl.gameObject.name)
                    {
                        if (pl.creatureAtt.readyAttack)
                        {
                            pl.creatureAtt.OnAttack(other.GetComponent<Creature>());
                        }
                        else if (pl.creatureActif.readyAbility)
                        {
                            pl.creatureActif.UseAbility(other);
                        }
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
                        else if (pl.creature.readyOrientation)
                        {
                            RaycastHit hit2;
                            Physics.Raycast(pl.transform.position, Vector3.forward, out hit2, 1000.0f);
                            MapManager.instance.UnColorAdjCell(hit2.transform.GetComponent<Cell>());
                            pl.creature.readyOrientation = false;
                        }
                        else if (pl.creatureActif.readyAbility)
                        {
                            pl.creatureActif.UnReadyAbility();
                        }
                    }
                }

                if (pl.creature.readyOrientation && other.CompareTag("Cell"))
                {
                    if (Vector3.Distance(pl.transform.position, other.transform.position + new Vector3(0, 0, -2)) == MapManager.instance.cellSize)
                    {
                        Vector3 direction = other.transform.position - pl.transform.position;
                        pl.creature.SetOrientation(direction.normalized);
                    }
                }
                else if (pl.creature.readyOrientation && other.CompareTag("Creature") && other.name != pl.gameObject.name)
                {
                    if (Vector3.Distance(pl.transform.position, other.transform.position) == MapManager.instance.cellSize)
                    {
                        Vector3 direction = other.transform.position - pl.transform.position;
                        pl.creature.SetOrientation(direction.normalized);
                    }
                }
            }
        }
    }
}
