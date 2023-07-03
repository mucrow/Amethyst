using UnityEngine;

public class Camera: MonoBehaviour {
  public Transform Target;

  void Update() {
    if (Target) {
      var newPosition = Target.position;
      newPosition.z = -10f;
      transform.position = newPosition;
    }
  }
}
