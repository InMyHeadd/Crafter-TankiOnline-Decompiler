using System.Mathf;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CrafterTankiOnlineDecompiller
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private static async Task CopyFileAsync(string sourceFile, string destinationFile)
        {
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
            using (var destinationStream = new FileStream(destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await sourceStream.CopyToAsync(destinationStream);
        }

        //algoritm
        private string MyLog = "";

        private void Log(string Originalfile, string DecompiledFile)
        {
            MyLog += "Decompilled:\n" + DecompiledFile + "\n\n Original:\n\n" + Originalfile + "\n\n}\n\n\n";
        }
        private async void DeFile(string path)
        {
            string[] files = Directory.GetFiles(path);


            Directory.CreateDirectory("C:\\TankiDecompiled\\models");
            Directory.CreateDirectory("C:\\TankiDecompiled\\tara");
            Directory.CreateDirectory("C:\\TankiDecompiled\\textures");
            Directory.CreateDirectory("C:\\TankiDecompiled\\swf");
            Directory.CreateDirectory("C:\\TankiDecompiled\\xml");
            Directory.CreateDirectory("C:\\TankiDecompiled\\unkown");
            Directory.CreateDirectory("C:\\TankiDecompiled\\images");
            Directory.CreateDirectory("C:\\TankiDecompiled\\TexturesToImages");
            byte[] txt = Encoding.UTF8.GetBytes(Utils.cmtc("MTA1MiwxMDg2LDEwODEsMzIsMTA3MiwxMDgzLDEwNzUsMTA4NiwxMDg4LDEwODAsMTA5MCwxMDg0LDMyLDEwNzYsMTA4MywxMTAzLDMyLDEwNzYsMTA3NywxMDgyLDEwODYsMTA4NCwxMDg3LDEwODMsMTA4MCwxMDgzLDExMDMsMTA5NCwxMDgwLDEwODAsMzIsMTA4MCwxMDg5LDEwOTMsMTA4NiwxMDc2LDEwODUsMTA4MCwxMDgyLDEwODYsMTA3NCwxMywxMCwxMDkwLDEwNzIsMTA4NSwxMDgyLDEwODYsMTA3NCwzMiwxMDg2LDEwODUsMTA4MywxMDcyLDEwODEsMTA4NSwzMiwxMDg1LDEwNzcsMzIsMTA4MCwxMDc2LDEwNzcsMTA3MiwxMDgzLDEwNzcsMTA4NSw0NCwzMiwxMTAzLDMyLDEwODcsMTA4NiwxMDg3LDEwOTksMTA5MCwxMDcyLDEwODMsMTA4OSwxMTAzLDMyLDEwNzcsMTA3NSwxMDg2LDMyLDEwODIsMTA3MiwxMDgyLDEzLDEwLDEwODQsMTA4NiwxMDc4LDEwODUsMTA4NiwzMiwxMDczLDEwODYsMTA4MywxMTAwLDEwOTYsMTA3NywzMiwxMDg2LDEwODcsMTA5MCwxMDgwLDEwODQsMTA4MCwxMDc5LDEwODAsMTA4OCwxMDg2LDEwNzQsMTA3MiwxMDkwLDExMDAsNDQsMzIsMTA4NywxMDg2LDExMDEsMTA5MCwxMDg2LDEwODQsMTA5MSwzMiwxMDc0LDMyLDEwODgsMTA3MiwxMDc5LDEwODUsMTA5OSwxMDc3LDEzLDEwLDEwODIsMTA3MiwxMDkwLDEwNzcsMTA3NSwxMDg2LDEwODgsMTA4MCwxMDgwLDMyLDEwODQsMTA4NiwxMDc1LDEwOTEsMTA5MCwzMiwxMDg3LDEwODYsMTA4NywxMDcyLDEwNzYsMTA3MiwxMDkwLDExMDAsMzIsMTA3NiwxMDg4LDEwOTEsMTA3NSwxMDgwLDEwNzcsMzIsMTA4MiwxMDcyLDEwOTAsMTA3NywxMDc1LDEwODYsMTA4OCwxMDgwLDEwODAsMTMsMTAsMTA5MiwxMDcyLDEwODEsMTA4MywxMDg2LDEwNzQsNDQsMzIsMTEwMSwxMDkwLDEwODYsMzIsMTEwMywzMiwxMDg1LDEwODAsMTA4MiwxMDcyLDEwODIsMzIsMTA4MCwxMDg5LDEwODcsMTA4OCwxMDcyLDEwNzQsMTA4MCwxMDkwLDExMDAsMzIsMTA4NSwxMDc3LDMyLDEwODQsMTA4NiwxMDc1LDEwOTEsNDYsMTMsMTAsMTMsMTAsMTMsMTAsMTMsMTAsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsMzIsNjcsMTE0LDk3LDEwMiwxMTYsMTAxLDExNCw3NywxMDUsMTEwLDEwMSw5OSwxMTQsOTcsMTAyLDExNiwxMDEsMTE0", true));
            using (FileStream fs = File.Create("C:\\TankiDecompiled\\ReadMe.txt"))
            {
                fs.Write(txt, 0, txt.Length);
                fs.Close();
                txt = null;
            }

            using (FileStream filestream = File.Create("C:\\TankiDecompiled\\Spy.txt"))
            {
                int Length = files.Length;
                for (int i = 0; i < Length;)
                {
                    label1.Text = "" + Length + '\\' + (i + 1);
                    int ig = (int)Mathf.Clamp(((float)i + 1) / Length * 100f, 0f, 100f);
                    progressBar1.Value = ig;
                    label2.Text = "" + ig + "%";
                    string local = "";
                    try
                    {
                        local = Path.GetFileName(Encoding.UTF8.GetString(Convert.FromBase64String(Path.GetFileName(files[i]))));
                    }
                    catch { i++; return; }
                    string ex = Path.GetExtension(local).ToLower();
                    string MD5 = Utils.MD5File(files[i]);
                    try
                    {
                        switch (ex)
                        {
                            case ".jpg":
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\images\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\images\\" + local);
                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\images\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\images\\" + MD5 + local);

                                }
                                break;
                            case ".tara":
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\tara\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\tara\\" + local);

                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\tara\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\tara\\" + MD5 + local);

                                }
                                break;
                            case ".png":
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\images\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\images\\" + local);

                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\images\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\images\\" + MD5 + local);

                                }
                                break;

                            case ".tnk":
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\textures\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\textures\\" + local);
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\texturestoimages\\" + local + ".png");
                                    Log(files[i], "C:\\TankiDecompiled\\texturestoimages\\" + local + ".png");

                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\textures\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\textures\\" + MD5 + local);
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\texturestoimages\\" + MD5 + local + ".png");
                                    Log(files[i], "C:\\TankiDecompiled\\texturestoimages\\" + MD5 + local + ".png");

                                }
                                break;
                            case ".3ds":
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\models\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\models\\" + local);

                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\models\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\models\\" + MD5 + local);

                                }
                                break;
                            case ".swf":
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\swf\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\swf\\" + local);

                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\swf\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\swf\\" + MD5 + local);

                                }
                                break;
                            case ".xml":
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\xml\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\xml\\" + local);

                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\xml\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\xml\\" + MD5 + local);

                                }
                                break;
                            default:
                                try
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\unkown\\" + local);
                                    Log(files[i], "C:\\TankiDecompiled\\unkown\\" + local);

                                }
                                catch
                                {
                                    await CopyFileAsync(files[i], "C:\\TankiDecompiled\\unkown\\" + MD5 + local);
                                    Log(files[i], "C:\\TankiDecompiled\\unkown\\" + MD5 + local);

                                }
                                break;

                        }


                    }

                    catch { }
                    i++;


                }
                byte[] bt = Encoding.UTF8.GetBytes(MyLog);
                await filestream.WriteAsync(bt, 0, bt.Length);
                MyLog = "";
                filestream.Close();

            }
            Process.Start("explorer.exe", "-path=" + "\"C:\\TankiDecompiled\"");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\TankiDecompiled"))
            {
                if (MessageBox.Show("C:\\TankiDecompiled Already exists, delete or cancel?", "Crafter Decompiller", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    Directory.Delete("C:\\TankiDecompiled", true);
                }
            }

            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                FBD.SelectedPath = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\TankiOnline\\Local Store\\cache";

                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    DeFile(FBD.SelectedPath);
                }
            }
        }
    }
}
