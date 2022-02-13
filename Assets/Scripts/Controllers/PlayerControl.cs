using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  public int speed = 20;
  public PictureData picConf;

  private float _distPerc = 0, _currSpeed = 0;
  private Rigidbody2D _rb;

  void Start()
  {
    _rb = GetComponent<Rigidbody2D>();
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
    float _scale = this.GetSpriteScale();
    float _speedScale = this.GetSpeedScale();
    _currSpeed = _speedScale;

    _rb.MovePosition(_rb.position + direction * _speedScale * Time.deltaTime);
    transform.localScale = new Vector3(_scale, _scale, 1);
  }


  private float GetDistancePercentage()
  {
    float distDiff = picConf.maxYPos - picConf.minYPos;
    float distPlayerDiff = transform.localPosition.y - picConf.maxYPos;
    float perc = Mathf.Abs((distPlayerDiff / distDiff) * 100);

    if (perc < 0) return 0;
    return perc > 100 ? 100 : perc;
  }

  private float GetSpriteScale()
  {
    return (_distPerc * (picConf.maxScale - picConf.minScale) / 100) + picConf.minScale;
  }

  private float GetSpeedScale()
  {
    return picConf.baseSpeed + ((_distPerc * (picConf.maxSpeed - picConf.minSpeed) / 100) + picConf.minSpeed);
  }
}
