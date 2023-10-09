using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : GenericSingleton<LevelManager>
{
    public Transform PlayerTransform { get; set; }
    [SerializeField]
    PauseMenu pauseMenu;

    PauseMenu createdPause = null;
    Transform canvas;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>().transform;
    }

    bool isPaused = false;
    public void OnPausePressed()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0;
            createdPause = Instantiate<PauseMenu>(pauseMenu, canvas);
        }
        else
        {
            Time.timeScale = 1;
            Destroy(createdPause.gameObject);
        }
    }
}
