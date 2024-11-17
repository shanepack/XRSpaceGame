using UnityEngine;

public class FresnelShaderApplier : MonoBehaviour
{
    public Shader fresnelShader; // The shader for the Fresnel effect
    public Color glowColor = Color.cyan; // The color of the Fresnel effect
    public float glowIntensity = 2f; // How bright the Fresnel glow should be
    public float fresnelPower = 2f; // Controls the sharpness of the Fresnel effect

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && fresnelShader != null)
        {
            // Get the original material
            Material originalMaterial = renderer.material;

            // Create a new material based on the original material
            Material fresnelMaterial = new Material(fresnelShader);

            // Copy the base texture and properties to the new Fresnel material
            if (originalMaterial.HasProperty("_MainTex"))
                fresnelMaterial.SetTexture("_MainTex", originalMaterial.GetTexture("_MainTex"));
            if (originalMaterial.HasProperty("_Color"))
                fresnelMaterial.SetColor("_Color", originalMaterial.GetColor("_Color"));

            // Set the Fresnel-specific properties
            fresnelMaterial.SetColor("_GlowColor", glowColor);
            fresnelMaterial.SetFloat("_GlowIntensity", glowIntensity);
            fresnelMaterial.SetFloat("_FresnelPower", fresnelPower);

            // Assign both the original and Fresnel materials to the renderer
            Material[] materials = new Material[2];
            materials[0] = originalMaterial; // Original material
            materials[1] = fresnelMaterial;  // Fresnel overlay material

            renderer.materials = materials;
        }
    }
}
