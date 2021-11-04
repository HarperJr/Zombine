using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public Vector3 RightAxis { get;  private set; }
    [SerializeField] private Camera _camera;
    
    private void Start() {
        RightAxis = transform.right;
    }

    public bool Raycast(Vector2 position, out Vector3 hit) {
        Ray ray = _camera.ScreenPointToRay(position);
        return ray.Raycast(Vector3.up, out hit);
    }
}