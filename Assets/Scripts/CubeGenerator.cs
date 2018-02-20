using System;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject customCube;
    public int maxCubes = 10;
    public int spawnInterval = 2;

    private int lastSpawnTimeSeconds = 0;
    private int nextCubeID = 0;

    private bool activated = false;

    void EnterSequenceFinished(){  activated = true; }

    void Start () {
        if (customCube == null) 
            Debug.LogError("You forgot to set the Cube prefab");
	}
	
	void Update () {
        if (!activated) return;

        string[] timeArray = Clock.time.Split(':');
        int currentSeconds = Int32.Parse(timeArray[timeArray.Length - 1]);

        if (currentSeconds % spawnInterval == 0 && currentSeconds != lastSpawnTimeSeconds) {
            lastSpawnTimeSeconds = currentSeconds;
            Spawn();
        }        
	}

    void Spawn() {        

        if (nextCubeID >= maxCubes) {
            CustomCube[] cubes = GetComponentsInChildren<CustomCube>();
            foreach (CustomCube cube in cubes) {
                if (cube.cubeID == nextCubeID - maxCubes) {
                    Destroy(cube.gameObject);                 
                    break;
                }
            }
        }
        CustomCube newCube = Instantiate(customCube, new Vector2(this.transform.position.x, this.transform.position.y + nextCubeID), Quaternion.identity).GetComponent<CustomCube>();
        newCube.transform.parent = this.transform;
        newCube.cubeID = nextCubeID;
        nextCubeID++;
    }
}
