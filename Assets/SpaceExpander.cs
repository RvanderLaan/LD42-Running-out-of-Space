using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceExpander : MonoBehaviour {

    public float rotSpeed = 1;
    private float angle = 0;

    public GameObject[] enableOnWin;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        angle += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            GameObject.Find("VoidWrapper").GetComponent<Void>().enabled = false;
            foreach (GameObject go in enableOnWin) {
                go.SetActive(true);
            }
        }
    }
}
