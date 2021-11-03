using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Player : MonoBehaviour, IInputEventListener {
    [SerializeField] private InputEventProvider _inputEventProvider;
    [SerializeField] private PlayerCamera _camera;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Movable _movable;

    private Vector3 _movementDirection = Vector3.zero;
    
    private void Start() { }

    private void Update() {
        _movable.Move(_movementDirection, Time.deltaTime * _movementSpeed);
    }

    private void OnEnable() {
        _inputEventProvider.AddListener(this);
    }

    private void OnDisable() {
        _inputEventProvider.RemoveListener(this);
    }

    public void OnMove(Vector2 position) {
        _movementDirection = _camera.CoarseDirection(position);
    }

    public void OnRightClick(Vector2 position) {
        Debug.Log("OnRightClick");
    }

    public void OnLeftClick(Vector2 position) {
        Debug.Log("OnLeftClick");
    }

    public void OnPoint(Vector2 position) {
        Vector3 worldPosition = _camera.GetWorldPosition(position);
        if (worldPosition != Vector3.zero) {
            _movable.LookAt(worldPosition);
        }
    }
}