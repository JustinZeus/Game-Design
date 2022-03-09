using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItimer : MonoBehaviour
{
    public Text UItext;
    // Start is called before the first frame update
    void Start()
    {
        UItext = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UItext.text = FormatTime(Time.time);
    }

    string FormatTime (float time){
         int intTime = (int)time;
         int minutes = intTime / 60;
         int seconds = intTime % 60;
         float fraction = time * 1000;
         fraction = (fraction % 1000);
         string timeText = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
         return timeText;
     }
}
