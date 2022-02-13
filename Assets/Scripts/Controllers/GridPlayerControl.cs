using UnityEngine;

public class GridPlayerControl : MonoBehaviour
{
  public float moveSpeed = 5f;

  private Rigidbody2D _rb;
  private Animator _animator;
  private Vector2 _movement;

  // Start is called before the first frame update
  void Start()
  {
    _rb = GetComponent<Rigidbody2D>();
    _animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    UpdateControl();
    UpdateLastFacing();
  }

  void FixedUpdate()
  {
    _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
  }

  private void UpdateControl()
  {
    _movement.x = Input.GetAxis("Horizontal");
    _movement.y = Input.GetAxis("Vertical");

    _animator.SetFloat("horizontal", _movement.x);
    _animator.SetFloat("vertical", _movement.y);
    _animator.SetFloat("speed", _movement.sqrMagnitude);

  }

  private void UpdateLastFacing()
  {
    if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
    {
      _animator.SetFloat("xIdle", _movement.x > 0 ? Mathf.Ceil(_movement.x) : Mathf.Floor(_movement.x));
      _animator.SetFloat("yIdle", _movement.y > 0 ? Mathf.Ceil(_movement.y) : Mathf.Floor(_movement.y));
    }
  }
}
