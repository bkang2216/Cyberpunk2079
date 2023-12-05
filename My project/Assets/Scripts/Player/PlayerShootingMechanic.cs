using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingMechanic : MonoBehaviour
{
    Animator animator;
    int charge;
    Coroutine animatorFunction;

    public AudioSource Charged;
    [Header("Projectile GameObjects")]
    public GameObject normalProjectile;
    public GameObject chargedProjectile;
    public GameObject projectileOrigin;

    [Header("Projectile Charging GUI Variables")]
    public int chargeTime;
    [SerializeField] Slider slider;
    [SerializeField] Image progressBar;
    void Awake()
    {
        animator = GetComponent<Animator>();
        slider.maxValue = chargeTime;
        progressBar.color = Color.red;
        Charged = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // Logic for shooting: Clicking shoots a normal projectile, hold and release shoots a charged projectile
        {
            ++charge; // Adds a charge per Update()
            slider.value = charge; // Syncs the charge UI display to variable

            if (charge >= chargeTime) 
            {
                progressBar.color = Color.blue; // Changes charge UI display to blue if the time for the charge is completed
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0)) // This part of the statement performs a task based on the duration of mouse left click
        {
            
            if (animatorFunction != null)
            {
                StopCoroutine(animatorFunction);
            }
            
            // Sets the animation to shooting if idle and reverts back to idle if not shooting after a second
            animator.SetBool("isShooting", true);
            animatorFunction = StartCoroutine(AnimationTimer(1));

            if (charge >= chargeTime) // Logic for calling the appropriate function for shooting a projectile
            {
                ShootChargedProjectile();
                Charged.Play();
            }
            else
            {
                ShootNormalProjectile();
            }

            //Resets the variables associated with charging
            charge = 0;
            slider.value = charge;
            progressBar.color = Color.red;
        }
    }

    IEnumerator AnimationTimer(int val)
    {
        yield return new WaitForSeconds(val);
        animator.SetBool("isShooting", false);
    }

    void ShootNormalProjectile()
    {
        Instantiate(normalProjectile, projectileOrigin.transform.position, transform.rotation);
    }

    void ShootChargedProjectile()
    {
        Instantiate(chargedProjectile, projectileOrigin.transform.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(projectileOrigin.transform.position, new(0.5f, 0.5f, 0)); // Adds a visible gizmo for the origin point of player projectile
    }
}
