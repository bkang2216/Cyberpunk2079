using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMechanic : MonoBehaviour
{
    public GameObject normalProjectile;
    public GameObject chargedProjectile;
    public GameObject projectileOrigin;

    float time = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            ++time;
            Debug.Log(time);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (time >= 500)
            {
                ShootChargedProjectile();
            }
            else
            {
                ShootNormalProjectile();
            }
            time = 0;
        }
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
