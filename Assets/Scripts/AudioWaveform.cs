using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioWaveform : MonoBehaviour
{
    public GameObject myprefab;
    public double threshold = 0.006;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);

        for (int i = 1; i < spectrum.Length; i+=24)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);

            if (spectrum[i] > threshold)
            {
                Instantiate(myprefab, new Vector3(15,0,10), Quaternion.identity);
            }
        }
    }
}
