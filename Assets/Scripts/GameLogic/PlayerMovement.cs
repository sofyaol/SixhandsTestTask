using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] CharacterController _characterController;
    [SerializeField] private Joystick _joystick;
    
    [Space] [Header("Movement parameters")]
    [SerializeField][Range(0, 20)] private float _speed;
    [SerializeField] private float _gravity;
    
    private float _currentGravity;
    private Vector3 _gravityDirection;
    private Vector3 _gravityMovement;
    private Vector3 _direction;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        if (_joystick == null)
        {
            _joystick = FindObjectOfType<Joystick>();
        }

        if (_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }
        
        _gravityDirection = Vector3.down;
    }

    void Update()
    {
        CalculateGravity();

        float vertical = _joystick.Vertical;
        float horizontal = _joystick.Horizontal;

        if (vertical != 0 || horizontal != 0)
        { 
            Walk(horizontal, vertical);
        }
        else
        {
            _animator.SetBool(IsWalking, false);
        }
    }
    
    private void Walk(float horizontal, float vertical)
    {
     
            _animator.SetBool(IsWalking, true);
            _direction = new Vector3(horizontal, 0, -vertical);

            float rotationY = -Quaternion.LookRotation(_direction).eulerAngles.y;
            transform.rotation = Quaternion.AngleAxis(rotationY, Vector3.up);
            _characterController.Move(transform.forward * _speed * Time.deltaTime + _gravityMovement);
     
        
    }

    private void CalculateGravity()
    {
        if (IsGrounded())
        {
            _currentGravity = 0;
        }
        else
        {
            _currentGravity -= _gravity * Time.deltaTime;
        }

        _gravityMovement = _gravityDirection * -_currentGravity * Time.deltaTime;
    }

    private bool IsGrounded()
    {
        return _characterController.isGrounded;
    }
}

