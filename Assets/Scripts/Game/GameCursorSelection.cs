using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursorSelection : MonoBehaviour
{
    public GameObject selected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            if (Physics.Raycast(ray, out rh, Camera.main.farClipPlane))
            {
                selected = rh.collider.gameObject;
            }
        }
    }
}
