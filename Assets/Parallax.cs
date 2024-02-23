using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform;
        public float scrollSpeed;
    }

    public ParallaxLayer[] layers;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
    }

    private void Update()
    {
        float deltaMovementX = cameraTransform.position.x - previousCameraPosition.x;

        foreach (ParallaxLayer layer in layers)
        {
            float parallaxX = deltaMovementX * layer.scrollSpeed;

            Vector3 newPosition = layer.layerTransform.position + new Vector3(parallaxX, 0f, 0f);

            layer.layerTransform.position = newPosition;
        }

        previousCameraPosition = cameraTransform.position;
    }
}