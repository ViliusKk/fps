using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bulletPrefab;
    
    public float cooldown = 0.3f;
    public float reload = 2;

    public int magazineCapasity = 2;
    private int currentAmmo = 0;
    
    private bool canShoot = true;

    private void Start()
    {
        currentAmmo = magazineCapasity;
    }

    void Update()
    {
        if (currentAmmo > 0 && canShoot && Input.GetMouseButtonDown(0))
        {
            currentAmmo--;
            var bullet = Instantiate(bulletPrefab, muzzle.position, transform.rotation);
            
            var screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out var hit))
            {
                bullet.transform.LookAt(hit.point);
            }
            
            StartCoroutine(Cooldown());
        }
        else if (currentAmmo == 0 && canShoot && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Reload());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        canShoot = false;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        yield return new WaitForSeconds(reload);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        currentAmmo = magazineCapasity;
        canShoot = true;
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
