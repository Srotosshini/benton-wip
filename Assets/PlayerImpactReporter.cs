using UnityEngine;

public class PlayerImpactReporter : MonoBehaviour
{
private void OnControllerColliderHit(ControllerColliderHit hit)
{
ImpactDissolveController dissolve =
hit.collider.GetComponent<ImpactDissolveController>();

if (dissolve != null)
{
dissolve.StartDissolve(hit.point);
}
}
}
