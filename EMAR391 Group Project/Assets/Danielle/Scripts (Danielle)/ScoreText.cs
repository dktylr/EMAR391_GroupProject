using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private Text scoreUI;
    public GameManager manager;
    public GameObject managerObject;

    void Start()
    {
        scoreUI = this.gameObject.GetComponent<Text>();
        managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<GameManager>();
    }

    void Update()
    {
        scoreUI.text = "score: " + manager.score;
    }
}
