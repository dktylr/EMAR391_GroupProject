using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBehavior : MonoBehaviour
{

    bool mouseDown = false;
    public Stats powerWireS;

    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        powerWireS = gameObject.GetComponent<Stats>();
        line = gameObject.GetComponentInParent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        line.SetPosition(0, new Vector3(gameObject.transform.localPosition.x - .5f, gameObject.transform.localPosition.y, 0));
        line.SetPosition(1, new Vector3(gameObject.transform.localPosition.x - 1f, gameObject.transform.localPosition.y, 0));

    }
    private void OnMouseDown()
    {
        mouseDown = true;
    } 

    private void OnMouseOver()
    {
        powerWireS.movable = true;
    }

    private void OnMouseExit()
    {
        if (!powerWireS.moving)
            powerWireS.movable = false;
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        if (!powerWireS.connected)
            gameObject.transform.position = powerWireS.startPosition;
        if (powerWireS.connected)
            gameObject.transform.position = powerWireS.connectedPosition;
    }

    private void MoveWire()
    {
        if (mouseDown && powerWireS.movable)
        {
            powerWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1));
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.parent.transform.position.z);
        }
        else
            powerWireS.moving = false;

    }
}
