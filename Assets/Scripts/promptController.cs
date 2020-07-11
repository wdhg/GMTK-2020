using List;
using Interactable;
using promptPair;
using UnityEngine;

public class promptController : MonoBehaviour {

    promptPair prompt;
    List<promptPair> prompts = new List<promptPair>();

    private void Start() {
        initPrompts();
        getNewPrompt();
    }

    private void initPrompts() {
        StreamReader sr = new StreamReader("../prompts.txt");
        using (sr) {
            while (sr.Peek() >= 0) {
                prompt = prompt.createPair(sr.ReadLine());
                prompts.Add(prompt);
            }
        }
    }

    private void getNewPrompt() {
        //current prompt = random prompt from list
        var random = new Random();
        int index = random.Next(prompts.Count);
        prompt = prompts[index];

        //NEEDS TO BE MADE
        //work value to go up
        displayPrompt(prompt.getString());
    }

    public void checkInteractable(Interactable interactable) {
        if (interactable == prompt.getInteractable()) {
            //correct button
            getNewPrompt();
        }
    }

}