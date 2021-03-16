using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    private string _gameId = "3919149";
    private bool _isTest = false;
    private float _delay = 0.2f;
    private string _banner = "MainBanner";

    private void Start()
    {
        Advertisement.Initialize(_gameId, _isTest);
        StartCoroutine(ShowBannerWhenReady());
    }

    private IEnumerator ShowBannerWhenReady()
    {
        var wait = new WaitForSeconds(_delay);

        while (!Advertisement.IsReady(_banner))
        {
            yield return wait;
        }
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(_banner);
    }
}
