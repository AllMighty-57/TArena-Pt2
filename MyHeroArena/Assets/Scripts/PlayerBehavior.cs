using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBehavior : MonoBehaviour
{

    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;

    public float JumpVelocity = 5f;
    private bool _isJumping;
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    private GameBehavior _gameManager;


    void Start()
    {

        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game Manager")
            .GetComponent<GameBehavior>();
    }
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
       
        _isJumping |= Input.GetKeyDown(KeyCode.Space);
        _isShooting |= Input.GetKeyDown(KeyCode.KeypadEnter);


    }
    void FixedUpdate()
    {

        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation *
            Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position +
            this.transform.forward * _vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);
        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity,
                 ForceMode.Impulse);
        }
        _isJumping = false;

        if (_isShooting)
        {
            // 5
            Vector3 spawnPos = transform.position +
                                   transform.forward * 1f;
            // 6
            GameObject newBullet = Instantiate(Bullet, spawnPos,
                                       this.transform.rotation);
            // 7
            Rigidbody bulletRB =
                newBullet.GetComponent<Rigidbody>();

            // 8
            bulletRB.linearVelocity = this.transform.forward *
                                          BulletSpeed;
        }
        // 9
        _isShooting = false;

    }
    private bool IsGrounded()
    {
        // 7
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
            _col.bounds.min.y, _col.bounds.center.z);

        // 8
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
            capsuleBottom, DistanceToGround, GroundLayer,
                QueryTriggerInteraction.Ignore);

        // 9
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 4 
        if (collision.gameObject.name == "Enemy")
        {
            // 5 
            _gameManager.HP -= 1;
        }
    }

}