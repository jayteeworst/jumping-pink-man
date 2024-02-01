using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform;
        public float scrollSpeed;
        public bool verticalParallax;
        public float verticalParallaxRange = 0.1f;
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
        float deltaMovementY = cameraTransform.position.y - previousCameraPosition.y;

        foreach (ParallaxLayer layer in layers)
        {
            float parallaxX = deltaMovementX * layer.scrollSpeed;
            float parallaxY = deltaMovementY;

            Vector3 newPosition = layer.layerTransform.position + new Vector3(parallaxX, parallaxY, 0f);

            // Clamping the vertical parallax within the specified range
            if (layer.verticalParallax)
            {
                newPosition.y = Mathf.Clamp(newPosition.y, layer.layerTransform.position.y - layer.verticalParallaxRange, layer.layerTransform.position.y + layer.verticalParallaxRange);
            }

            layer.layerTransform.position = newPosition;
        }

        previousCameraPosition = cameraTransform.position;
    }
}