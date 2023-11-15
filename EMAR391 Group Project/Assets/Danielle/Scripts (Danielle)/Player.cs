using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    public ScreenBounds screenBounds;
    public AudioSource shootSound;
    public AudioClip hitSound;
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private bool _reversing;
    private bool _isDamaged = false;
    private float _turnDirection;
    public Animator animator;
    public RuntimeAnimatorController nanobotController;
    public RuntimeAnimatorController nanobotDamagedController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        _reversing = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        } else
        {
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
            shootSound.Play();
        }     
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }
        
        if (_reversing)
        {
            _rigidbody.AddForce(this.transform.up * -this.thrustSpeed);
        }

        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection * turnSpeed);
        }

        Vector3 tempPosition = transform.position;
        if (screenBounds.AmIOutOfBounds(tempPosition))
        {
            Vector2 newPosition = newPosition = screenBounds.CalculateWrappedPosition(tempPosition);
            transform.position = newPosition;
        }
        else
        {
            transform.position = tempPosition;
        }
    }

    private void LateUpdate()
    {
        if(_isDamaged)
        {
            animator.runtimeAnimatorController = nanobotDamagedController;
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Virus")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            _isDamaged = true;

            AudioSource.PlayClipAtPoint(hitSound, new Vector2(0, 0));
            this.gameObject.SetActive(false);

            FindAnyObjectByType<GameManager>().PlayerDied();
        }
    }
}
