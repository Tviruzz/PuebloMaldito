using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateFolderStructure : MonoBehaviour
{
    [MenuItem("Herramientas/Estructura/Crear estructura de carpetas")]
    public static void CreateFolders()
    {
        string[] folders = new string[]
        {
            "Assets/_Developer/Isaac",
            "Assets/Animations",
            "Assets/Audio/Music",
            "Assets/Audio/SoundEffects",
            "Assets/Editor",
            "Assets/Materials",
            "Assets/Models",
            "Assets/PhysicsMaterials",
            "Assets/Plugins",
            "Assets/Prefabs/UI",
            "Assets/Prefabs/Enemies",
            "Assets/Prefabs/Items",
            "Assets/Resources",
            "Assets/Scenes",
            "Assets/Scripts",
            "Assets/Shaders",
            "Assets/Sprites",
            "Assets/Textures",
            "Assets/XternalAssets"
        };

        foreach (string folder in folders)
        {
            string[] parts = folder.Split('/');
            string currentPath = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                string nextPath = currentPath + "/" + parts[i];
                if (!AssetDatabase.IsValidFolder(nextPath))
                {
                    AssetDatabase.CreateFolder(currentPath, parts[i]);
                }
                currentPath = nextPath;
            }

            // Crear .gitkeep en la carpeta final
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), folder);
            string gitkeepPath = Path.Combine(fullPath, ".gitkeep");

            if (!File.Exists(gitkeepPath))
            {
                File.WriteAllText(gitkeepPath, ""); // archivo vacío
            }
        }

        AssetDatabase.Refresh();
        Debug.Log("✅ Estructura de carpetas creada correctamente.");
    }
}
