using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public Transform target;
    public float totalWidth = 24;
    public float spriteSize = 8;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        if (target.position.x > transform.position.x + spriteSize / 2) {
            newPos.x += spriteSize * 2;
        } else if (target.position.x < transform.position.x - spriteSize * 2) {
            newPos.x -= spriteSize * 2;
        }
        transform.position = newPos;
	}
}
