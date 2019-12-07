﻿using System;
using System.Collections;
using UnityEngine;

namespace GlobalSnowEffect {

    [ExecuteInEditMode]
    public class GlobalSnowIgnoreCoverage : MonoBehaviour {

        [SerializeField]
        [Tooltip("If this gameobject or any of its children can receive snow.")]
        bool _receiveSnow;

        public bool receiveSnow {
            get { return _receiveSnow;  }
            set { if (_receiveSnow != value) { _receiveSnow = value; if (snow != null) snow.RefreshExcludedObjects(); } }
        }

        [SerializeField]
        [Tooltip("If this gameobject or any of its children block snow down.")]
        bool _blockSnow;

        public bool blockSnow {
            get { return _blockSnow; }
            set { _blockSnow = value; }
        }

        [NonSerialized]
        public int layer;

        [NonSerialized]
        public Renderer[] renderers;

        GlobalSnow snow;

        void OnEnable() {
            renderers = GetComponentsInChildren<Renderer>(true);
            snow = GlobalSnow.instance;
            if (snow != null) {
                snow.IgnoreGameObject(this);
            }
        }

        void Start() {
            if (Application.isPlaying && snow == null) {
                snow = GlobalSnow.instance;
                if (snow != null) {
                    snow.IgnoreGameObject(this);
                } else {
                    StartCoroutine(DelayIgnoreObject());
                }
            }
        }

        IEnumerator DelayIgnoreObject() {
            WaitForEndOfFrame w = new WaitForEndOfFrame();
            while (snow == null) {
                snow = GlobalSnow.instance;
                yield return w;
            }
            snow.IgnoreGameObject(this);
        }


        private void OnDisable() {
            if (snow != null)
                snow.UseGameObject(this);
        }



    }
}