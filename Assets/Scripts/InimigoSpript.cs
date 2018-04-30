using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSpript : MonoBehaviour {
    public float interval;
    public float velocidadeMorte;
    public float movespeed;
    public float direcao;
    public GameObject inimigosPrefab;
    public Transform geradorPeixes;

    // Use this for initialization
    IEnumerator Start()
    {
        Instantiate(inimigosPrefab,
            geradorPeixes.transform.position,
            geradorPeixes.transform.rotation);

        yield return new WaitForSeconds(interval);
        StartCoroutine(Start());
    }


    void OnCollisionEnter2D(Collision2D c)
    {

        print(c);
        if (c.gameObject.tag == "Player")
        {
            float mover_y =   velocidadeMorte * Time.deltaTime;
            transform.Translate(0.0f, mover_y, 0.0f);
               
            
        }

        if (c.gameObject.tag == "Chao")
        {
            Destroy(gameObject);
        }

        if (c.gameObject.tag == "Direita")
        {
            direcao = -1;
        }
        if (c.gameObject.tag == "Esquerda")
        {
            direcao = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float mover_x = direcao * movespeed * Time.deltaTime;
        transform.Translate(mover_x, 0.0f, 0.0f);
    }
}
