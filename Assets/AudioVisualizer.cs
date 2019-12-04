using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
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
        /*
         * 22050/512 = 43 hz per sample
         * 20 - 60hz
         * 60 - 250
         * 500 - 2000
         * 4000 - 6000
         * 6000 - 20000
         * 
         * 0 - 2 = 86
         * 1 - 4 = 172    - 87-258
         * 2 - 8 = 344    - 259-602
         * 3
         * 4
         * 5
         * 6
         * 7
         * 
         * 
         */

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
