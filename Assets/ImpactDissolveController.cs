using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ImpactDissolveController : MonoBehaviour
{
private Material material;

private Vector3 hitPoint;
private float radius = 0f;
private bool dissolving = false;

public float dissolveSpeed = 3f;

void Start()
{
material = GetComponent<Renderer>().material;
}

void Update()
{
if (!dissolving) return;

radius += dissolveSpeed * Time.deltaTime;

material.SetVector("_HitPoint", hitPoint);
material.SetFloat("_HitRadius", radius);
material.SetFloat("_Feather", 1f);
}

public void StartDissolve(Vector3 point)
{
hitPoint = point;
radius = 0;
dissolving = true;
}
}

