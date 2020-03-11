using UnityEngine;
using UnityEngine.Playables;

public class TimelineEndActivator : MonoBehaviour {
    public PlayableDirector director;

    public GameObject activate;

    void OnEnable() {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector) {
        if (director == aDirector) {
            activate.SetActive(true);
        }
    }

    void OnDisable() {
        director.stopped -= OnPlayableDirectorStopped;
    }
}