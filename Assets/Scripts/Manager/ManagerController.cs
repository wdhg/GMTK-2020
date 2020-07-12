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

  private string messageText = "";
  private int textIndex;
  private float timeSinceSay;
  private AudioSource audioSource;
  private List<string> insults;
  private float intervalTime;
  private bool speaking;

  private void Start() {
    this.audioSource = this.GetComponent<AudioSource>();
    this.LoadInsults();
    this.intervalTime = Random.Range(this.minInterval, this.maxInterval);
    this.speaking = false;
  }

  private void LoadInsults() {
    this.insults = new List<string>();
    StreamReader sr = new StreamReader("Assets/insults.txt");
    using (sr) {
      string read;
      if (sr != null) {
        while((read = sr.ReadLine()) != null) {
          this.insults.Add(read);
        }
      }
    }
  }

  public void Say() {
    this.message.text = "";
    int index = Random.Range(0, this.insults.Count);
    this.messageText = this.insults[index];
    this.textIndex = 0;
    this.timeSinceSay = 0f;
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
