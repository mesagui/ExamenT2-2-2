using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExtraGrandeController : MonoBehaviour
{
	// Start is called before the first frame update

	public float velocityX = 10f;
	private Rigidbody2D rb;
	private MegamanPlayer redBoyPlayerController;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		redBoyPlayerController = FindObjectOfType<MegamanPlayer>();
		Destroy(gameObject, 2f);// personaje lanza bala y se destruye despues de 3
	}

	// Update is called once per frame
	void Update()
	{
		rb.velocity = Vector2.right * velocityX;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Enemy")
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}
}
