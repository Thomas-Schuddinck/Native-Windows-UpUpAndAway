using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace UpUpAndAwayApp.Utils
{
    public class MediaPlayerTool
    {
        public static async void PlayDefaultMediaFile()
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/" + "Video.mp4"));

            if (file == null)
                return;

            // Set the option to show the picker
            var options = new Windows.System.LauncherOptions
            {
                DisplayApplicationPicker = false
            };

            // Launch the retrieved file
            bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
            Debug.WriteLine(success);
        }
    }
}
