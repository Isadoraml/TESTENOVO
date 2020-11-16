using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public string nomeDacena;

    public void ChangeS() 
     {
          SceneManager.LoadScene(nomeDacena);
      }

    

    public void Sair()
    {
        Application.Quit();
    }
}