using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(SurvivorData))]
public class SurvivorDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SurvivorData survivorData = (SurvivorData)target; EditorGUILayout.LabelField("Talking Head Icon", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        survivorData.TalkingHeadIcon = (Image)EditorGUILayout.ObjectField("Image", survivorData.TalkingHeadIcon, typeof(Image), false);

        Rect iconRect = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight * 3); // Adjust the size as needed
        if (survivorData.TalkingHeadIcon != null && survivorData.TalkingHeadIcon.sprite != null)
        {
            Texture2D iconTexture = survivorData.TalkingHeadIcon.sprite.texture;
            EditorGUI.DrawPreviewTexture(iconRect, iconTexture, null, ScaleMode.ScaleToFit);
        }
        else
        {
            EditorGUI.LabelField(iconRect, "No Image");
        }

        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        survivorData.Name = EditorGUILayout.TextField("Name", survivorData.Name);
        survivorData.StartingWeapon = (GameObject)EditorGUILayout.ObjectField("Starting Weapon", survivorData.StartingWeapon, typeof(GameObject), false);

        EditorGUILayout.LabelField("Enemy", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        survivorData.Target = (Enemy)EditorGUILayout.ObjectField("Target", survivorData.Target, typeof(Enemy), false);

        EditorGUI.indentLevel--;
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Damage", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        survivorData.DamageModifier = EditorGUILayout.FloatField("Damage Modifier", survivorData.DamageModifier);
        survivorData.Damage = EditorGUILayout.FloatField("Damage", survivorData.Damage);
        survivorData.Range = EditorGUILayout.FloatField("Range", survivorData.Range);

        EditorGUI.indentLevel--;
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Shot Speed", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        survivorData.ShotSpeedMultiplier = EditorGUILayout.FloatField("Shot Speed Multiplier", survivorData.ShotSpeedMultiplier);
        survivorData.ShotSpeed = EditorGUILayout.FloatField("Shot Speed", survivorData.ShotSpeed);

        EditorGUI.indentLevel--;

        EditorGUILayout.Space();
    }
}
