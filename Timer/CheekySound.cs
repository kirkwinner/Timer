using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Linq;
using System.Security.Policy;
using System.Threading;

public class CheekySound
{
	private readonly float[] stFreqs = new float[]
	{
		0,
		1200,
		600,
		1200,
		600,
		1200,
		600
	};

	private readonly float stDurations = 150f;

	private readonly float[] ltFreqs = new float[]
	{
		0,
		1200,
		600,
		800,
		1200
	};

	private readonly float ltDurations = 250f;

	private readonly float[] alarmFreqs = new float[]
	{
		200,
		300,
		400,
		500,
		600,
		700,
		800
	};

	private readonly float alarmDurations = 142f;

	private bool alarmStopped;

	private WaveOut output;
	//public Sound()
	//{
	//	var saws = Pattern(freqs, 250);

	//	using (var wo = new WaveOutEvent())
	//	{
	//		wo.Init(saws);
	//		wo.Play();

	//		while (wo.PlaybackState == PlaybackState.Playing)
	//		{
	//			Thread.Sleep(50);
	//		}

	//		wo.Stop();
	//	}
	//}

	public void ShortTimerSet()
	{
		var saws = SetterPattern(stFreqs, stDurations);

		using (var wo = new WaveOutEvent())
		{
			wo.Init(saws);
			wo.Play();

			while (wo.PlaybackState == PlaybackState.Playing)
			{
				Thread.Sleep(50);
			}

			wo.Stop();
		}
	}

	public void LongTimerSet()
	{
		var saws = SetterPattern(ltFreqs, ltDurations);

		using (var wo = new WaveOutEvent())
		{
			wo.Init(saws);
			wo.Play();

			while (wo.PlaybackState == PlaybackState.Playing)
			{
				Thread.Sleep(50);
			}

			wo.Stop();
		}
	}

	public void AlarmStart()
	{
		var saws = AlarmPattern(alarmFreqs, alarmDurations);

		alarmStopped = false;
		output = new WaveOut();

		output.Init(saws);

		output.Play();
		
	}

	public void AlarmStop()
	{
		alarmStopped = true;
		if (output != null)
		{
			if (output.PlaybackState == PlaybackState.Playing)
				output.Stop();

			output.Dispose();
			output = null;
		}
	}

	private ISampleProvider SetterPattern(float[] freqs, float durations)
	{
		float sawRate = 1 / (durations/1000f);
		ISampleProvider concat = new FilteredSaw(freqs[0], 8f, 48000, sawRate, 0.2f).Take(TimeSpan.FromMilliseconds(durations/2));
		float gain = 0.2f;

		for (int f = 1; f < freqs.Length; f++)
		{
			concat = concat.FollowedBy(TimeSpan.FromMilliseconds(durations/2), new FilteredSaw(freqs[f], 8f, 48000, sawRate, gain).Take(TimeSpan.FromMilliseconds(durations/2)));
			gain *= (freqs.Length * 0.08f);
		}

		return concat;
	}

	private ISampleProvider AlarmPattern(float[] freqs, float durations)
	{
		float sawRate = 1 / (durations / 1000f);
		ISampleProvider concat = new FilteredSaw(0, 8f, 48000, sawRate, 0).Take(TimeSpan.FromMilliseconds(5));

		for (int loops = 0; loops < 60; loops++)
		{
			float gain = 0.3f;
			for (int reps = 0; reps < 3; reps++)
			{
				for (int f = 0; f < freqs.Length; f++)
				{
					concat = concat.FollowedBy(TimeSpan.FromMilliseconds(durations / 2), new FilteredSaw(freqs[f], 8f, 48000, sawRate, gain).Take(TimeSpan.FromMilliseconds(durations / 2)));
				}
				gain *= 0.25f;
			}

			concat = concat.FollowedBy(new FilteredSaw(0, 0, 48000, sawRate, 0).Take(TimeSpan.FromMilliseconds(durations * freqs.Length)));
		}

		return concat;
	}
}
