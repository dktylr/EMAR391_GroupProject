using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private Text endScoreUI;
    public GameManager manager;
    public GameObject managerObject;

    void Start()
    {
        endScoreUI = this.gameObject.GetComponent<Text>();
        managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<GameManager>();
    }

    void Update()
    {
        endScoreUI.text = "Your Nanobot defeated " + manager.score + " viruses!";
    }
}
