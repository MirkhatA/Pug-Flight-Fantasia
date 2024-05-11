using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Jump physics")]
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private LayerCheckComponent layerCheckComponent;
    [SerializeField] private float angleInDegrees = 70f;

    [Header("Materials")]
    [SerializeField] private PhysicsMaterial2D normalMaterial;
    [SerializeField] private PhysicsMaterial2D bounceMaterial;

    private int jumpCount = 1;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = layerCheckComponent.IsTouchingLayer;

        if (_isGrounded)
        {
            jumpCount = 1;
        }
    }

    public void Jump(int direction)
    {
        if (jumpCount > 0)
        {
            var angleInRadians = angleInDegrees * Mathf.Deg2Rad;
            var horizontalVelocity = Mathf.Cos(angleInRadians) * direction;
            var verticalVelocity = Mathf.Sin(angleInRadians);
            _rigidbody.velocity = new Vector2(horizontalVelocity, verticalVelocity) * jumpForce;
            jumpCount--;
        }
    }
}
