using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float force = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collison) {
        Collider other = collison.collider;
        if (other.gameObject.CompareTag("Player")) {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 localDirection = other.gameObject.GetComponent<Player>().getDirection();
            if (!rb.IsSleeping()) { 
               rb.AddForce(-localDirection * force);
            } else {
                rb.Sleep();
            }
        }
    }
}
