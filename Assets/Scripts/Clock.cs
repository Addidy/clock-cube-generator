using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour {

    public DateTime time;
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time = DateTime.UtcNow;
        text.text = time.ToString("HH:mm:ss");
	}
}
