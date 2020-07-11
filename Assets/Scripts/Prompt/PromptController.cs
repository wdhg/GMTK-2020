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

    private void Start() {
        initPrompts();
        promptText = gameObject.GetComponent<PromptDisplayer>();
        workMeter = GameObject.Find("WorkMeter");
        if (workMeter != null) {
            work = workMeter.GetComponent<Meter>();
        }
        getNewPrompt();
    }

    private void initPrompts() {
        StreamReader sr = new StreamReader("Assets/prompts.txt");
        using (sr) {
            string read;
            if (sr != null) {
                while ((read = sr.ReadLine()) != null) {
                    PromptPair pair = new PromptPair(read);
                    prompts.Add(pair);
                }
            }
        }
    }

    private void getNewPrompt() {
        System.Random random = new System.Random();
        int index = random.Next(prompts.Count);
        prompt = prompts[index];
        if(Config.DEBUG) {
            Debug.Log("Prompt: " + prompt.getString());
            Debug.Log("Button required: " + prompt.getInteractable());
        }

        //work value to go up
        if (work != null) {
            work.increase(0.1f);
        }

        if (promptText != null) {
            promptText.displayPrompt(prompt.getString());
        }
    }

    public void checkInteractable(string id) {
        Interactable interactable = identifyInteractable(id);
        if (interactable == prompt.getInteractable()) {
            //increment work thing
            getNewPrompt();
        } else {
            Debug.Log(interactable + " != " + prompt.getInteractable());
        }
    }

}