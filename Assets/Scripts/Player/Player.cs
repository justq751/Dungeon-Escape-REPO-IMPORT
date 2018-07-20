using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private PlayerAnim _playerAnim;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speed = 5f;
    private bool _facingRight = true;
    private bool _grounded = false;
    private float _move;


    void Start ()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnim>();
	}
	
	void Update ()
    {
        Movement();
        Attacking();
    }

    //Движение и прыжки
    private void Movement()
    {
        _move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        if (_facingRight == false && _move > 0)
        {
            Flip();
        }
        else if (_facingRight == true && _move < 0)
        {
            Flip();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _playerAnim.Jump(true);
        }
        _rigidBody.velocity = new Vector2(_move * _speed, _rigidBody.velocity.y);
        _playerAnim.Move(_move);
    }

    //Проверка пола под ногами
    bool IsGrounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);
        if (hitinfo.collider != null)
        {
            Debug.Log("hit " + hitinfo.collider.name);
            _playerAnim.Jump(false);
            return true;
        }
        else
        {            
            return false;
        }
            
    }

    //Перевернуть персонажа
    void Flip()
    {
        _facingRight = !_facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    //Атака
    private void Attacking ()
    {
        if (Input.GetMouseButtonDown(0) && _grounded == true)
        {
            _playerAnim.Attack();
        }
    }
}
