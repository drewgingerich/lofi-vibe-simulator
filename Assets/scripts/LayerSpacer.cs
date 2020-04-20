using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class LayerSpacer: MonoBehaviour
{
    [SerializeField]
    private float spacing = 1;

    void Update()
    {
        var layers = transform.Cast<Transform>().ToList();
        var startZ = transform.localPosition.z;
        for (var i = 0; i < layers.Count; i++ ) {
            var layer = layers[i];
            var layerDepth = startZ + (spacing * i);
            var layerPosition = layer.transform.position;
            layerPosition.z = layerDepth;
            layer.transform.position = layerPosition;
        };
    }
}
