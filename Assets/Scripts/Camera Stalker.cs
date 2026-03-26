using UnityEngine;

public class CameraStalker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothCameraSpeed = 5f;

    [SerializeField] private Vector2 _leftBound;
    [SerializeField] private Vector2 _rightBound;

    private float _camHalfWidth;
    private float _camHalfHeight;

    private void Start()
    {
        Camera camera = GetComponent<Camera>();

        _camHalfHeight = camera.orthographicSize;
        _camHalfWidth = camera.aspect * _camHalfHeight;
    }
    private void LateUpdate()
    {
        if(_target == null) return;

        Vector3 currentPosition = transform.position;

        float targetX = _target.position.x;

        float smoothX = Mathf.Lerp(currentPosition.x, targetX, _smoothCameraSpeed * Time.deltaTime);

        transform.position = new Vector3(smoothX,currentPosition.y,currentPosition.z);
    }
}
