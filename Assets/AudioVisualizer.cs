using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    //Adapted from: https://www.youtube.com/watch?v=4Av788P9stk

    AudioSource audiosource;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFreqBand();
    }

    void GetSpectrumAudioSource()
    {
        audiosource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFreqBand()
    {
        

        int count = 0;

        for(int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            float average = 0;

            if(i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;

        }
    }
}
