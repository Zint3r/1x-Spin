using UnityEngine;
using Firebase.Analytics;
using Firebase;
using Firebase.Extensions;
public class FBAnalyticsScript : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }
    void Update()
    {

    }
}