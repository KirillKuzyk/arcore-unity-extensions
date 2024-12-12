#if UNITY_EDITOR
using System;
using Google.XR.ARCoreExtensions.Internal;
using JetBrains.Annotations;
using UnityEngine;
#endif
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("ARFoundationRemote.Runtime")]
[assembly: InternalsVisibleTo("ARFoundationRemote.RuntimeEditor")]

#if UNITY_EDITOR
namespace Google.XR.ARCoreExtensions {
    internal interface IARCoreCloudAnchors {
        IntPtr HostCloudAnchor(IntPtr sessionHandle, IntPtr anchorHandle, int? ttlDays);
        Pose GetAnchorPose(IntPtr sessionHandle, IntPtr anchorHandle);
        CloudAnchorState GetCloudAnchorState(IntPtr sessionHandle, IntPtr anchorHandle);
        string GetCloudAnchorId(IntPtr sessionHandle, IntPtr anchorHandle);
        ApiTrackingState GetTrackingState(IntPtr sessionHandle, IntPtr anchorHandle);
        FeatureMapQuality EstimateFeatureMapQualityForHosting(IntPtr sessionHandle, Pose sessionRelativePose);
        void SetAuthToken(IntPtr sessionHandle, string authToken);
        IntPtr ResolveCloudAnchor(IntPtr sessionHandle, string cloudAnchorId);
    }

    internal static class ARCoreCloudAnchorsEditorDelegate {
        static IARCoreCloudAnchors _instance;
        public static readonly IntPtr dummySessionPtr = new IntPtr(340934763);
        public static readonly IntPtr dummyFramePtr = new IntPtr(797718823);


        public static IARCoreCloudAnchors Instance {
            get {
                if (_instance == null) {
                    throw new Exception("To test the ARCore Cloud Anchors API in Editor, please install the AR Foundation Remote 2.0 or newer:\n" +
                                   "https://assetstore.unity.com/packages/slug/201106");
                }

                return _instance;
            }
        }

        public static void SetDelegate([NotNull] IARCoreCloudAnchors del) {
            _instance = del;
        }
    }
}
#endif
