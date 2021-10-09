using UnityEngine;
using UnityEngine.UI;

public class PortalSprite : MonoBehaviour
{
  public Camera renderCamera;

  private Image _slotImage;
  private Sprite _sprite;

  // Start is called before the first frame update
  void Start()
  {
    // RenderTexture renderTexture = new RenderTexture(512, 512, 0);
    // renderTexture.name = "Default_Texture";
    // renderCamera.targetTexture = renderTexture;
    _slotImage = gameObject.GetComponent<Image>();
    Debug.Log(renderCamera.targetTexture);
    Texture2D modelView = ToTexture2D(renderCamera.targetTexture);
    _sprite = Sprite.Create(modelView, new Rect(0, 0, modelView.width, modelView.height), new Vector2(0.5f, 0.5f));
    _sprite.name = modelView.name;

    SpriteRenderer _sp = GetComponent<SpriteRenderer>();

    Debug.Log(_sp);
    GetComponent<SpriteRenderer>().sprite = _sprite;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public Texture2D ToTexture2D(RenderTexture rTex)
  {
    RenderTexture currentActiveRT = RenderTexture.active;
    RenderTexture.active = rTex;
    renderCamera.Render();

    Texture2D tex = new Texture2D(rTex.width, rTex.height);
    tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
    tex.Apply();
    RenderTexture.active = currentActiveRT;
    return tex;
  }
}
