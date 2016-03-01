using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput3D : MonoBehaviour
{
    private List<GameObject> touchList = new List<GameObject>();
    private RaycastHit hit;

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(screenRay.origin, screenRay.direction, out hit))
            {
                GameObject recipient = hit.transform.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                Debug.Log ("test " + recipient.name);
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
            }
        }
    }
}
