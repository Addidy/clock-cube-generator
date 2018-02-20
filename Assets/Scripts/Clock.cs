using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class Clock : MonoBehaviour {

    public static String time;//static to be accessed by other objects (in this case CubeGenerator.cs)
    private Text text;

	void Awake () {
        text = GetComponent<Text>();                //get and set the text component
        time = DateTime.UtcNow.ToString("HH:mm:ss");//set the initial time
    }
	
	void Update () {
        time = DateTime.UtcNow.ToString("HH:mm:ss");//set the time
        text.text = time;                           //display the time
	}
}
