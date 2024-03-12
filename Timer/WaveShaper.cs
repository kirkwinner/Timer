using System;
using NAudio;

/*
 * These functions are largely inspired by the Waveshaping section of the CSound manual: https://flossmanual.csound.com/sound-synthesis/waveshaping
 * And the Waveshaping article on A Perfect Circuit: https://www.perfectcircuit.com/signal/learning-synthesis-waveshapers
 * 
 */
public class WaveShaper
{
	float threshold;
	float ratio;
	float exponent;
	float quantisedValues;

	/// <summary>
	/// Initialise the waveshaper
	/// </summary>
	/// <param name="_threshold">Represents the amplitude at which Hard Knee and Wave Fold will start to be applied, and at which Soft Clip and hard clip will make the signal completely horizontal</param>
	/// <param name="_ratio">Ratio for Hard Knee squash. Cannot be less than 1</param>
	/// <param name="_exponent">The exponent used for Power Shaping</param>
	/// <param name="_bits">The number of bits to output from the Bit Crusher</param>
	public WaveShaper(float _threshold, float _ratio = 2f, float _exponent = 1f, int _bits = 8)
	{
		threshold = Math.Min(Math.Max(_threshold, 0f), 1f);

		ratio = Math.Max(_ratio, 1f);

		exponent = _exponent;

		quantisedValues = (float)Math.Pow(2, _bits) / 2 - 1;
	}

	#region Symmetrical Functions

	/// <summary>
	/// Reduces the amplitude of input signal in excess of the Threshold by the Ratio.
	/// There is probably a proper name for this but I don't know what it is.
	/// In the case of Threshold = 0.5 and Ratio = 2, a signal of amplitude 1 will become 0.75.
	/// Can be thought of as a kind of compressor with infinitely short attack and release.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet squashed sample</returns>
	public float HardKnee(float sample)
	{
		float outSample;

		if (sample > threshold)
			outSample = (sample - threshold) / ratio + threshold;
		
		else if (sample < -threshold)
			outSample = (sample + threshold) / ratio - threshold;
		
		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Hard-clips the input. The Threshold for this function determines the point that the
	/// output will not exceed. In the case of Threshold = 0.5, any signal above 0.5 will
	/// become a flat line until the input drops below 0.5 again.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet hard-clipped sample</returns>
	public float HardClip(float sample)
	{
		float outSample;

		if (sample > threshold)
			outSample = threshold;

		else if (sample < -threshold)
			outSample = -threshold;

		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Soft-clips the input. The Threshold for this function is the point at which the soft
	/// clip curve ends. In the case of Threshold = 1, an infinitely high amplitude input
	/// will approach an output value of 1.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet soft-clipped sample</returns>
	public float SoftClip(float sample)
	{
		if (threshold == 0)
			return 0f;

		float outSample;
		
		sample /= threshold;

		outSample = (float)Math.Tanh(sample) * threshold;

		return outSample;
	}

	/// <summary>
	/// Adds odd-numbered harmonics to the input signal, has a similar effect to tape saturation.
	/// The Exponent value determines the degree of power-shaping. Exponents >1 add overtones and
	/// reduce the strength of the base input frequency as exponent size increases. A very large
	/// exponent size transforms a sine wave into a series of positive and negative impulses.
	/// 
	/// Exponents <1 add overtones but maintain the strength of the input frequency as exponent
	/// size approaches 0. An exponent size very close to 0 transforms a sine wave into a square wave.
	/// </summary>
	/// <param name="sample">Dry input signal</param>
	/// <returns>Wet saturated signal</returns>
	public float PowerShape(float sample)
	{
		float outSample = (float)Math.Abs(Math.Pow(sample, exponent));

		if (sample < 0f)
			outSample = -outSample;

		return outSample;
	}

	/// <summary>
	/// Folds back the waveform when it reaches the threshold value. Samples in the input signal
	/// with a greater amplitude than the threshold begin moving back towards zero. Apparently
	/// this process is prone to introducing aliasing errors, so use with caution. Or don't,
	/// I'm not your dad.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet folded sample</returns>
	public float WaveFold(float sample)
	{
		float outSample;

		if (sample > threshold)
			outSample = threshold * 2 - sample;

		else if (sample < -threshold)
			outSample = -threshold * 2 + sample;

		else
			outSample = sample;

		return outSample;
	}

	#endregion

	/// <summary>
	/// Flips all negative sample values into positive ones.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet rectified sample</returns>
	public float Rectify(float sample)
	{
		return (float)Math.Abs(sample);
	}

	/// <summary>
	/// Lowers the bit-depth of the input to the specified number of bits.
	/// </summary>
	/// <param name="sample"></param>
	/// <returns></returns>
	public float BitCrush(float sample)
	{
		if (sample == 0f) return 0f;

		int quantisedSample = (int)(sample * quantisedValues);
		float outSample = quantisedSample / quantisedValues;

		return outSample;
	}

	#region Asymmetrical Functions
	/*The following functions are duplicates of the above functions, except that they are
	only applied to positive or negative input values, so that asymmetrical wave-shaping
	can be performed.
	
	Additionally, since none of these functions will output a value
	with a sign not matching the input value, an input can be run through the Positive
	version of one function and the Negative version of a second function without either
	pass interfering with the other.
	
	The exception to this is the Wave Fold, which could result in samples swapping signs
	if the input exceeds double the threshold value. */

	/// <summary>
	/// Hard knee, but only applied to positive input values.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet squashed sample</returns>
	public float PosHardKnee(float sample)
	{
		float outSample;

		if (sample > threshold)
			outSample = (sample - threshold) / ratio + threshold;

		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Hard knee, but only applied to negative input values.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet squashed sample</returns>
	public float NegHardKnee(float sample)
	{
		float outSample;

		if (sample < threshold)
			outSample = (sample + threshold) / ratio - threshold;

		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Hard-clipper that only applies to positive inputs.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet hard-clipped sample</returns>
	public float PosHardClip(float sample)
	{
		float outSample;

		if (sample > threshold)
			outSample = threshold;

		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Hard-clipper that only applies to negative inputs.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet hard-clipped sample</returns>
	public float NegHardClip(float sample)
	{
		float outSample;

		if (sample < threshold)
			outSample = threshold;

		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Soft-clipper that only applies to input samples with positive values.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet soft-clipped sample</returns>
	public float PosSoftClip(float sample)
	{
		if (sample <= 0)
			return sample;

		if (threshold == 0)
			return 0f;

		float outSample;

		sample /= threshold;

		outSample = (float)Math.Tanh(sample) * threshold;

		return outSample;
	}

	/// <summary>
	/// Soft-clipper that only applies to input samples with negative values.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet soft-clipped sample</returns>
	public float NegSoftClip(float sample)
	{
		if (sample >= 0)
			return sample;

		if (threshold == 0)
			return 0f;

		float outSample;

		sample /= threshold;

		outSample = (float)Math.Tanh(sample) * threshold;

		return outSample;
	}

	/// <summary>
	/// Power-shaper that only applies to inputs with a positive value.
	/// </summary>
	/// <param name="sample">Dry input signal</param>
	/// <returns>Wet saturated signal</returns>
	public float PosPowerShape(float sample)
	{
		if (sample <= 0)
			return sample;

		float outSample = (float)Math.Abs(Math.Pow(sample, exponent));

		return outSample;
	}

	/// <summary>
	/// Power-shaper that only applies to inputs with a negative value.
	/// </summary>
	/// <param name="sample">Dry input signal</param>
	/// <returns>Wet saturated signal</returns>
	public float NegPowerShape(float sample)
	{
		if (sample >= 0)
			return sample;

		return -(float)Math.Abs(Math.Pow(sample, exponent));
	}

	/// <summary>
	/// Wave-folder that only applies to inputs with a positive value.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet folded sample</returns>
	public float PosWaveFold(float sample)
	{
		float outSample;

		if (sample > threshold)
			outSample = threshold * 2 - sample;

		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Wave-folder that only applies to inputs with a negative value.
	/// </summary>
	/// <param name="sample">Dry input sample</param>
	/// <returns>Wet folded sample</returns>
	public float NegWaveFold(float sample)
	{
		float outSample;

		if (sample < -threshold)
			outSample = -threshold * 2 + sample;

		else
			outSample = sample;

		return outSample;
	}

	/// <summary>
	/// Bit-crushes inputs with a positive value.
	/// </summary>
	/// <param name="sample"></param>
	/// <returns></returns>
	public float PosBitCrush(float sample)
	{
		if (sample <= 0f) return sample;

		int quantisedSample = (int)(sample * quantisedValues);
		float outSample = quantisedSample / quantisedValues;

		return outSample;
	}

	/// <summary>
	/// Bit-crushes inputs with a negative value
	/// </summary>
	/// <param name="sample"></param>
	/// <returns></returns>
	public float NegBitCrush(float sample)
	{
		if (sample >= 0f) return sample;

		int quantisedSample = (int)(sample * quantisedValues);
		float outSample = quantisedSample / quantisedValues;

		return outSample;
	}

	#endregion
}
