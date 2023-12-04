using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource walking, jump2, wind, shoot;

    public static SoundEffects sfxInstance;

    bool grounded;
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
            jump2.enabled = false;
        }
        else
        {
            walking.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump2.enabled = true;
        }
        else
        {
            jump2.enabled = false;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot.enabled = true;
        }
        else
        {
            shoot.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }

    }
}
