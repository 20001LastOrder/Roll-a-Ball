using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private GameObject[] collectables;
    private GameObject target;
    private Rigidbody rb;
    private bool needAnotherTarget = true;
    // Use this for initialization
    IEnumerator Start () {
        yield return new WaitForSeconds(2f);
        collectables = GameObject.Find("Ground").GetComponent<ObjectsCreator>().getCollectables();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = 0;
        if (needAnotherTarget) {
            for (int i = 0; i < collectables.Length; i++) {
                float newDistance = Vector3.Distance(this.gameObject.transform.position, collectables[i].transform.position);
                if (i == 0) {
                    distance = newDistance;
                    target = collectables[i];
                } else if (newDistance < distance) {
                    target = collectables[i];
                    distance = newDistance;
                } //end if  
            } //end for loop
            needAnotherTarget = false;
        }
       
        Vector3 direction =   (target.transform.position - new Vector3(0, 0.5f, 0)) - this.transform.position;
        direction = direction.normalized;
        print (target.transform.position);
        rb.AddForce(direction*10);
        //TODO: add method to continuously change the list of collectables
        //      implement the same collision method for enemy as for players
	}

    public void setCollectables(GameObject[] c) {
        collectables = c;
    }
}
