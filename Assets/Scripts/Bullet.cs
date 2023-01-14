using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed = 20f;
	public Rigidbody2D rb;
	public int damage = 1;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		Asteroid asteroid = hitInfo.GetComponent<Asteroid>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			Destroy(gameObject);
		}
		if(asteroid != null)
        {
			asteroid.TakeDamage(damage);
			Destroy(gameObject);
        }
		
	}

}
