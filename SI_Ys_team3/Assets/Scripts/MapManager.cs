using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {

    public static MapManager instance = null;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public int width = 3;
    public int height = 4 ;

    public GameObject prefab;
    public List<GameObject> map;


	// Use this for initialization
	void Start () {

        //map = new GameObject[width, height];
        map = new List<GameObject>();

        /*float startPos = 0.2f;
        float endPos = 0.8f;*/

        GameObject go = GameObject.Find("Cells");

        for(int i = 0; i < width; i++)
        {
            for(int j =0; j < height; j++)
            {
                /*Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3( ((float) i /width)*endPos+startPos, ((float) j /height) * endPos + startPos, 0.0f)) ;
                position.z = 0;
                map[i, j] =  Instantiate(prefab, position, Quaternion.identity) as GameObject;*/
                map.Add(go.transform.GetChild(i * height + j).gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
