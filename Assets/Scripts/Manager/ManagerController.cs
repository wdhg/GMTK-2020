using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour {

  public float characterTime;
  public float idleTime;
  public Text message;
  public GameObject display;
  public float pitchMin, pitchMax;
  public AudioClip sfx;
  public float minInterval, maxInterval;
  private GameObject sanityMeter;
  private Meter sanity;

  private string messageText = "";
  private int textIndex;
  private float timeSinceSay;
  private AudioSource audioSource;
  private List<string> insults = new List<string>();
  private float intervalTime;
  private bool speaking;

  private void Start() {
    this.audioSource = this.GetComponent<AudioSource>();
    this.LoadInsults();
    this.intervalTime = Random.Range(this.minInterval, this.maxInterval);
    this.speaking = false;
    sanityMeter = GameObject.Find("SanityMeter");
    if (sanityMeter != null) {
        sanity = sanityMeter.GetComponent<Meter>();
    }
  }

  private void LoadInsults() {
    insults.Add("You are a big dummy");
    insults.Add("Do you even know spreadsheets?");
    insults.Add("You're behind schedule doofus!");
    insults.Add("My child could do a better job!");
    insults.Add("No wonder your wife left you");
    insults.Add("Do I smell booze?");
    insults.Add("You're getting a demotion!");
    insults.Add("Have a shower once in a while");
  }

  public void Say() {
    this.message.text = "";
    int index = Random.Range(0, this.insults.Count);
    this.messageText = this.insults[index];
    this.textIndex = 0;
    this.timeSinceSay = 0f;
    if (sanity != null) {
      sanity.decrease(0.15f);
    }
    this.display.SetActive(true);
    this.audioSource.pitch = Random.Range(this.pitchMin, this.pitchMax);
    this.audioSource.Play();
  }
  private void SayCharacter() {
    this.message.text += this.messageText[this.textIndex];
    this.textIndex++;
  }

  private void Update() {
    if (0 < this.intervalTime) {
      this.intervalTime -= Time.deltaTime;
      return;
    }
    if (!this.speaking) {
      this.speaking = true;
      this.Say();
    }
    float speakTime = this.messageText.Length * this.characterTime;
    if(this.display.activeSelf && speakTime + this.idleTime <= this.timeSinceSay) {
      this.display.SetActive(false);
      this.intervalTime = Random.Range(this.minInterval, this.maxInterval);
      this.speaking = false;
      return;
    }
    if(this.message.text.Length * this.characterTime < this.timeSinceSay && this.timeSinceSay < speakTime) {
      this.SayCharacter();
    }
    this.timeSinceSay += Time.deltaTime;
  }

}
