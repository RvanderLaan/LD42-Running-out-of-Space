using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public GameObject target;
    public float smoothness = 0.9f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.x = target.transform.position.x;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);        
	}
}
