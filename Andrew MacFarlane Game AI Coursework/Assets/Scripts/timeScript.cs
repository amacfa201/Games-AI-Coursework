using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeScript : MonoBehaviour {
    public Text timeText;
    public int hours;
    public int minutes;

    public int currentTime;

    string timeStringTemp;

    public int daysElapsed;
    public float timeElapsed;

    public Text textUpdates;


    public bool testBool;

    public float timeFactor = 0.1f;

    public float minuteLimiter= 0;
    public float hourLimit = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timeElapsed += Time.deltaTime;
        minuteLimiter += Time.deltaTime;

        if (minuteLimiter > timeFactor)
        {
            minuteLimiter = 0f;
            minutes++;
        }


        if (minutes == 59)
        {
            minutes = 0;
            hours++;
        }

        if (hours == 24) {
            hours = 0;
            daysElapsed++;
        }


        if (hours < 10)

        {
            timeText.text = "0" + hours + ":";
            timeStringTemp = "0" + hours.ToString();
        }
        else
        {
            timeText.text = hours + ":";
            timeStringTemp = hours.ToString();
        }

        if (minutes < 10)
        {
            timeText.text = timeText.text + " 0 " + minutes;
            timeStringTemp = timeStringTemp + "0" + minutes.ToString();
        }
        else
        {
            timeText.text = timeText.text + minutes;
            timeStringTemp = timeStringTemp + minutes.ToString();
        }

        

        
        //timeStringTemp = hours.ToString() + minutes.ToString();
        int.TryParse(timeStringTemp, out currentTime);

        if (currentTime > 400)
        {
            testBool = true;
        }


       // textUpdates.text = textUpdates.text + "Testing text output box: " + minutes + "\n";



	}



}
