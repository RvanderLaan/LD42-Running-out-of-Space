using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    public int boostDistance = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            ShipController ship = collider.GetComponent <ShipController > ();
            ship.StartCoroutine(ship.Boost(boostDistance));
        }
    }
}
