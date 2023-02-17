using Assets.Scripts.SavingSystem.Surrogats;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.SavingSystem
{
    public class Storage
    {
        private string filePath;
        private BinaryFormatter formatter;

        public Storage()
        {
            var directory = Application.persistentDataPath + "/saves";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            filePath = directory + "/GameSave.save";
            InitializeBinaryFormatter();
        }

        private void InitializeBinaryFormatter()
        {
            formatter = new BinaryFormatter();
            var selector = new SurrogateSelector();

            var v3Surrogate = new Vector3SerializationSurrogate();
            var qSurrogate = new QuaternionSerializationSurrogate();

            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3Surrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qSurrogate);

            formatter.SurrogateSelector = selector;
        }

        public object Load(object saveDataByDefault)
        {
            if (!File.Exists(filePath))
            {
                if (saveDataByDefault != null) 
                {
                    Save(saveDataByDefault);
                    return saveDataByDefault;
                }
            }

            var file = File.Open(filePath, FileMode.Open);
            var savedData = formatter.Deserialize(file);
            file.Close();
            return savedData;
        }

        public void Save(object saveData)
        {
            var file = File.Create(filePath);
            formatter.Serialize(file, saveData);
            file.Close();
        }
    }
}

