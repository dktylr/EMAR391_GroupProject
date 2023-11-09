using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnpoweredWireBehavior : MonoBehaviour
{
    UnpoweredWireStat unpoweredWireS;
    Stats stats;
    public GameObject levelCompleteUI;
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    public GameObject blueLight;
    public bool redConnected = false;
    public bool yellowConnected = false;
    public bool greenConnected = false;
    public bool blueConnected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        unpoweredWireS = gameObject.GetComponent<UnpoweredWireStat>();
        stats = gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageLight();
        if (redLight.activeSelf == true)
        {
            redConnected = true;
        }
        if (yellowLight.activeSelf == true)
        {
            yellowConnected = true;
        }
        if (greenLight.activeSelf == true)
        {
            greenConnected = true;
        }
        if (blueLight.activeSelf == true)
        {
            blueConnected = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Stats>())
        {
            Stats poweredWireS = collision.GetComponent<Stats>();
            if (poweredWireS.objectColor == unpoweredWireS.objectColor)
            {
                poweredWireS.connected = true;
                unpoweredWireS.connected = true;
                poweredWireS.connectedPosition = gameObject.transform.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Stats>())
        {
            Stats poweredWireS = collision.GetComponent<Stats>();
            if (!poweredWireS)
            {
                poweredWireS.connected = false;
                unpoweredWireS.connected = false;
            }
        }
    }
    void ManageLight()
    {
        if (unpoweredWireS.connected)
        {
            unpoweredWireS.poweredLight.SetActive(true);
            unpoweredWireS.unpoweredLight.SetActive(false);
      

            if (redConnected == true && yellowConnected == true && greenConnected == true && blueConnected == true) 
            { 
                levelCompleteUI.SetActive(true);
            }

        }
        else
        {
            unpoweredWireS.poweredLight.SetActive(false);
            unpoweredWireS.unpoweredLight.SetActive(true);
            levelCompleteUI.SetActive(false);
        }

    }
}