using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CitySoundPlayer : MonoBehaviour
{
	[SerializeField]
	private List<AudioClip> clips;
	[SerializeField]
	private int min = 6;
	[SerializeField]
	private int max = 15;

	private AudioSource audioSource;
	private List<AudioClip> usedClips = new List<AudioClip>();

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(Random.Range(min, max));

		audioSource = gameObject.GetComponent<AudioSource>();

		while (true)
		{
			if (clips.Count == 0)
			{
				clips = usedClips;
				usedClips = new List<AudioClip>();
			}

			int index = Random.Range(0, clips.Count);
			AudioClip clip = clips[index];
			audioSource.clip = clip;
			audioSource.Play();

			usedClips.Add(clip);
			clips.RemoveAt(index);

			yield return new WaitForSeconds(clip.length + Random.Range(min, max));
		}
	}
}
