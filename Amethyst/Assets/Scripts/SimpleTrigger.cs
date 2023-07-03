using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger: MonoBehaviour {
  public bool IsColliding => Collisions.Count > 0;
  public List<Collider2D> Collisions = new List<Collider2D>();

  void OnTriggerEnter2D(Collider2D other) {
    Collisions.Add(other);
  }

  void OnTriggerExit2D(Collider2D other) {
    Collisions.Remove(other);
  }
}
