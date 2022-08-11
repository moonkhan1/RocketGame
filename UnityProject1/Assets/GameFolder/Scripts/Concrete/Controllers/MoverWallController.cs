using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Abstracts.Controllers;


namespace UnityProject1.Controllers{
public class MoverWallController : WallControllers
{
    // Hereketli divar verilen araliq arasinda gedib gelmelidi
    [SerializeField] Vector3 _direction;
    // [Range(0f, 1f)]
    [SerializeField] float _factor;
    [SerializeField] float _speed = 1f;

    Vector3 _startPosition;
    private const float FULL_CIRCLE = Mathf.PI * 2f;

    private void Awake() {
        _startPosition = transform.position;
    }
    private void Update() {
        // Divarin hereket suretini tenzimlemek ucun
        float cycle = Time.time / _speed;
        float sinWave = Mathf.Sin(cycle * FULL_CIRCLE);
        // Mover Divarin hereketi
        _factor = Mathf.Abs(sinWave); // BU 0 ile 1 arasinda range yaradir. Menfi olmamasi ucun Absolute metodundan isdifade edirik
        Vector3 offset = _direction * _factor;
        transform.position = offset + _startPosition;
    }
    
}
}
