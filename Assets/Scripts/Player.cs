using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int score;
    private Vector3 direction;
    private Vector3 lastPosition;
    public UI sceneUI;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        this.lastPosition = this.transform.position;
        sceneUI = GameObject.Find("Ground").GetComponent<UI>();
        sceneUI.showPlayerScore(score);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.direction = this.transform.position - lastPosition;
        this.lastPosition = this.transform.position;
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
        rb.AddForce(movement*speed);

        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } //end if
	}

    private void OnTriggerEnter(Collider other){
       if(other.gameObject.CompareTag("Pick Up")) {
            score++;
            sceneUI.showPlayerScore(score);
            Destroy(other.gameObject);
        }
        
    }

    public Vector3 getDirection() {
        return this.direction;
    }



}
