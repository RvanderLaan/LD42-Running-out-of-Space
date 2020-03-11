using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour {

    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.x += Time.deltaTime * speed;
        transform.position = newPos;
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            ShipController ship = collider.GetComponent<ShipController>();
            ship.StartCoroutine(ship.Boost(-10));
            Debug.Log("YOU DEAD");
            ship.Die();
        }
    }
}
