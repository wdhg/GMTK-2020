using UnityEngine;

public class Meter : MonoBehaviour {
    
    float maxValue = 1.0f;
    float minValue = 0.0f;
    public float currentValue = 0.5f;
    public float timePerDecrement = 1.0f;
    float timer = 0.0f;
    public bool work;
    public Transform fill;

    private void Start() {
        fill = transform.Find("Fill Parent");
    }

    public void increase(float f) {
        currentValue += f;
        if (currentValue > maxValue) {
            currentValue = maxValue;
        }
    }

    public void decrease(float f) {
        currentValue -= f;
        if (currentValue < minValue) {
            currentValue = minValue;
        }
    }

    public void Update() {
        timer += Time.deltaTime;
        if (timer > timePerDecrement && work) {
            currentValue -= 0.01f;
            timer = 0.0f;
        }
        if (fill != null) {
            fill.transform.localScale = new Vector3(1.0f, currentValue, 1.0f);
        }
        if (currentValue <= minValue) {
            if(Config.DEBUG) {
                Debug.Log("Game over");
            }
            //game over
        }
    }

}