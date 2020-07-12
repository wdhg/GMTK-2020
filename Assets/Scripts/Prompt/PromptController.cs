using static InteractableMethods;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PromptController : MonoBehaviour {

    List<PromptPair> prompts = new List<PromptPair>();
    private PromptDisplayer promptText;
    private GameObject workMeter;
    private Meter work;
    PromptPair prompt;
    PromptPair previous;

    private void Start() {
        initPrompts();
        promptText = gameObject.GetComponent<PromptDisplayer>();
        workMeter = GameObject.Find("WorkMeter");
        if (workMeter != null) {
            work = workMeter.GetComponent<Meter>();
        }
        getNewPrompt();
        previous = prompt;
    }

    private void initPrompts() {
    prompts.Add(new PromptPair("Press the red button;red_square"));
    prompts.Add(new PromptPair("Press the red button;red_circle"));
    prompts.Add(new PromptPair("Press the green button;green_square"));
    prompts.Add(new PromptPair("Press the blue button;blue_square"));
    prompts.Add(new PromptPair("Press the yellow button;yellow_circle"));
    prompts.Add(new PromptPair("Press the big button;red_circle"));
    prompts.Add(new PromptPair("Press the small button;yellow_circle"));
    prompts.Add(new PromptPair("Slide the slider to one;slider_0"));
    prompts.Add(new PromptPair("Slide the slider to two;slider_1"));
    prompts.Add(new PromptPair("Slide the slider to three;slider_2"));
    prompts.Add(new PromptPair("Slide the slider to four;slider_3"));
    prompts.Add(new PromptPair("Slide the slider to five;slider_4"));
    prompts.Add(new PromptPair("Pull the lever;lever"));
    prompts.Add(new PromptPair("Press the left-hand square button;red_square"));
    prompts.Add(new PromptPair("Press the center square button;green_square"));
    prompts.Add(new PromptPair("Press the right-hand square button;blue_square"));
    prompts.Add(new PromptPair("Press the left-hand round button;red_circle"));
    prompts.Add(new PromptPair("Press the right-hand round button;yellow_circle"));
    prompts.Add(new PromptPair("Press the round button;red_circle"));
    prompts.Add(new PromptPair("Press the round button;yellow_circle"));
    prompts.Add(new PromptPair("Press the square button;red_square"));
    prompts.Add(new PromptPair("Press the square button;green_square"));
    prompts.Add(new PromptPair("Press the square button;blue_square"));
    prompts.Add(new PromptPair("Hit the square;green_square"));
    prompts.Add(new PromptPair("Smash that blue button;blue_square"));
    prompts.Add(new PromptPair("Red button, please;red_circle"));
    prompts.Add(new PromptPair("Slide to the leftmost slider slot;slider_0"));
    prompts.Add(new PromptPair("Slide to the rightmost slider slot;slider_4"));
    prompts.Add(new PromptPair("Move the slider to the center;slider_2"));
    prompts.Add(new PromptPair("Hit the small round button;yellow_circle"));
    prompts.Add(new PromptPair("Slap the red square button;red_square"));
    prompts.Add(new PromptPair("Push the red button;red_circle"));
    prompts.Add(new PromptPair("Push the red button;red_square"));
    prompts.Add(new PromptPair("Hit the green square;green_square"));
    prompts.Add(new PromptPair("Smash that round button;yellow_circle"));
    prompts.Add(new PromptPair("Smash that round button;red_circle"));
    prompts.Add(new PromptPair("Hit that button;red_square"));
    prompts.Add(new PromptPair("Hit that button;blue_square"));
    prompts.Add(new PromptPair("Hit that button;yellow_circle"));
    prompts.Add(new PromptPair("Slap the red round button;red_circle"));
    prompts.Add(new PromptPair("Push the green button;green_square"));
    prompts.Add(new PromptPair("Get the lever;lever"));
    prompts.Add(new PromptPair("Set the slider to four;slider_3"));
    prompts.Add(new PromptPair("Set the slider to one;slider_0"));
    prompts.Add(new PromptPair("Set the slider to five;slider_4"));
    prompts.Add(new PromptPair("Switch that lever;lever"));
    prompts.Add(new PromptPair("Push the lever;lever"));
    prompts.Add(new PromptPair("Activate the lever;lever"));
  }

    private void getNewPrompt() {
        previous = prompt;
        while (previous == prompt) {
            System.Random random = new System.Random();
            int index = random.Next(prompts.Count);
            prompt = prompts[index];
        }
        previous = prompt;
        if(Config.DEBUG) {
            Debug.Log("Prompt: " + prompt.getString());
            Debug.Log("Button required: " + prompt.getInteractable());
        }
        if (promptText != null) {
            promptText.displayPrompt(prompt.getString());
        }
    }

    public void checkInteractable(string id) {
        Interactable interactable = identifyInteractable(id);
        if (interactable == prompt.getInteractable()) {
            if (work != null) {
                work.increase(0.1f);
            }
            getNewPrompt();
        } else {
            work.decrease(0.05f);
        }
    }

}