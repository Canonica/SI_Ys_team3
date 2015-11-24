using UnityEngine;
using System.Collections;

public class NotUnloadManager : MonoBehaviour {

    public static NotUnloadManager instance = null;
    
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
