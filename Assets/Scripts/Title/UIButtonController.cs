using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonController : MonoBehaviour, IPointerDownHandler {

  public Screen screen;

  private ScreenManager sm;

  private void Start() {
    sm = GameObject.FindGameObjectWithTag("ScreenManager").GetComponent<ScreenManager>();
  }

  public void OnPointerDown(PointerEventData eventData) {
    sm.OpenScreen(screen);
  }
}
