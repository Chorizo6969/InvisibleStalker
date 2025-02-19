using System.Collections;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Sound : MonoBehaviour
{
    [SerializeField] private int _delayBeforeMakeASound;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clipRire;
    [SerializeField] private AI_StateMachine _stateMachine;

    private void Start()
    {
        StartCoroutine(Temps());
    }

    IEnumerator Temps()
    {
        yield return new WaitForSeconds(_delayBeforeMakeASound);
        while (true)
        {
            if (!_source.isPlaying)
            {
                print("rire");
                yield return new WaitForSeconds(_delayBeforeMakeASound);
                _source.outputAudioMixerGroup = null;
                _source.volume = 0.5f;
                _source.PlayOneShot(_clipRire);
            }
            else
            {
                print("y'a un son");
                yield return new WaitForSeconds(_delayBeforeMakeASound);
            }
        }
    }
}
