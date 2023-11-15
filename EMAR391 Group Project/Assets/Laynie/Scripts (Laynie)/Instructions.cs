using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    private void Start()
    {
        instructionsPanel.SetActive(false);

    }
    public GameObject instructionsPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInstructions();
        }
    }

    public void ToggleInstructions()
    {
        if (!instructionsPanel.activeSelf)
        {
            instructionsPanel.SetActive(true);
        }
        else
        {
            instructionsPanel.SetActive(false);
        }
    }
}
