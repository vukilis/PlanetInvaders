using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour {

    public AudioSource music;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    //Play Global
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update () {
		
	}
}
