using UnityEngine;

public class ContrabandController : MonoBehaviour {

  public Meter sanity;
  public HandController hand;

  public void OnMouseDown() {
    if (Config.DEBUG) {
      Debug.Log("Contraband pressed");
    }
    sanity.increase(0.1f);
    hand.StartShake();
  }
}
