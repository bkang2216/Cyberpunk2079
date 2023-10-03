using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource walking;

    public AudioClip Click;

    public static SoundEffects sfxInstance;


    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            walking.enabled = true;
        }
        else
        {
            walking.enabled = false;
        }
    }
}
