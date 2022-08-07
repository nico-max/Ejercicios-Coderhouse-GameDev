using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    void Awake()
    {
        if (GameManager._instance == null)
        {
            DontDestroyOnLoad(gameObject);
            GameManager._instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void salir()
    {
        Application.Quit();
    }
}
