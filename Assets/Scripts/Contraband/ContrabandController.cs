using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrabandController : MonoBehaviour {

  public bool alcohol;
  public GameObject sanityMeter;
  private Meter sanity;

  private void Start() {
      sanityMeter = GameObject.Find("SanityMeter");
      if (sanityMeter != null) {
          sanity = sanityMeter.GetComponent<Meter>();
      }
  }

  public void OnMouseDown() {
    if (Config.DEBUG) {
      Debug.Log("Contraband (is alcohol = " + alcohol + ") pressed");
    }
    if (sanity != null) {
      sanity.increase(0.1f);
    }
    if (alcohol) {
      
    } else {

    }
  }
}
