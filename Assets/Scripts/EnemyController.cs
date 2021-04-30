using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	private int contador = 0;

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.layer == 10)
		{
			if (contador == 4)
				Destroy(this.gameObject);
			else
				contador++;
		}

		if (other.gameObject.layer == 11)
		{
			if (contador == 1)
				Destroy(this.gameObject);
			else
				contador++;
		}

		if (other.gameObject.layer == 12)
		{
			Destroy(this.gameObject);

		}
	}
}
