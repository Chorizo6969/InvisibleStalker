using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector2 _movement;

    [SerializeField]
    private Rigidbody _rb;

    public Transform cameraTransform;

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if ((_rb != null && cameraTransform != null))
        {
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;


            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();


            Vector3 movement = (forward * _movement.y + right * _movement.x) * _speed * Time.fixedDeltaTime;

            _rb.MovePosition(_rb.position + movement);
        }
    }
}