using UnityEngine;

public class InclusionGPUInstansing : MonoBehaviour
{
    private void Awake()
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        if (meshRenderer != null)
            meshRenderer.SetPropertyBlock(materialPropertyBlock);
        else
            skinnedMeshRenderer.SetPropertyBlock(materialPropertyBlock);

    }
}
