using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanPlayer : MonoBehaviour
{
	private SpriteRenderer sr;
	private Animator _animator;
	private Rigidbody2D rb2d;

	public float speed = 5;
	public float upSpeed = 25;
	private bool puedoSaltar = true;
	private int contadorSaltos = 0;


	//recarga
	private bool recargar = false;

	public GameObject balaPequeña;
	public GameObject balaGrande;
	public GameObject balaExtraGrande;

	void Start()
	{

		sr = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update()
	{
		setQuietoAnimation();


		if (Input.GetKey(KeyCode.RightArrow))
		{
			sr.flipX = false;
			setCorrerAnimation();
			rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			sr.flipX = true;
			setCorrerAnimation();
			rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
		}

		//Correr Disparando
		if (Input.GetKey(KeyCode.C))
		{
			if (!sr.flipX)
			{
				setCorrerDisparoAnimation();

				rb2d.velocity = new Vector2(speed * 1.2f, rb2d.velocity.y);

			}
			else
			{
				setCorrerDisparoAnimation();

				rb2d.velocity = new Vector2(-speed * 1.2f, rb2d.velocity.y);
			}
		}

		//Saltar
		if (Input.GetKeyDown(KeyCode.Space))
		{

			if (puedoSaltar == true)
			{
				puedoSaltar = true; rb2d.velocity = Vector2.up * upSpeed; setSaltarAnimation();

			}

		}



		//Disparar
		if (Input.GetKeyDown(KeyCode.X))
		{

			var position = new Vector2(transform.position.x + 1, transform.position.y);
			Instantiate(balaPequeña, position, balaPequeña.transform.rotation);

		}





		//Recarga 3
		if (Input.GetKeyDown(KeyCode.Q) && recargar == false)
		{
			Recarga();
			recargar = true;

			if (recargar == true)
			{
				Invoke("AnularRecarga3", 3.0f);
			}

		}

		//Recarga 5
		if (Input.GetKeyDown(KeyCode.Z) && recargar == false)
		{
			Recarga();
			recargar = true;

			if (recargar == true)
			{
				Invoke("AnularRecarga5", 5.0f);
			}

		}



	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == 3)
		{
			puedoSaltar = true;
		}
	}


	private void Recarga()
	{
		sr.color = Color.blue;

	}

	private void AnularRecarga3()
	{
		sr.color = Color.white;
		var position = new Vector2(transform.position.x + 1, transform.position.y);
		Instantiate(balaGrande, position, balaGrande.transform.rotation);
		setBallaBrandeDisparoAnimation();
	}


	private void AnularRecarga5()
	{
		sr.color = Color.white;
		var position = new Vector2(transform.position.x + 1, transform.position.y);
		Instantiate(balaExtraGrande, position, balaExtraGrande.transform.rotation);
		setBallaExtraBrandeDisparoAnimation();
	}



	private void setQuietoAnimation()
	{
		_animator.SetInteger("Estado", 0);
	}

	private void setCorrerAnimation()
	{
		_animator.SetInteger("Estado", 1);
	}

	private void setSaltarAnimation()
	{
		_animator.SetInteger("Estado", 2);
	}

	private void setCorrerDisparoAnimation()
	{
		_animator.SetInteger("Estado", 3);
	}

	private void setBallaBrandeDisparoAnimation()
	{
		_animator.SetInteger("Bala", 0);
	}

	private void setBallaExtraBrandeDisparoAnimation()
	{
		_animator.SetInteger("Bala", 1);
	}


}
