using UnityEngine;

public static class Rigidbody2DExt
{

    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Impulse)
    {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;
        Debug.Log("---");
        Debug.Log(rb.position);
        Debug.Log(explosionPosition);
        Debug.Log(explosionDir);
        Debug.Log(explosionDistance);
        Debug.Log(explosionForce);
        Debug.Log(explosionRadius);
        Debug.Log(Mathf.Lerp(0, explosionForce, Mathf.Max(0, (explosionRadius - explosionDistance))) * explosionDir);


        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else
        {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        rb.AddForce(Mathf.Lerp(0, explosionForce, Mathf.Max(0, (explosionRadius - explosionDistance))) * explosionDir, mode);
        
    }
}