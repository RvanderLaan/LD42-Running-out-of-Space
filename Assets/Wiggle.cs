using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour {

    public float rotateSpeed = 1;
    public float maxWiggleAngle = 30;

	// Use this for initialization
	void Start () {
        StartCoroutine(Rotate((Random.value * 2 - 1) * maxWiggleAngle));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Rotate(float angle) {
        Quaternion oldRot = transform.rotation;
        Quaternion newRot = Quaternion.Euler(new Vector3(0, 0, angle));
        for (float t = 0.0f; t < 1.0; t += Time.deltaTime * rotateSpeed) {
            transform.rotation = Quaternion.Slerp(oldRot, newRot, t);
            yield return null;
        }
        transform.rotation = newRot;
        StartCoroutine(Rotate((Random.value * 2 - 1) * maxWiggleAngle));
    }
}
