using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    static KeyCode KEY_UP = KeyCode.UpArrow;
    static KeyCode KEY_DOWN = KeyCode.DownArrow;
    static KeyCode KEY_LEFT = KeyCode.LeftArrow;
    static KeyCode KEY_RIGHT = KeyCode.RightArrow;

    public KeyCode lastKey = KEY_RIGHT;
    public float moveTime = 1;
    public float rotateSpeed = 1;
    public float boostSpeed = 2;

    public AnimationCurve boostCurve;
    private bool boosting = false;

    public GameObject[] enableOnDeath;

    // Use this for initialization
    void Start () {
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
        InvokeRepeating("Move", moveTime, moveTime);
    }

    void Update() {
        if (Input.GetKeyDown(KEY_UP)) {
            lastKey = KEY_UP;
            StartCoroutine(Rotate(90));
        }
        if (Input.GetKeyDown(KEY_DOWN)) {
            lastKey = KEY_DOWN;
            StartCoroutine(Rotate(270));
        }
        if (Input.GetKeyDown(KEY_LEFT)) {
            lastKey = KEY_LEFT;
            StartCoroutine(Rotate(180));
        }
        if (Input.GetKeyDown(KEY_RIGHT)) {
            lastKey = KEY_RIGHT;
            StartCoroutine(Rotate(0));
        }
    }

    IEnumerator Rotate(float angle) {
        StopCoroutine("Rotate");
        Quaternion oldRot = transform.rotation;
        Quaternion newRot = Quaternion.Euler(new Vector3(0, 0, angle));
        for (float t = 0.0f; t < 1.0; t += Time.deltaTime * rotateSpeed) {
            transform.rotation = Quaternion.Slerp(oldRot, newRot, t);
            yield return null;
        }
        transform.rotation = newRot;
    }

    void Move () {
        Vector3 newPos = transform.position;
        if (lastKey == (KEY_UP)) {
            newPos.y += 1;
        }
        if (lastKey == (KEY_DOWN)) {
            newPos.y -= 1;
        }
        if (lastKey == (KEY_LEFT)) {
            newPos.x -= 1;
        }
        if (lastKey == (KEY_RIGHT)) {
            newPos.x += 1;
        }
        transform.position = newPos;
    }


    public IEnumerator Boost(int distance) {
        if (!boosting) {
            boosting = true;
            Vector3 oldPos = transform.position;
            Vector3 newPos = new Vector3(oldPos.x + distance, oldPos.y, oldPos.z);
            for (float t = 0.0f; t < 1.0; t += Time.deltaTime * boostSpeed) {
                float curveT = boostCurve.Evaluate(t);
                transform.position = Vector3.Slerp(oldPos, newPos, curveT);
                yield return null;
            }
            transform.position = newPos;
            boosting = false;
        }
    }

    public void Die() {
        CancelInvoke("Move");
        foreach (GameObject go in enableOnDeath) {
            go.SetActive(true);
        }
    }
}
