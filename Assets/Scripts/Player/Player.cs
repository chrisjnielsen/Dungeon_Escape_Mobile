using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;
    private PlayerControls playerInput;
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed, _horizontalInput;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private LayerMask _layer;
    private bool _resetJumpNeeded = false;
    private PlayerAnimation _anim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordArcSprite;

    private bool isMoving;
    public int Health { get; set; }

    private AudioSource _audioSource;
    


    private void Awake()
    {
        playerInput = new PlayerControls();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _swordArcSprite.gameObject.SetActive(false);
        Health = 4;
        UIManager.Instance.OpenShop(diamonds);
        UIManager.Instance.UpdateGemCount(diamonds);
        _audioSource = GameObject.Find("Sound_1_WalkPlayer").GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        if (_horizontalInput != 0) isMoving = true;
        else isMoving = false;
        if (isMoving)
        {
            if (!_audioSource.isPlaying) GameManager.Instance.WalkPlayer();
        }
        else AudioManager.instance.StopSound("WalkPlayer");

        if (playerInput.PlayerMain.Attack.triggered && IsGrounded())
        {
            _anim.Attack();
        }
    }

    void Movement()
    { 
        Vector2 movementInput = playerInput.PlayerMain.Movement.ReadValue<Vector2>();
        _horizontalInput = movementInput.x;
        
        if (IsGrounded())
        {
            movementInput.y = 0;
        }

        _anim.Move(_horizontalInput);

        if (_horizontalInput > 0)
        {
            Flip(true);
        }
        else if (_horizontalInput < 0)
        {
            Flip(false);
        }

        if (playerInput.PlayerMain.Jump.triggered && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _anim.Jump(true);
            StartCoroutine(ResetJumpRoutine());
        }

        _rb.velocity = new Vector2(movementInput.x * _speed, _rb.velocity.y);
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.5f);
        _resetJumpNeeded = false;
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _layer);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
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
        if(Health < 1)
        {
            return;
        }
        Health--;
        UIManager.Instance.UpdateLives(Health);
        if (Health < 1)
        {
            _anim.Death();
        }
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
        UIManager.Instance.OpenShop(diamonds);
    }

    public void SwordArcOn()
    {
        _swordArcSprite.gameObject.SetActive(true);
    }

    public void BootsActive()
    {
        _jumpForce=10;
    }


}














