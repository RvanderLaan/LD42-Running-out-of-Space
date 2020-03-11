using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public float blinkTime = 1;

    // Use this for initialization
    void Start() {
        InvokeRepeating("ToggleActive", blinkTime, blinkTime);
    }

    // Update is called once per frame
    void Update() {

    }

    void ToggleActive() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
