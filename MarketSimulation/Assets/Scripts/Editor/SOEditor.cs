using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SOEditor))]
public class SOEditor : EditorWindow
{
    public int id;
    [Space]
    public int priceOpt;
    [Space]
    public string name;
    [Space]
    public Sprite icon;
    [Space]
    public TypeItem typeItem;
    [Space]
    public bool stackable;

    [MenuItem("Tools/Create Item")]
    public static void ShowWindow()
    {
        // Убедитесь, что здесь нет ошибок и эта строка правильная
        GetWindow<SOEditor>("Create MyData");
    }

    private void OnGUI()
    {
        GUILayout.Label("Создание нового Item", EditorStyles.boldLabel);

        name = EditorGUILayout.TextField("Название", name);
        priceOpt = EditorGUILayout.IntField("Стоимость закупки", priceOpt);
        id = EditorGUILayout.IntField("id", id);
        icon = (Sprite)EditorGUILayout.ObjectField("Иконка", icon, typeof(Sprite), false);
        typeItem = (TypeItem)EditorGUILayout.EnumFlagsField("Что это", typeItem);
        stackable = EditorGUILayout.Toggle("Возможность стакать", stackable);

        if (GUILayout.Button("Создать"))
        {
            CreateMyData();
        }
    }

    private void CreateMyData()
    {
        string path = "Assets/Scripts/ScriptbleObject/" + name + ".asset";

        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem._name = name;
        newItem._priceOpt = priceOpt;
        newItem._id = id;
        newItem._icon = icon;
        newItem._typeItem = typeItem;
        newItem._stackable = stackable;

        AssetDatabase.CreateAsset(newItem, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newItem;
    }


}
