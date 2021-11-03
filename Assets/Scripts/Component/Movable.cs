using UnityEngine;

public class Movable : MonoBehaviour {
    private Transform _transform;

    private void Start() {
        _transform = transform;
    }

    public void MoveTo(Vector3 position, float time) {
        _transform.MoveTo(position, time);
    }

    public void Move(Vector3 delta, float time) {
        _transform.Move(delta, time);
    }

    public void LookAt(Vector3 position) {
        _transform.LookAt(position);
    }
}
