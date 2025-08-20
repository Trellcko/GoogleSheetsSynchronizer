#if ODIN_INSPECTOR
using System.Linq;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Trellcko.GoogleSheetsSynchronizer.Editor
{
    public class GoogleSheetSynchronizeWindow : OdinMenuEditorWindow
    {
        private SynchronizedData[] _foundSo;
        private Vector2 _scroll;
        private readonly IGoogleSheetsSynchronizer _googleSheetsSynchronizer = new GoogleSheetsSynchronizer();

        [MenuItem("Tools/Google Sheets Synchronizer")]
        private static void OpenWindow()
        {
            GoogleSheetSynchronizeWindow window = GetWindow<GoogleSheetSynchronizeWindow>();
            window.titleContent = new("Google Sheets Synchronizer");
            window.Show();
        }
    

         protected override void OnBeginDrawEditors()
         {
             OdinMenuTreeSelection selection = MenuTree.Selection;

             SirenixEditorGUI.BeginHorizontalToolbar();
             {
                 GUILayout.FlexibleSpace();
                 SynchronizeAllButton();
                 SynchronizeCurrentButton(selection);
             }
             SirenixEditorGUI.EndHorizontalToolbar();
         }

         private void SynchronizeCurrentButton(OdinMenuTreeSelection selection)
         {
             if (SirenixEditorGUI.ToolbarButton(new GUIContent("Synchronize Current")))
             {
                 SynchronizedData synchronizedData = selection.SelectedValue as SynchronizedData;
                 _googleSheetsSynchronizer.Synchronize(synchronizedData);
                     
             }
         }

         private void SynchronizeAllButton()
         {
             if (SirenixEditorGUI.ToolbarButton(new GUIContent("Synchronize All")))
             {
                 foreach (SynchronizedData synchronizedData in _foundSo)
                 {
                     _googleSheetsSynchronizer.Synchronize(synchronizedData);
                 }
             }
         }

         private void FindAllSOs()
        {
            string[] guids = AssetDatabase.FindAssets("t:SynchronizedData");
            _foundSo = guids
                .Select(guid => AssetDatabase.LoadAssetAtPath<SynchronizedData>(AssetDatabase.GUIDToAssetPath(guid)))
                .Where(obj => obj)
                .ToArray();
           
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            FindAllSOs();
            OdinMenuTree tree = new();
            tree.AddRange(_foundSo, x => x.name);
            return tree;
        }
    }
}
#endif