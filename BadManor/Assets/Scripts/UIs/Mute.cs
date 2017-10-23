using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
  public class Mute : MonoBehaviour
  {
    public Button MuteButton;
    public Image mute;
    public Image notmute;
    private SoundManager _soundManager = null;
    private float storedBgmVolume = 0;
    private float storedAudioVolume = 0;
        
        
    private bool muted = false;

    private void Awake()
    {
      _soundManager = FindObjectOfType<SoundManager>();
    }

    public Mute()
    {
      mute.gameObject.SetActive(false);
      notmute.gameObject.SetActive(true);
      _soundManager.setSoundVolume(1);
      _soundManager.setBgmVolume(1);
    }

    public void SwitchMute()
    {
      if (muted)
      {
        _soundManager.setSoundVolume(storedAudioVolume);
        _soundManager.setBgmVolume(storedBgmVolume);
        mute.gameObject.SetActive(true);
        notmute.gameObject.SetActive(false);
      }
      else
      {
        storedBgmVolume = _soundManager.BgmVolume;
        storedAudioVolume = _soundManager.SoundVolume;
        _soundManager.setSoundVolume(0);
        _soundManager.setBgmVolume(0);
        mute.gameObject.SetActive(false);
        notmute.gameObject.SetActive(true);
      }
      muted = !muted;
    }
  }
}