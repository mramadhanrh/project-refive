using UnityEngine;

public class Gallery : MonoBehaviour
{
  // Start is called before the first frame update

  public Animator cameraAnim;
  public Animator canvasAnim;

  private bool _isZoom = false;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
  }

  void OnMouseDown()
  {
    if (Input.GetMouseButtonDown(0))
    {
      if (_isZoom)
      {
        cameraAnim.Play("camera-zoom-out");
        canvasAnim.Play("gallery-zoom-out");
      }
      else
      {
        cameraAnim.Play("camera-zoom-in");
        canvasAnim.Play("gallery-zoom-in");
      };
      _isZoom = !_isZoom;
    }
  }
}
