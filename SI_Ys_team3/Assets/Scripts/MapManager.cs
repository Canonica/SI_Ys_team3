using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{

    public static MapManager instance = null;

    void Awake()
    {
        instance = this;
    }


    public int width = 3;
    public int height = 4;

    public float cellSize = 1.5f;

    public GameObject prefab;
    public List<GameObject> map;


    // Use this for initialization
    void Start()
    {

        //map = new GameObject[width, height];
        map = new List<GameObject>();

        /*float startPos = 0.2f;
        float endPos = 0.8f;*/



        GameObject go = GameObject.Find("Cells");

        if (go)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    /*Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3( ((float) i /width)*endPos+startPos, ((float) j /height) * endPos + startPos, 0.0f)) ;
                    position.z = 0;
                    map[i, j] =  Instantiate(prefab, position, Quaternion.identity) as GameObject;*/
                    GameObject cell = go.transform.GetChild(i * height + j).gameObject;
                    cell.AddComponent<Cell>();
                    cell.GetComponent<Cell>().x = i;
                    cell.GetComponent<Cell>().y = j;
                    cell.GetComponent<Renderer>().material.color = Color.yellow;
                    map.Add(cell);

                }
            }
        }

    }


    public void ColorAdjCell(Cell cell)
    {
        GameObject up;
        GameObject down;
        GameObject left;
        GameObject right;

        if (cell.x * height + cell.y + height < map.Count)
        {
            right = map[cell.x * height + cell.y + height];
            right.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (cell.x * height + cell.y - height >= 0)
        {
            left = map[cell.x * height + cell.y - height];
            left.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (cell.x * height + cell.y - 1 > 0 && cell.y - 1 > 0)
        {
            up = map[cell.x * height + cell.y - 1];
            up.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (cell.x * height + cell.y + 1 < map.Count && (cell.y + 1) < height)
        {
            down = map[cell.x * height + cell.y + 1];
            down.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    public void UnColorAdjCell(Cell cell)
    {
        GameObject up;
        GameObject down;
        GameObject left;
        GameObject right;

        if (cell.x * height + cell.y + height < map.Count)
        {
            right = map[cell.x * height + cell.y + height];
            right.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (cell.x * height + cell.y - height >= 0)
        {
            left = map[cell.x * height + cell.y - height];
            left.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (cell.x * height + cell.y - 1 >= 0)
        {
            up = map[cell.x * height + cell.y - 1];
            up.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (cell.x * height + cell.y + 1 < map.Count)
        {
            down = map[cell.x * height + cell.y + 1];
            down.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    public void ColorFrontCell(Cell cell, Vector3 direction)
    {
        switch (Mathf.RoundToInt(direction.x))
        {
            case -1:
                map[cell.x * height + cell.y - height].GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 1:
                map[cell.x * height + cell.y + height].GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
        switch (Mathf.RoundToInt(direction.y))
        {
            case -1:
                map[cell.x * height + cell.y + 1].GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 1:
                map[cell.x * height + cell.y - 1].GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }

    public void UnColorFrontCell(Cell cell, Vector3 direction)
    {
        switch (Mathf.RoundToInt(direction.x))
        {
            case -1:
                map[cell.x * height + cell.y - height].GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 1:
                map[cell.x * height + cell.y + height].GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
        switch (Mathf.RoundToInt(direction.y))
        {
            case -1:
                map[cell.x * height + cell.y + 1].GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 1:
                map[cell.x * height + cell.y - 1].GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
    }

    public void UnColorCell(Cell cell)
    {
        cell.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void ColorCell(Cell cell)
    {
        cell.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void Play()
    {
        Start();
        if (GameObject.Find("Grid"))
        {
            cellSize = GameObject.Find("Grid").transform.lossyScale.x;
        }
        else if (GameObject.Find("Grid2"))
        {
            cellSize = GameObject.Find("Grid2").transform.lossyScale.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
