using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour
{
    public float detectionMargin;
    public float speed;

    private Vector3 top;
    private Vector3 right;

    // Start is called before the first frame update
    void Start()
    {
        top = (Vector3.right + Vector3.forward) / 2;
        right = (Vector3.right - Vector3.forward) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float mouseY = Input.mousePosition.y / Screen.height;
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float verticalMargin = detectionMargin / aspectRatio;
        float horizontalMargin = detectionMargin;
        Vector3 move = Vector3.zero;

        if (mouseX < horizontalMargin) // Left
        {
            move.x = -1;
        } else if (mouseX > 1 - horizontalMargin) // Right
        {
            move.x = 1;
        }

        if (mouseY < verticalMargin) // Bottom
        {
            move.z = -aspectRatio;
        }
        else if (mouseY > 1 - horizontalMargin) // Top
        {
            move.z = aspectRatio;
        }

        transform.position += (move.x * right + move.z * top) * speed;
    }

    private void OnDrawGizmosSelected()
    {
        Camera camera = GetComponent<Camera>();
        float verticalMargin = detectionMargin * Screen.height;
        float horizontalMargin = detectionMargin * Screen.width;
        Vector3 topLeft = camera.ScreenToWorldPoint(new Vector3(horizontalMargin, Screen.height - verticalMargin, 0));
        Vector3 topRight = camera.ScreenToWorldPoint(new Vector3(Screen.width - horizontalMargin, Screen.height - verticalMargin, 0));
        Vector3 bottomLeft = camera.ScreenToWorldPoint(new Vector3(horizontalMargin, verticalMargin, 0));
        Vector3 bottomRight = camera.ScreenToWorldPoint(new Vector3(Screen.width - horizontalMargin, verticalMargin, 0));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
