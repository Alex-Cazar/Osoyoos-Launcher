﻿using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ToolkitLauncher.Utility
{
    public class ManagedBlam
    {
        public static void RunMBBitmaps(string ek_path, string tag_path, string tags_folder_path, string compression_type)
        {
            string exe_path = Path.Combine(ek_path, @"bin\OsoyoosMB.exe");

            if (File.Exists(exe_path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = exe_path,
                    Arguments = $"getbitmapdata \"{ek_path}\" \"{tag_path.TrimEnd('\\')}\" \"{tags_folder_path}\" \"{compression_type}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                try
                {
                    // Start the process
                    using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();
                    }
                }
                catch
                {
                    // Handle any errors that might occur
                    MessageBox.Show("Unspecified ManagedBlam error.\nBitmaps will still be imported, but settings will not be applied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // User likely hasnt put the second exe in the right place
                MessageBox.Show($"Error: Cannot find \"{exe_path}\".\nMake sure the OsoyoosMB.exe is in your editing kit's \"bin\" folder.\nBitmaps will still be imported, but settings will not be applied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
