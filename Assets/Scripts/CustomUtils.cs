using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomUtils {   //personal class for custom utilities

    public static void BroadcastAll(string function) {                                          //broadcast to all gameobjects in the scene
        GameObject[] gameObjects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));  //get a list of every gameobject currently in the scene
        foreach (GameObject gameObject in gameObjects) {                                            //for each game object...
            if (gameObject && gameObject.transform.parent == null)                                      //if the game object has no parent...
                gameObject.gameObject.BroadcastMessage(function, SendMessageOptions.DontRequireReceiver);   //has the gameobject broadcast a message to itself and its children
        }
    }
}
