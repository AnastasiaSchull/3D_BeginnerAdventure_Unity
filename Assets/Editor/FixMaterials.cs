
using UnityEngine;
using UnityEditor;

public class FixMaterials : MonoBehaviour
{
    [MenuItem("Tools/Reset Materials to Standard")]
    static void ResetMaterials()
    {
        // Восстановление всех материалов
        string[] guids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && mat.shader.name.Contains("HDRP"))
            {
                mat.shader = Shader.Find("Standard");
            }
        }

        // Восстановление слоёв Terrain
        Terrain[] terrains = FindObjectsOfType<Terrain>();
        foreach (Terrain terrain in terrains)
        {
            if (terrain.terrainData != null)
            {
                Debug.Log($"Processing Terrain: {terrain.name}");

                foreach (TerrainLayer layer in terrain.terrainData.terrainLayers)
                {
                    if (layer != null)
                    {
                        Debug.Log($"Restoring layer: {layer.name}");

                        // Проверка текстур слоя
                        if (layer.diffuseTexture == null)
                        {
                            Debug.LogWarning($"Layer {layer.name} is missing a diffuse texture!");
                        }
                    }
                }
            }
        }

        Debug.Log("All HDRP materials and terrain layers checked for restoration.");
    }
}

