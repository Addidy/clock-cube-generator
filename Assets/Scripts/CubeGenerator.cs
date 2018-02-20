using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject customCube;
    public int maxCubes = 10;
    public int spawnInterval = 2;

    private int lastSpawnTimeSeconds = 0;
    private int nextCubeID = 0;

    void Start () {
        if (customCube == null) 
            Debug.LogError("You forgot to set the Cube prefab");
	}
	
	void Update () {
        string[] timeArray = Clock.time.Split(':');
        int currentSeconds = Int32.Parse(timeArray[timeArray.Length - 1]);

        if (currentSeconds % spawnInterval == 0 && currentSeconds != lastSpawnTimeSeconds) {
            Debug.Log(currentSeconds);
            lastSpawnTimeSeconds = currentSeconds;
            Spawn();
        }        
	}

    void Spawn() {

        CubeID newCube = new CubeID();

        if (nextCubeID >= maxCubes) {
            CubeID[] cubes = GetComponentsInChildren<CubeID>();
            foreach (CubeID cube in cubes) {
                if (cube.cubeID == nextCubeID - maxCubes) {
                    newCube = cube;
                    cube.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + nextCubeID);                    
                    break;
                }
            }
        }else{
            newCube = Instantiate(customCube, new Vector2(this.transform.position.x, this.transform.position.y + nextCubeID), Quaternion.identity).GetComponent<CubeID>();
            newCube.transform.parent = this.transform;            
        }
        newCube.cubeID = nextCubeID;
        nextCubeID++;
    }
}
