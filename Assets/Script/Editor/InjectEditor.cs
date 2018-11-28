using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
public class InjectEditor : Editor
{
    [MenuItem("Tools/Inject")]
    static void InjectVariable()
    {
        Debug.Log("Inject ");
        GameObject[] objs = FindObjectsOfType<GameObject>();
        for (int i = 0; i < objs.Length; i++)
        {
            UIBase uibase = objs[i].GetComponent<UIBase>();
            if (uibase != null)
            {
                uibase.Inject();
                PrefabType t_type = PrefabUtility.GetPrefabType(objs[i]);
                if (t_type == PrefabType.PrefabInstance)
                {
                    //Debug.LogError("prefab "+objs[i].name);
                    PrefabUtility.ReplacePrefab(objs[i], PrefabUtility.GetPrefabParent(objs[i]));
                }
            }
        }
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
    }
}
