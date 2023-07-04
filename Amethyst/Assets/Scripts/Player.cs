using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player: MonoBehaviour {
  [SerializeField] PlatformingCollisionDetector _platformingCollisionDetector;
  [SerializeField] float _jumpVelocity = 15f;

  [SerializeField] float _slowFallAcceleration = 30f;
  [SerializeField] float _maxSlowFallSpeed = 10f;

  [SerializeField] float _fastFallSpeed = 30f;

  [SerializeField] float _runSpeed = 6f;

  bool _isJumping = false;
  bool _jumpInputHeld = false;
  Rigidbody2D _rigidbody2D;
  float _runInput = 0f;
  Vector2 _velocity = Vector2.zero;

  void Awake() {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  void Update() {
    _jumpInputHeld = Input.GetKey(KeyCode.Space);

    _runInput = 0f;
    if (Input.GetKey(KeyCode.A)) {
      _runInput -= 1f;
    }
    if (Input.GetKey(KeyCode.D)) {
      _runInput += 1f;
    }
  }

  void FixedUpdate() {
    // simple as
    _velocity.x = _runInput * _runSpeed;

    if (_platformingCollisionDetector.IsOnGround()) {
      // on ground + jump input
      if (_jumpInputHeld) {
        _velocity.y = _jumpVelocity;
        _isJumping = true;
      }
      // just on ground
      else {
        _velocity.y = 0f;
        _isJumping = false;
      }
    }
    else {
      // in air + jump input not held
      if (_isJumping && !_jumpInputHeld) {
        _velocity.y = 0f;
        _isJumping = false;
      }
      // in air + jump input held
      else {
        _velocity.y = Math.Max(-1f * _maxSlowFallSpeed, _velocity.y - Time.fixedDeltaTime * _slowFallAcceleration);
        // clear _isJumping flag if velocity is less than 0
        if (_velocity.y <= 0f) {
          _isJumping = false;
        }
      }
    }

    _rigidbody2D.velocity = _velocity;
  }
}
