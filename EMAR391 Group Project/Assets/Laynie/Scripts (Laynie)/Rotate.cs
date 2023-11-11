using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public AudioSource spin;
    private Rect audiorect;

    // Start is called before the first frame update

    private void Start()
    {
        audiorect = new Rect(20, 20, 100, 20);
    }
    private void OnMouseDown()
    {
        if (!GameControl.youWin)
            transform.Rotate(0f, 0f, 90f);

            if (Input.GetMouseButtonDown(0))
            {
                spin.Play();
            }
        }
    }