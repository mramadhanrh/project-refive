using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  public int speed = 20;
  public PictureData picConf;

  private float _distPerc = 0, _currSpeed = 0;
  private Rigidbody2D _rb;
  private Transform _tr;

  void Start()
  {
    _rb = GetComponent<Rigidbody2D>();
    _tr = GetComponent<Transform>();
  }

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
    Vector2 direction = new Vector2(h, v).normalized;

    _distPerc = this.GetDistancePercentage();
    float _scale = this.GetSpriteScale(_distPerc);
    float _speedScale = this.GetSpeedScale(_distPerc);
    _currSpeed = _speedScale;

    _rb.MovePosition(_rb.position + direction * _speedScale * Time.deltaTime);
    _tr.localScale = new Vector3(_scale, _scale, 1);
  }


  private float GetDistancePercentage()
  {
    float _val = (Mathf.Abs(transform.localPosition.y) - Mathf.Abs(picConf.maxYPos - picConf.minYPos)) * 100;

    if (_val < 0) return 0;

    return _val > 100 ? 100 : _val;
  }

  private float GetSpriteScale(float distPerc)
  {
    return (distPerc * (picConf.maxScale - picConf.minScale) / 100) + picConf.minScale;
  }

  private float GetSpeedScale(float distPerc)
  {
    return picConf.baseSpeed + ((this.GetDistancePercentage() * (picConf.maxSpeed - picConf.minSpeed) / 100) + picConf.minSpeed);
  }
}
