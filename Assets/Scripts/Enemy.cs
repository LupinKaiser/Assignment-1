using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private bool movingRight = true;
	public int health = 1;
	public float speed = 1f;

	public GameObject deathEffect;
	public Transform groundDetection;

    public void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
		if(groundInfo.collider == false)
        {
			if(movingRight == true)
            {
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;
            }
            else
            {
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;
			}
        }
    }

    public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
