using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
			FindObjectOfType<AudioManager>().Play("GunShoot");
		}
	}

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
