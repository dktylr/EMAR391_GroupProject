using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    string currentScene = "";

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
    }
    public void Builder(string scene)
    {
        SceneManager.LoadScene("NanobotBuilder");
    }
    public void Start(string scene)
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Charger(string scene)
    {
        SceneManager.LoadScene("NanobotCharger");
    }

    public void Attack(string scene)
    {
        SceneManager.LoadScene("NanobotAttack");
    }
}