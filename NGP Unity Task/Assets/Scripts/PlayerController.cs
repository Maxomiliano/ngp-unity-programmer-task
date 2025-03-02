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
    private Animator _animator;
    private bool _isGrounded;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        Run();
        Jump();
        PickItem();
        FlipSprite();
    }

    private void Run()
    {
        float move = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(move * _speed, _rb.velocity.y);
        bool playerHasHorizontalSpeed = Mathf.Abs(_rb.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("Running", playerHasHorizontalSpeed);
    }
    private void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
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

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rb.velocity.x), 1f);
        }
    }

}
