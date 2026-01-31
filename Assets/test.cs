using Omotenashi;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Emotion.OnEmotionSelected += TestDelegate;
    }

    void OnDestroy()
    {
        Emotion.OnEmotionSelected += TestDelegate;
    }

    // Update is called once per frame
    void TestDelegate(Emotions output)
    {
        Debug.Log(output);
    }
}
