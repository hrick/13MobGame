using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Animator animator;

    public float velocidade;
	public float impulso;

	public Transform chaoVerificador;
	bool estaoNoChao;

	SpriteRenderer spriteRender;
	Rigidbody2D rb;

	void Start () {
        animator = GetComponent<Animator>();
        // Interface para os componentes
        spriteRender = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		
		// Mover
		float mover_x = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
        print(Input.GetAxisRaw("Horizontal"));
        transform.Translate (mover_x, 0.0f, 0.0f);

		// Verificar colisao com o piso
		estaoNoChao = Physics2D.Linecast(transform.position, 
			chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));


        animator.SetFloat("run", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        // Pulo
        if (Input.GetButtonDown ("Jump") && estaoNoChao) {
			rb.velocity = new Vector2 (0.0f, impulso);
            animator.SetBool("pular", true);

        } else
        {
            animator.SetBool("pular", false);
        }
		// Orientacao
		if (mover_x > 0) {
			spriteRender.flipX = true; 
		} else if (mover_x < 0) {
			spriteRender.flipX = false; 
		}			


	
	}
    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag == "PisoInimigo")
        {
            Destroy(gameObject);
        }

    }
}
