using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public GameObject[] enable;
    public GameObject[] disable;
    public float timer = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGameWithAnim() {
        foreach (GameObject go in enable) {
            go.SetActive(true);
        }
        foreach (GameObject go in disable) {
            go.SetActive(false);
        }
        Invoke("LoadGame", timer);
    }

    public void LoadGame() {
        SceneManager.LoadScene("Attempt2");
    }
}
