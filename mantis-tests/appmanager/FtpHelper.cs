using System;
using System.IO;
using System.Net.FtpClient;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;

        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient
            {
                Credentials = new System.Net.NetworkCredential("mantis", "mantis")
            };
            client.Host = "localhost";
            client.Connect();
        }

        public void BackupFile(String path)
        {
            String backupPath = path + ".bak";
            if (client.FileExists(backupPath))
            {
                return;
            }
            client.Rename(path, backupPath);
        }

        public void RestoreBackUpFile(String path)
        {
            String backupPath = path + ".bak";
            if (! client.FileExists(backupPath))
            {
                return;
            }
            if (client.FileExists(backupPath))
            {
                client.DeleteFile(path);
            }
            client.Rename(backupPath, path);
        }

        public void UploadFile(String path, Stream localfile )
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }

            using (Stream ftpstream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localfile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpstream.Write(buffer, 0, count);
                    count = localfile.Read(buffer, 0, buffer.Length);
                }
            }
        }

    }
}
