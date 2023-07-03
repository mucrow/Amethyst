using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
  [SerializeField] SimpleTrigger _onGroundTrigger;
  [SerializeField] float _jumpVelocity = 10f;
  [SerializeField] float _maxFallSpeed = 10f;
  [SerializeField] float _runSpeed = 6f;

  bool _jumpInput = false;
  Rigidbody2D _rigidbody2D;
  float _runInput = 0f;
  Vector2 _velocity = Vector2.zero;

  void Awake() {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  void Update() {
    _jumpInput = Input.GetKey(KeyCode.Space);

    _runInput = 0f;
    if (Input.GetKey(KeyCode.A)) {
      _runInput -= 1f;
    }
    if (Input.GetKey(KeyCode.D)) {
      _runInput += 1f;
    }
  }

  void FixedUpdate() {
    // _velocity.x = _runInput * _runSpeed;
    //
    // if (_onGroundTrigger.IsColliding) {
    //   if (_jumpInput) {
    //     _velocity.y = _jumpVelocity;
    //   }
    //   else {
    //     _velocity.y = 0f;
    //   }
    // }
    // else {
    //   _velocity.y = Math.Max(-1f * _maxFallSpeed, _velocity.y - Time.fixedDeltaTime * 30.0f);
    // }
    //
    // _rigidbody2D.velocity = _velocity;
  }
}
