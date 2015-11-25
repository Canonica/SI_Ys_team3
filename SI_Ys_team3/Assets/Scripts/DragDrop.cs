using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragDrop : MonoBehaviour {
    Vector3 dist;
    float posX;
    float posY;
    public bool canMove = false;

    List<GameObject> arrayCell;

    Vector3 posObj;
    Vector3 posObjInit;

    void Start()
    {
        arrayCell = new List<GameObject>();
    }

    void Update()
    {
        Debug.Log(name + canMove);
    }


    void OnMouseDown()
    {
        if (canMove == true)
        {
            arrayCell.Clear();

            posObjInit = transform.position;
            dist = Camera.main.WorldToScreenPoint(transform.position);
            posX = Input.mousePosition.x - dist.x;
            posY = Input.mousePosition.y - dist.y;
       
            RaycastHit hit;
            if (Physics.Raycast(posObj, Vector3.forward, out hit, 100.0f))
            {
                if (hit.transform.gameObject.CompareTag("Cell"))
                {
                    hit.transform.gameObject.GetComponent<Cell>().isOccupied = false;
                }
                else
                {
                    Debug.Log("Pas de cell");
                }

            }
        }
    }

    void OnMouseUp()
    {
        if (canMove == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(posObj, Vector3.forward, out hit, 100.0f))
            {
                if (hit.transform.gameObject.GetComponent<Cell>().isOccupied == true)
                {
                    transform.position = posObjInit;
                }
                else
                {
                    if (hit.transform.gameObject.CompareTag("Cell") 
                        && arrayCell.Count-1 <=
                        GetComponent<Creature>().currentMovementPoint)
                    {
                        hit.transform.gameObject.GetComponent<Cell>().isOccupied = true;
                        transform.position = hit.transform.position;
                        transform.position = new Vector3(0, 0, -2) + transform.position;
                    }
                    else
                    {
                        transform.position = posObjInit;
                    }
                }
            }
        }
    }

    void OnMouseDrag()
    {

        if (canMove == true)
        {
            Vector3 curPos =
                  new Vector3(Input.mousePosition.x - posX,
                  Input.mousePosition.y - posY, dist.z);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;

            posObj = transform.position;

            RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(posObj, Vector3.forward, out hit, 100.0f))
            {
                if (hit.transform.gameObject.CompareTag("Cell"))
                {
                    if (!arrayCell.Contains(hit.transform.gameObject))
                    {
                        arrayCell.Add(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}
