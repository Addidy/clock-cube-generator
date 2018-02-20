using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour {

    public static String time;
    private Text text;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        time = DateTime.UtcNow.ToString("HH:mm:ss");
    }
	
	// Update is called once per frame
	void Update () {
        time = DateTime.UtcNow.ToString("HH:mm:ss");
        text.text = time;
	}
}
