using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    private bool needFlowDown = true;
    private float xValue;
    private float zValue;
    private float yValue;
    private bool needMove = false;
    private Vector3 rotation;
    private void Start() {
        rotation = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
        
    }
    // Update is called once per frame
    void Update () {

        
        //flow down the obeject
        if (needFlowDown && !needMove) {
            this.gameObject.transform.Translate(new Vector3(0, -0.1f, 0), Space.World);  
        }
        if (!needFlowDown && ! needMove) {
            transform.Rotate(rotation * Time.deltaTime);
        }
        if (needMove) {
            this.gameObject.transform.Translate(new Vector3(1f, 0, 0));
            needMove = false;
        }
        
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ground")) {
            this.gameObject.transform.Translate(new Vector3(0, 0.5f, 0), Space.World);
            needFlowDown = false;
        } else if (other.gameObject.CompareTag("Wall")) {
            needMove = true;
        }
    }

}
