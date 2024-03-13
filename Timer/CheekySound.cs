using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
//using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

	public void ShortTimerSet()
	{
		var saws = SetterPattern(stFreqs, stDurations);
		PlaySet(saws);
	}

	public void LongTimerSet()
	{
		var saws = SetterPattern(ltFreqs, ltDurations);
		PlaySet(saws);
	}

	private void Output_PlaybackStopped(object sender, StoppedEventArgs e)
	{
		output.PlaybackStopped -= Output_PlaybackStopped;
		output.Dispose();
		output = null;
	}

	private void PlaySet(ISampleProvider input)
	{
		if (output != null)
			AlarmStop();
		
		output = new WaveOut();

		output.Init(input);
		output.Play();
		output.PlaybackStopped += Output_PlaybackStopped;
	}

	public async void AlarmStart()
	{
		//var saws = AlarmPattern(alarmFreqs, alarmDurations);

		alarmStopped = false;
		int reps = 0;

		output = new WaveOut();

		ISampleProvider alarm = AlarmPattern(alarmFreqs, alarmDurations);
		
		while (!alarmStopped && reps < 300)
		{
			
			output.Init(alarm);
			output.Play();

			await Task.Delay(TimeSpan.FromSeconds(4));

			alarm = AlarmPattern(alarmFreqs, alarmDurations);

			reps++;
		}

		if (reps >= 300)
			AlarmStop();
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

			float gain = 0.3f;
			for (int reps = 0; reps < 3; reps++)
			{
				for (int f = 0; f < freqs.Length; f++)
				{
					concat = concat.FollowedBy(TimeSpan.FromMilliseconds(durations / 2), new FilteredSaw(freqs[f], 8f, 48000, sawRate, gain).Take(TimeSpan.FromMilliseconds(durations / 2)));
				}
				gain *= 0.25f;
			}

		return concat;
	}
}
