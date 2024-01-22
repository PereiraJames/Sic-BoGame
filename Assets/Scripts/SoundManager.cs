using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundEffectSource;
    public AudioSource musicSource;

    public AudioClip PokerChip;
    public AudioClip DiceShuffle;

    void Awake()
    {
        // Ensure only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PokerChipSound()
    {
        soundEffectSource.PlayOneShot(PokerChip);
    }

    public void DiceShuffleSound()
    {
        soundEffectSource.PlayOneShot(DiceShuffle);
    }
}
