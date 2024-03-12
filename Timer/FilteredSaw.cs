using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

public class FilteredSaw : ISampleProvider
{
	private float filterFreq;
	private float filterQ;
	private float sampleRate;
	private float sawFreq;
	private float gain;
	private BiQuadFilter filter;
	private SignalGenerator saw;
	private WaveShaper waveShaper;

	public WaveFormat WaveFormat { get { return saw.WaveFormat; } }

	public FilteredSaw(float _filterFreq, float _filterQ, float _sampleRate, float _sawFreq, float _gain)
	{
		filterFreq = _filterFreq;
		filterQ = _filterQ;
		sampleRate = _sampleRate;
		sawFreq = _sawFreq;
		gain = _gain;

		saw = new SignalGenerator()
		{
			Gain = gain,
			Frequency = sawFreq,
			Type = SignalGeneratorType.SawTooth
		};

		filter = BiQuadFilter.LowPassFilter(sampleRate, filterFreq, filterQ);

		waveShaper = new WaveShaper(gain*2f);
	}

	public int Read(float[] buffer, int offset, int count)
	{
		int samplesRead = saw.Read(buffer, offset, count);

		for (int i = 0; i < samplesRead; i++)
		{
			buffer[offset + i] = waveShaper.SoftClip(filter.Transform(buffer[offset + i]));
		}
		return samplesRead;
	}

}
