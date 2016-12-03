using UnityEngine;
using System.Collections;

public interface IKnockbackable {
    void Knockback(float knockSourceX, int knockForce);
}