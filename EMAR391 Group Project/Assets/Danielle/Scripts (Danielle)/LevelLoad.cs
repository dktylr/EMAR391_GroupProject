using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    string currentScene = "";
    public GameManager manager;
    public GameObject managerObject;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<GameManager>();
        Debug.Log(currentScene);
    }
    public void Builder(string scene)
    {
        SceneManager.LoadScene("NanobotBuilder");
    }
    public void Start(string scene)
    {
        SceneManager.LoadScene("StartScreen");
        Destroy(manager.gameObject);
    }

    public void Charger(string scene)
    {
        SceneManager.LoadScene("NanobotCharger");
    }

    public void Attack(string scene)
    {
        SceneManager.LoadScene("NanobotAttack");
    }

    public void Instruction(string scene)
    {
        SceneManager.LoadScene("Instructions");
    }

    public void End(string scene)
    {
        SceneManager.LoadScene("EndScreen");
    }
}