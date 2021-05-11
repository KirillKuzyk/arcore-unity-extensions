#if UNITY_EDITOR
using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.ARSubsystems;


namespace Google.XR.ARCoreExtensions {
    public interface IARCoreCloudAnchors {
        IntPtr HostCloudAnchor(IntPtr sessionHandle, IntPtr anchorHandle, int? ttlDays);
        Pose GetAnchorPose(IntPtr sessionHandle, IntPtr anchorHandle);
        CloudAnchorState GetCloudAnchorState(IntPtr sessionHandle, IntPtr anchorHandle);
        string GetCloudAnchorId(IntPtr sessionHandle, IntPtr anchorHandle);
        TrackingState GetTrackingState(IntPtr sessionHandle, IntPtr anchorHandle);
        FeatureMapQuality EstimateFeatureMapQualityForHosting(IntPtr sessionHandle, Pose pose);
        void SetAuthToken(IntPtr sessionHandle, string authToken);
        IntPtr ResolveCloudAnchor(IntPtr sessionHandle, string cloudAnchorId);
    }

    public static class ARCoreCloudAnchorsEditorDelegate {
        static IARCoreCloudAnchors _instance;
        public static readonly IntPtr dummySessionPtr = new IntPtr(340934763);
        public static readonly IntPtr dummyFramePtr = new IntPtr(797718823);


        public static IARCoreCloudAnchors Instance {
            get {
                if (_instance == null) {
                    throw new Exception("To test the ARCore Cloud Anchors API in Editor, please install the AR Foundation Editor Remote plugin version 4.12.0 or newer:\n" +
                                   "https://assetstore.unity.com/packages/tools/utilities/ar-foundation-editor-remote-168773"); // todo update link
                }

                return _instance;
            }
        }

        public static void SetDelegate([NotNull] IARCoreCloudAnchors del) {
            Assert.IsNull(_instance);
            _instance = del;
        }
    }
}
#endif
