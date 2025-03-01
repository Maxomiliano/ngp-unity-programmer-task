using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private float _interactRadius = 2f;
    
    private Rigidbody2D _rb;
    private bool _isGrounded;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(move * _speed, _rb.velocity.y);
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
        PickItem();
    }

    private void PickItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, _interactRadius, _interactableLayer);
            if (collider != null && collider.TryGetComponent(out IInteractable interactable)) 
            {
                interactable.Interact();
            }
        }
    }
}
