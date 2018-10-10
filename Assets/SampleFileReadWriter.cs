using UnityEngine;

public class SampleFileReadWriter : MonoBehaviour
{
    #region Field

    public string filePath = "C:\\";

    public string fileContent = "Sample";

    protected string result = "";

    #endregion Field

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            this.result = FileReadWriter.ReadFile(this.filePath).content;
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            this.result = FileReadWriter.WriteFile(this.filePath, this.fileContent).content;
        }
    }

    protected void OnGUI()
    {
        GUILayout.Label("Press [R] to read content from file.");
        GUILayout.Label("Press [W] to write content into file.");
        GUILayout.Label("Latest message > " + this.result);
    }
}