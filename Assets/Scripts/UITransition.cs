using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animation))]
public class UITransition : MonoBehaviour {

    public string nextScene;
    private bool activatedExitSequence = false;

    public void StartExitSequence() {                   //Called by onclick function on start button
        if (!activatedExitSequence){                        //If the exit sequence has not yet been activated...
            activatedExitSequence = true;                       //flag the exit sequence has been activated
            GetComponent<Animation>().Play();                   //start the attached animation (event at the end of exitanimation will call nextSceneOpen)
        }
    }

    public void EnterSequenceEnd() {                    //Called by the end of the transitionenter animation, The idea is to start scene operations only when the animation has finished)
        BroadcastMessage("EnterSequenceFinished");          //all children with "EnterSequenceFinished" functions will start their operations
    }

    public void nextSceneOpen() {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);    //go to the scene specified in the inspector
    }
}
