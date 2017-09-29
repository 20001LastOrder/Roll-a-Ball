using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCreator : MonoBehaviour {
    public int numberOfCollectables = 15;
    public int numberOfObstacles = 5;
    public int numberOfSprings = 5;
    public float distanceForSpring = 5;
    private GameObject collectable;
    private GameObject[] collectableList;
    private GameObject obstacle;
    private GameObject[] obstaclesList;
    private GameObject spring;
    private GameObject enemy;
    // Use this for initialization
    void Start() {
        //load game resources
        float xValue;
        float zValue;
        collectable = (GameObject)Resources.Load("Pick Up", typeof(GameObject));
        obstacle = (GameObject)Resources.Load("Obstacle", typeof(GameObject));
        spring = (GameObject)Resources.Load("Spring", typeof(GameObject));

        //create new obstacle list
        obstaclesList = new GameObject[numberOfObstacles];
        //create Obstacle Objects
        for (int i = 0; i < numberOfObstacles; i++) {
            xValue = UnityEngine.Random.Range(-14, 14);
            zValue = UnityEngine.Random.Range(-14, 14);
            obstaclesList[i] = createObstacle(xValue, zValue);
        }

        //create new collectable list
        collectableList = new GameObject[numberOfCollectables];
        //create Collectable Objects;
        for (int i = 0; i < numberOfCollectables; i++) {
            xValue = UnityEngine.Random.Range(-16, 16);
            zValue = UnityEngine.Random.Range(-16, 16);
            collectableList[i] = createCollectable(xValue, zValue);
        } //end for loop

        //create new spring object
        for (int i = 0; i < numberOfSprings; i++) {
            createSprings(obstaclesList[i], this.distanceForSpring);
        }
    } //end start

	
	// Update is called once per frame
	void Update () {
		
	}

    private GameObject createCollectable(float x, float z){
        Vector3 position = new Vector3(x, 10f, z);
        Quaternion rotation = new Quaternion(45, 45, 45, 0);
        GameObject o = Instantiate(collectable,position,rotation);
        return o;
    }

    private GameObject createObstacle(float x, float z) {
        Vector3 position = new Vector3(x, 0.6f, z);
        GameObject o = Instantiate(obstacle, position,new Quaternion(0,0,0,0));
        return o;
    }

    private void createSprings(GameObject o, float distance) {
        float x = UnityEngine.Random.value;
        float z = UnityEngine.Random.value;
        Vector3 direction = (new Vector3(x, 0, z)).normalized;
        Vector3 position = o.transform.position -new Vector3(0,0.63f,0)+ (direction * distanceForSpring);
        Instantiate(spring, position, new Quaternion(0, 0, 0,0));

    } //end createSprings

    public GameObject[] getCollectables() {
        return collectableList;
    }
}
