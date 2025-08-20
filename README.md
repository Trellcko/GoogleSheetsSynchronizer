# Google Sheets Synchronizer

A Unity editor extension for synchronizing data from **Google Sheets** directly into your project.  
Built with [Odin Inspector](https://odininspector.com/) for a clean and powerful editor UI and [UniTask](https://github.com/Cysharp/UniTask) for modern async operations.

---

## ✨ Features
- Download CSV data directly from **Google Sheets**.
- View and manage synchronized data inside a custom **Odin Editor Window**.
- Async operations powered by **UniTask** (no coroutines needed).
- Built-in error handling for network requests.

---

## 📦 Requirements
- **Unity** 2021.3 or newer (tested).
- [Odin Inspector](https://odininspector.com/) – required for editor UI.
- [UniTask](https://github.com/Cysharp/UniTask) – required for async/await support.

> ⚠️ If Odin Inspector is not installed, the editor window will not be available, but synchronization can work.
>
## 🚀 Usage

- Create a class that inherits from SynchronizedData.

Example:

```csharp
using UnityEngine;

namespace Trellcko.GoogleSheetsSynchronizer
{
    [CreateAssetMenu(fileName = "TestSyncData", menuName = "Scriptable Objects/TestSyncData")]
    public class TestSyncData : SynchronizedData
    {
        public float Lalala;
    }
}
```
- Now you need create a Sheet names of the fields and names of the first rows have to be the same

<img width="508" height="289" alt="image" src="https://github.com/user-attachments/assets/e7079a55-bb12-4702-9c51-aa5d0d0d3578" />

- Publish the sheet
  
<img width="799" height="257" alt="image" src="https://github.com/user-attachments/assets/eddd2272-e31f-4479-bbbb-03955a5d008a" />

- Copy ID of the sheet and paste it into the data
  
<img width="1296" height="50" alt="image" src="https://github.com/user-attachments/assets/1b595adc-fbab-4e1f-b041-127d30d536e1" />

<img width="1030" height="208" alt="image" src="https://github.com/user-attachments/assets/0e32e656-3772-4ff4-83d7-ac525ee982ed" />

- If you have Odin Inspector you can use Editor for better experience

<img width="928" height="1005" alt="image" src="https://github.com/user-attachments/assets/e172a818-7ca4-4915-a8c2-56331216feb3" />

- If you don't have you can use GoogleSheetsSynchronizer

```csharp
    public class TestScript : MonoBehaviour
    {
        private IGoogleSheetsSynchronizer _synchronizer = new GoogleSheetsSynchronizer();
        private SynchronizedData[] _data;

        private void Start()
        {
            foreach(var data in _data)
            {
                _synchronizer.Synchronize(data);
            }
        }
        
    }
```
