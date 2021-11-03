using UnityEngine;

public static class TransformExt {

    public static void Move(this Transform transform, Vector3 delta, float time) {
        Vector3 lastPosition = transform.position;
        transform.MoveTo(lastPosition + delta, time);
    }
    
    public static void MoveTo(this Transform transform, Vector3 position, float time) {
        transform.position = Vector3.Slerp(transform.position, position, time);
    }

    public static Vector3 CoarseIn(this Vector3 vec, Vector3 direction, Vector3 up) {
        Vector3 forward = Vector3.ProjectOnPlane(direction, up);
        Vector3 horizontal = Vector3.Cross(up, forward) * vec.x;
        Vector3 vertical = forward * vec.z;
        return (horizontal + vertical).normalized;
    }
}
