using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 previousCamPosition;
    private SpriteRenderer spriteRenderer;
    private float textureWidth;
    [SerializeField] private Vector2 parallaxCoefficient;
    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        previousCamPosition = cameraTransform.position;
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = new Vector2(spriteRenderer.size.x * 3, spriteRenderer.size.y);
        textureWidth = spriteRenderer.sprite.texture.width / spriteRenderer.sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        var positionDelta = cameraTransform.position - previousCamPosition;
        transform.position += new Vector3(positionDelta.x * parallaxCoefficient.x, positionDelta.y * parallaxCoefficient.y, 0);
        previousCamPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureWidth)
        {
            var offset = (cameraTransform.position.x - transform.position.x) % textureWidth;
            transform.position = new Vector3(cameraTransform.position.x + offset, transform.position.y);
        }
    }
}
