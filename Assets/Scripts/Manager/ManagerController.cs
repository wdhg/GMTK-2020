﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour {

  public float characterTime;
  public float idleTime;
  public Text message;
  public GameObject display;
  public float pitchMin, pitchMax;
  public AudioClip sfx;

  private string messageText = "";
  private int textIndex;
  private float timeSinceSay;
  private AudioSource audioSource;


  public void Say(string text) {
    this.message.text = "";
    this.messageText = text;
    this.textIndex = 0;
    this.timeSinceSay = 0f;
    this.display.SetActive(true);
  }
  private void Start() {
    this.audioSource = this.GetComponent<AudioSource>();
    this.Say("Butt face");
  }

  private void SayCharacter() {
    if(Config.DEBUG) {
      Debug.Log(this.messageText[this.textIndex]);
    }
    this.message.text += this.messageText[this.textIndex];
    this.textIndex++;
    this.audioSource.pitch = Random.Range(this.pitchMin, this.pitchMax);
    this.audioSource.PlayOneShot(this.sfx);
  }

  private void Update() {
    float speakTime = this.messageText.Length * this.characterTime;
    if(this.display.activeSelf && speakTime + this.idleTime <= this.timeSinceSay) {
      this.display.SetActive(false);
      return;
    }
    if(this.message.text.Length * this.characterTime < this.timeSinceSay && this.timeSinceSay < speakTime) {
      this.SayCharacter();
    }
    this.timeSinceSay += Time.deltaTime;
  }

}
