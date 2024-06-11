using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PanelScoreBinary : MonoBehaviour
{
    private Studentabc student;
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/student.dat";
        Load();
    }

    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, student);
        file.Flush();
        file.Close();
    }

    private void Load()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            student = (Studentabc)bf.Deserialize(file);
            file.Close();
            return;
        }
        student = new Studentabc("", "", 33);
        Save();
    }

}

[System.Serializable]
public class Studentabc
{
    public string StudentName;
    public string Class;
    public int Age;

    public Studentabc(string studentName, string Class, int age)
    {
        StudentName = studentName;
        this.Class = Class;
        Age = age;
    }
}