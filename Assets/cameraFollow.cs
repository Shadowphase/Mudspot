using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.5f;
    public Vector3 offset;

    public float zoomScale;

    [SerializeField]
    private float minZoom = 5f;
    [SerializeField]
    private float maxZoom = 15f;

    private float currZoom;

	// Use this for initialization
	void Start () {
        currZoom = Camera.main.orthographicSize;
	}

	// Update is called once per frame
	void Update () {
        if(Input.mouseScrollDelta.y != 0)
        {
            Zoom(Input.mouseScrollDelta.y);
        }
    }

    void LateUpdate () {
        transform.position = target.position + offset;
    }

    void Zoom(float scrollDelta) {
        currZoom -= scrollDelta * zoomScale;

        if (currZoom < minZoom)
        {
            currZoom = minZoom;
        }

        if (currZoom > maxZoom)
        {
            currZoom = maxZoom;
        }

        Camera.main.orthographicSize = currZoom;
    }
}
