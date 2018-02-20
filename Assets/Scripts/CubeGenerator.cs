using System;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject customCube;
    public int maxCubes = 10;
    public int spawnInterval = 2;

    private int lastSpawnTimeSeconds = 0;
    private int nextCubeID = 0;

    private bool activated = false;

    void EnterSequenceFinished(){  activated = true; }  //flag that the opening animation has finished

    void Start () {
        if (customCube == null)                                 //if the custom cube was not set in the inspector...
            Debug.LogError("You forgot to set the Cube prefab");    //tell me
	}
	
	void Update () {
        if (!activated) return;                                                             // if opening animation is not finished, do nothing

        string[] timeArray = Clock.time.Split(':');                                         // To get the seconds from the clock we are first going to split it's string representation into an array where the last value is seconds
        int currentSeconds = Int32.Parse(timeArray[timeArray.Length - 1]);                  // Get the current seconds value from the clock

        if (currentSeconds % spawnInterval == 0 && currentSeconds != lastSpawnTimeSeconds) {// if the current clock seconds is divisible by the spawnInterval(set to 2 in inspector) AND it is a different value from the last interval...
            lastSpawnTimeSeconds = currentSeconds;                                              //set the last time interval to be this currenttime
            Spawn();                                                                            //spawn the next cube
        }        
	}

    void Spawn() {        

        if (nextCubeID >= maxCubes) {                               //if maxcubes(set in inspector to be 10) have been spawned
            CustomCube[] cubes = GetComponentsInChildren<CustomCube>(); //get an array of all the cubes
            foreach (CustomCube cube in cubes) {                        //and for each cube found...
                if (cube.cubeID == nextCubeID - maxCubes) {                 //if the cube was spawned "maxCubes" ago...
                    Destroy(cube.gameObject);                                   //destroy it
                    break;                                                      //stop checking more cubes (by exiting the loop
                }
            }
        }
        CustomCube newCube = Instantiate(customCube, new Vector2(this.transform.position.x, this.transform.position.y + nextCubeID), Quaternion.identity).GetComponent<CustomCube>();//spawn a new cube on top of the last one
        newCube.transform.parent = this.transform;  //add it to object pool
        newCube.cubeID = nextCubeID;                //set the cubes id
        nextCubeID++;                               //increment the next cubeid
    }
}
