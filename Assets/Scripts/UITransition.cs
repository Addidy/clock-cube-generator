using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animation))]
public class UITransition : MonoBehaviour {

    public string nextScene;
    private bool activatedExitSequence = false;

    public void StartExitSequence() {
        if (!activatedExitSequence){
            activatedExitSequence = true;
            GetComponent<Animation>().Play();
        }
    }

    public void EnterSequenceEnd() {
        BroadcastMessage("EnterSequenceFinished");
    }

    public void nextSceneOpen() {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
