using UnityEngine;

public class ContrabandController : MonoBehaviour {

  public Meter sanity;
  public HandController hand;

  private bool handHovering = false;

  private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.tag == "Hand") {
      this.handHovering = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if(collision.tag == "Hand") {
      this.handHovering = false;
    }
  }

  private void Update() {
    if(handHovering && Input.GetKeyDown(KeyCode.Mouse0) && !hand.IsShaking()) {
      if (Config.DEBUG) {
        Debug.Log("Contraband pressed");
      }
      sanity.increase(0.2f);
      hand.StartShake();
    }
  }
}
