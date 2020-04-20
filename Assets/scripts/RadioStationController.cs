using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class RadioStationController: MonoBehaviour
{
    [SerializeField]
    private AudioMixerSnapshot searchSnapshot;
    [SerializeField]
    private AudioMixerSnapshot staticSnapshot;
    [SerializeField]
    private AudioMixerSnapshot[] stationSnapshots;
    [SerializeField]
    private float transitionTime = 1f;
    [SerializeField]
    private float searchTime = 1f;
    [SerializeField]
    private int currentStationIndex = 0;
    private bool settled = true;

    void Start()
    {
        SetStation(currentStationIndex);
    }

    private IEnumerator ChangeStationRoutine(int stationIndex)
    {
        if (!settled) yield break;
        settled = false;
        stationIndex = stationIndex % stationSnapshots.Length;
        
        searchSnapshot.TransitionTo(transitionTime);
        yield return new WaitForSeconds(transitionTime);

        yield return new WaitForSeconds(searchTime);

        stationSnapshots[stationIndex].TransitionTo(transitionTime);
        yield return new WaitForSeconds(transitionTime);

        settled = true;
    }

    public void SetStation(int stationIndex)
    {
        StartCoroutine(ChangeStationRoutine(stationIndex));
    }

    public void NextStation()
    {
        currentStationIndex++;
        SetStation(currentStationIndex);
    }
}
