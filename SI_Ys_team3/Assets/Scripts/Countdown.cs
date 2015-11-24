using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public static Countdown instance = null;


    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public int countDown = 3;
    private Text m_text;
    
    public void CDStart()
    {
       
            m_text = GetComponent<Text>();

            m_text.text = ""+countDown;
            StartCoroutine(StartCD());
    }

    IEnumerator StartCD()
    {

        while((countDown > 0) )
        {
            yield return new WaitForSeconds(1f);
            countDown--;
            Debug.Log(countDown);
        }
        GameManager.instance.gamestate = GameManager.GameState.playing;
    }

}


