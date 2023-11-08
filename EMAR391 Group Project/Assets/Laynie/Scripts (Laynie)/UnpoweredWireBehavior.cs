using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoweredWireBehavior : MonoBehaviour
{
    UnpoweredWireStat unpoweredWireS;
    // Start is called before the first frame update
    void Start()
    {
        unpoweredWireS = gameObject.GetComponent<UnpoweredWireStat>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageLight();
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
        }
        else
        {
            unpoweredWireS.poweredLight.SetActive(false);
            unpoweredWireS.unpoweredLight.SetActive(true);
        }
    }
}