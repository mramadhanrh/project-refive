using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  // Start is called before the first frame update

  int _speed = 10;
  private Rigidbody2D _rigidbody2D;
  void Start()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    UpdateControl();
  }

  private void UpdateControl()
  {
    // GetAxisRaw is unsmoothed input -1, 0, 1
    float v = Input.GetAxisRaw("Vertical");
    float h = Input.GetAxisRaw("Horizontal");

    // normalize so going diagonally doesn't speed things up
    Vector3 direction = new Vector3(h, v, 0f).normalized;

    // translate
    transform.Translate(direction * _speed * Time.deltaTime);
  }
}
