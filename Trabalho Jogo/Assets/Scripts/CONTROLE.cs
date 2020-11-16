using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CONTROLE : MonoBehaviour
{
    Vector3 direção;
    public float velocidade;
    Rigidbody rb;
    Renderer cor;

    bool jabati = false;
    float tempocor = 0;
    public float tempoCorLimite = 1f;


    public Material Verde;
    public Material Amarelo;
    public Material Cubobase;
    public Material Marrom;


    public float speedH = 2.0f;
    
    private float yaw = 0.0f;
   






    public float maxAltura;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cor = GetComponent<Renderer>();
    }


    void Update()
    {
        if (jabati)
        {
            tempocor += Time.deltaTime;
            if (tempocor > tempoCorLimite)
            {
                MudaCor(Cubobase);
                tempocor = 0;
            }
        }

        float pulo = 0;
        if ((Input.GetKey(KeyCode.Space)) && (rb.position.y < maxAltura))
        {
            pulo = 2;
        }

        direção = new Vector3(Input.GetAxis("Horizontal"), pulo, Input.GetAxis("Vertical"));
        transform.Translate(direção * velocidade * Time.deltaTime);

        yaw += speedH * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
    private void OnTriggerEnter(Collider other)
    {   

        if (other.tag == "Finish")
        {
            Vitoria();
        }
        if (other.GetComponent<Amarelo>() == true)
        {

            Morre();

        }

        if (other.GetComponent<Verde>() == true)
        {
            if (jabati)
            {
                Morre();
            }


            else
            {
                MudaCor(Verde);

            }



        }
        else if (other.GetComponent<Marrom>() == true)
        {
           
            
                Destroy(other.gameObject);
              
            
            

        }


        



    }


    private void Morre()
    {
        cor.enabled = false;
        Time.timeScale = 0;
    }

    private void MudaCor(Material material)
    {
        cor.material = material;
        if (material == Verde)
        {
            jabati = true;
        }
        else
        {
            jabati = false;
        }

    }

    private void Vitoria()
    {
        Destroy(gameObject);
    }
}
    
