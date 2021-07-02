using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private string playStoreID = "3983333";
    private string appStoreID = "3983332";

    private string interstitialAd = "video";

    public bool isTargetPlayStore;
    public bool isTestAd;

    // Start is called before the first frame update
    void Start()
    {
        IntializeAdvertisement();
    }

    private void IntializeAdvertisement()
    {
        if (isTargetPlayStore) { Advertisement.Initialize(playStoreID, isTestAd); return; }
        Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstilitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd)) { return; }
        Advertisement.Show(interstitialAd);
    }

}
