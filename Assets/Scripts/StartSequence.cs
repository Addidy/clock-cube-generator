using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSequence : MonoBehaviour {

    public string nextScene;
    private bool activated = false;

    public void Activate() {
        if (!activated)
        {
            activated = true;
            GetComponent<Animation>().Play();
        }
    }

    public void nextSceneOpen() {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
