
using Tolian.Runtime.Systems.DebuggerSystem;
using UnityEngine;

namespace Tolian.Runtime.Systems.SaveDomain
{
    /// <summary>
    /// This class handles all save/load systems with one single class which is named as "SaveState".
    /// This class can be extended by adding more security.
    /// This class is using Easy Save System 3 as provider. It can be replaced by other systems.
    ///
    /// Tip: Please do not use constructor is "SaveSystem". It causes some errors.
    /// </summary>
    public class SaveSystem : MonoBehaviour
    {
        #region Fields
        public SaveState SaveState = new SaveState();
        private const string _firstSaveCompletedString = "FirstSaveCompleted";
        #endregion
    
        private void Start()
        {
            Load();
        }
        
        /// <summary>
        /// Save the current state of SAVESTATE
        /// </summary>
        public void Save()
        {
            ES3.Save(_firstSaveCompletedString, true); // Save the "first Save"
            ES3.Save("state", SaveState); // Save the "State"

            ManagerDebugger.Log("The game session saved successfully", gameObject);
        }
        
        /// <summary>
        /// Load and Update the SAVESTATE
        /// </summary>
        public void Load()
        {
            bool isExist = ES3.KeyExists(_firstSaveCompletedString);
            if (!isExist)
            {
                SaveState = new SaveState();
                SaveState.SetInitialValues();
                Save();

                ManagerDebugger.Log("The inital data created successfully", gameObject);
            }
            else if(isExist)
            {
                SaveState = ES3.Load("state", new SaveState());

                ManagerDebugger.Log("The saved data loaded successfully", gameObject);
            }
   
        }
    }
}

