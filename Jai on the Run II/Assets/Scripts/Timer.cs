using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] ScoreSaver scoreSaver;
    int time;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
        time = 0;
        StartCoroutine(Increase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Increase() 
    {
        while(true) 
        {
            yield return new WaitForSeconds(1);
            time++;
            text.text = "" + time;
        }
    }
    public void SetScore(int type)
    {
        ScoreSaver scoreSaver = GameObject.FindWithTag("Score").GetComponent<ScoreSaver>();
        scoreSaver.score = time;
        scoreSaver.type = type;
    }
}
