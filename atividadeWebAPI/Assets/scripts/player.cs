using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float jumpForce = 10f; 
    private Rigidbody2D rb;
    private bool isGrounded;
    private int vida;
    private int itensColetados;
    [SerializeField] private GameObject autoSave;
    [SerializeField] private GameObject telaMorte;
    [SerializeField] private TesteAPI teste;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vida = 5;

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 direcao = new Vector2(horizontal, vertical);
        rb.linearVelocity = direcao.normalized;
        this.GetComponent<Rigidbody2D>().linearVelocity = direcao * this.moveSpeed;

    }

    public void ReceberDano()
    {
        this.vida--;
    }

    public void Coletados()
    {
        this.itensColetados++;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Dano"))
        {
            itemDano Dano = collider.GetComponent<itemDano>();
            ReceberDano();
            if (vida<=0)
            {
                telaMorte.SetActive(true);
                Time.timeScale = 0f;
            }

        }
        if (collider.CompareTag("Colecionavel"))
        {
            itemColecionavel Colecao = collider.GetComponent<itemColecionavel>();
            Coletados();
            AutoSave();
            teste.Coletou();
        }

    }

    public int GetVida()
    {
        return vida;
    }

    public int GetItens()
    {
        return itensColetados;
    }



    public void AutoSave()
    {
        StartCoroutine(Salvando());
    }

    private IEnumerator Salvando()
    {
        autoSave.SetActive(true);
        yield return new WaitForSeconds(2f);
        autoSave.SetActive(false);
    }
}
