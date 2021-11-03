using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputEventProvider : MonoBehaviour {
    private readonly List<IInputEventListener> _listeners = new List<IInputEventListener>();
    private Vector2 _lastMousePosition;

    public void OnLeftClick(InputAction.CallbackContext context) {
        _listeners.ForEach(_listener => _listener.OnLeftClick(_lastMousePosition));
    }

    public void OnRightClick(InputAction.CallbackContext context) {
        _listeners.ForEach(_listener => _listener.OnRightClick(_lastMousePosition));
    }

    public void OnPoint(InputAction.CallbackContext context) {
        _lastMousePosition = context.ReadValue<Vector2>();
        _listeners.ForEach(_listener => _listener.OnPoint(_lastMousePosition));
    }

    public void OnMove(InputAction.CallbackContext context) {
        Vector2 position = context.ReadValue<Vector2>();
        _listeners.ForEach(_listener => _listener.OnMove(position));
    }

    public void AddListener(IInputEventListener listener) {
        _listeners.Add(listener);
    }

    public void RemoveListener(IInputEventListener listener) {
        _listeners.Remove(listener);
    }
}

public interface IInputEventListener {

    public void OnMove(Vector2 position);

    public void OnRightClick(Vector2 position);

    public void OnLeftClick(Vector2 position);

    public void OnPoint(Vector2 position);
}