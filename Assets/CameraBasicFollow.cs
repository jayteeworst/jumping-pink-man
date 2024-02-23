using UnityEngine;

public class CameraBasicFollow : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToFollow;

    private void Update()
    {
        transform.position = new Vector3(_gameObjectToFollow.transform.position.x, _gameObjectToFollow.transform.position.y + 1f, transform.position.z);
    }
}
