using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{

    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private LayerMask _layer;
    private bool _resetJumpNeeded = false;
    private bool _grounded;
    private PlayerAnimation _anim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordArcSprite;

    public int Health { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _anim.Attack();
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _anim.Move(horizontalInput);
        _grounded = IsGrounded();

        if (horizontalInput > 0)
        {
            Flip(true);
        }
        else if (horizontalInput < 0)
        {
            Flip(false);
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {     
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _anim.Jump(true);
            StartCoroutine(ResetJumpRoutine());
        }

        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _layer);
        //Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if(hitInfo.collider != null)
        {
            if (_resetJumpNeeded == false)
            {
                _anim.Jump(false);
                return true;
            }
        }
        
        return false;
    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _sprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else if (faceRight == false)
        {
            _sprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    }

    public void Damage()
    {
        Debug.Log("Player Damage() called");
    }

}














