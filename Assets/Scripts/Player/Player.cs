using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Player : MonoBehaviour, IInputEventListener {
    [SerializeField] private InputEventProvider _inputEventProvider;
    [SerializeField] private PlayerCamera _camera;
    [SerializeField] private Movable _movable;
    [SerializeField] private float _movementSpeed;

    private Vector2 _inputDirection = Vector2.zero;
    private Vector3 _pointPosition = Vector2.zero;

    private void Start() {
       
    }

    private void Update() {
        if (_inputDirection != Vector2.zero) {
            MovePlayer(_inputDirection);
        }
        _movable.LookAt(_pointPosition);
    }

    private void MovePlayer(Vector2 inputDirection) {
        Vector3 horizontal = new Vector3(_camera.RightAxis.x * inputDirection.x, 0f, _camera.RightAxis.y * inputDirection.x);
        Vector3 direction = new Vector3(horizontal.x, 0f, inputDirection.y + horizontal.z).normalized;
        _movable.Move(direction, Time.deltaTime * _movementSpeed);
    }

    private void OnEnable() {
        _inputEventProvider.AddListener(this);
    }

    private void OnDisable() {
        _inputEventProvider.RemoveListener(this);
    }

    public void OnMove(Vector2 position) {
        _inputDirection = position;
    }

    public void OnRightClick(Vector2 position) { }

    public void OnLeftClick(Vector2 position) { }

    public void OnPoint(Vector2 position) {
        if (_camera.Raycast(position, out Vector3 hit)) {
            _pointPosition = hit;
        }
    }
}