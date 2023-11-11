using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    [SerializeField] GameObject score;
    [SerializeField] GameObject button;
    [SerializeField] Text text;
    [SerializeField] GameObject jai;
    [SerializeField] GameObject dumpa;
    ScoreSaver scoreSaver;
    // Start is called before the first frame update
    void Start()
    {
        jai.SetActive(false);
        dumpa.SetActive(false);
        scoreSaver = GameObject.FindWithTag("Score").GetComponent<ScoreSaver>();
        StartCoroutine(LateStart());
        text.text = "Score: " + scoreSaver.score;
        if(scoreSaver.type == 0)
        {
            jai.SetActive(true);
        }
        else
        {
            dumpa.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LateStart()
    {
        score.SetActive(false);
        button.SetActive(false);
        yield return new WaitForSeconds(2);
        score.SetActive(true);
        button.SetActive(true);
    }
}
