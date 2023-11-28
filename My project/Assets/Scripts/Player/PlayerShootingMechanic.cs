using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingMechanic : MonoBehaviour
{

    [Header("Projectile GameObjects")]
    public GameObject normalProjectile;
    public GameObject chargedProjectile;
    public GameObject projectileOrigin;

    [Header("Projectile Charging GUI Variables")]
    public int chargeTime;
    [SerializeField] Slider slider;
    [SerializeField] Image progressBar;

    int charge;
    Animator animator;
    Coroutine animatorFunction;

    void Awake()
    {
        animator = GetComponent<Animator>();
        slider.maxValue = chargeTime;
        progressBar.color = Color.red;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ++charge;
            slider.value = charge;

            if (charge >= chargeTime)
            {
                progressBar.color = Color.blue;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
            if (animatorFunction != null)
            {
                StopCoroutine(animatorFunction);
            }
            
            animator.SetBool("isShooting", true);
            animatorFunction = StartCoroutine(AnimationTimer(1));

            if (charge >= chargeTime)
            {
                ShootChargedProjectile();
            }
            else
            {
                ShootNormalProjectile();
            }
            
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
}
