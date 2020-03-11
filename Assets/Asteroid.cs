using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public float maxAngularVelocity = 1;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().angularVelocity = Random.value * maxAngularVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            ShipController ship = collider.GetComponent<ShipController>();

            Debug.Log("OUCH");
            ship.Die();

            Vector2 shipCrashVelocity = new Vector2(Random.value - 0.5f, Random.value - 0.5f);
            float shipCrashAngularVelocity = Random.value * 10;
            ship.GetComponent<Rigidbody2D>().angularVelocity = shipCrashAngularVelocity;
            ship.GetComponent<Rigidbody2D>().velocity = shipCrashVelocity;

            GetComponent<Rigidbody2D>().angularVelocity = -shipCrashAngularVelocity;
            GetComponent<Rigidbody2D>().velocity = -shipCrashVelocity;
        }
    }
}
