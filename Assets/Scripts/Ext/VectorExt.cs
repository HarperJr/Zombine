using System;
using UnityEngine;

public static class VectorExt {

    public static bool HitOnPlane(this Ray ray, Vector3 normal, out Vector3 hit) {
        float denominator = Vector3.Dot(normal, ray.direction);
        if (Math.Abs(denominator) >= 0.0001f) {
            Vector3 difference = normal - ray.origin;
            float t = Vector3.Dot(difference, normal) / denominator;
            if (t > 0.0001f) {
                hit = ray.origin + (ray.direction * t) - normal;
                return true;
            }
        }

        hit = Vector3.zero;
        return false;
    }
}