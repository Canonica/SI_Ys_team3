using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
    public float fadeSpeed = 1.5f;

    public float waitFade = 1.5f;

    bool fadeIn = false;
    bool fadeOut = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeIn)
        {
            if(GetComponent<Renderer>() && GetComponent<Renderer>().material.color.a < 1f)
            {
                GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, GetComponent<Renderer>().material.color.a + Time.deltaTime * fadeSpeed) ;
            }
            else
            {
                fadeIn = false;
                StartCoroutine(FadeDelay());
            }
        }

        if (fadeOut)
        {
            if (GetComponent<Renderer>() && GetComponent<Renderer>().material.color.a > 0f)
            {
                GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, GetComponent<Renderer>().material.color.a - Time.deltaTime * fadeSpeed);
            }
            else
            {
                fadeOut = false;
            }
        }
	}



    public void FadeIn()
    {
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(waitFade);
        FadeOut();
    }
}
