using UnityEngine;
using System.Collections;

public class SoundEvent : MonoBehaviour {

    public AudioClip running01;
    public AudioClip shield_hit01;
    public AudioClip sword_hit01;
    public AudioClip sword_hit02;
    
    public void running()
    {
        SoundManager.instance.PlaySingle(running01);
    }

    public void sword()
    {
        SoundManager.instance.RandomizeSfx(sword_hit01, sword_hit02);
    }

    public void shield()
    {
        SoundManager.instance.PlaySingle(shield_hit01);
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
