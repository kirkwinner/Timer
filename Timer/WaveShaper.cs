using System;
using NAudio;

public class WaveShaper
{
	float threshold;
	float ratio;

	public WaveShaper(float _threshold, float _ratio)
	{
		threshold = _threshold;
		ratio = _ratio;
	}
	
	public float Processs(float sample)
	{
		float outSample;
		if (sample > threshold)
		{
			outSample = (sample - threshold) / ratio + threshold;
		}
		else if (sample < -threshold)
		{
			outSample = (sample + threshold) / ratio - threshold;
		}
		else
		{
			outSample = sample;
		}

		return outSample;
	}
}
