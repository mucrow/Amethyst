using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformingCollisionDetector: MonoBehaviour {
  [SerializeField] SimpleTrigger _downTrigger;
  [SerializeField] SimpleTrigger _strictDownTrigger;
  [SerializeField] SimpleTrigger _upTrigger;
  [SerializeField] SimpleTrigger _strictUpTrigger;
  [SerializeField] SimpleTrigger _leftTrigger;
  [SerializeField] SimpleTrigger _strictLeftTrigger;
  [SerializeField] SimpleTrigger _rightTrigger;
  [SerializeField] SimpleTrigger _strictRightTrigger;

  public bool IsOnGround() {
    if (_strictDownTrigger.IsColliding) {
      return true;
    }
    if (_downTrigger.IsColliding && !_leftTrigger.IsColliding && !_rightTrigger.IsColliding) {
      return true;
    }
    return false;
  }
}
