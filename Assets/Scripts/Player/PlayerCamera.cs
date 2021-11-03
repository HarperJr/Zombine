using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    [SerializeField] private Camera _camera;

    public Vector3 GetWorldPosition(Vector2 position) {
        Ray ray = _camera.ScreenPointToRay(position);
        var isPlaneIntersected = ray.HitOnPlane(Vector3.up, out Vector3 hit);
        return isPlaneIntersected ? hit : Vector3.zero;
    }

    public Vector3 CoarseDirection(Vector2 position) {
        Vector3 worldDirection = new Vector3(position.x, 0f, position.y);
        return worldDirection.CoarseIn(_camera.transform.forward, Vector3.up);
    }
}