using UnityEngine;

public static class TransformExt {

    public static void Move(this Transform transform, Vector3 delta, float time) {
        Vector3 lastPosition = transform.position;
        transform.position = lastPosition + delta * time;
    }
}
