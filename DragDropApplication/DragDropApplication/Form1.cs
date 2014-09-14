using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDropApplication
{
    public partial class Form1 : Form
    {

        #region Global Declaration 

        Boolean _blnSongPlaying = false;

        #endregion 

        #region Contructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion 

        #region Accessor

        private String[] dragedFiles(DragEventArgs e)
        {
            return (string[])e.Data.GetData(DataFormats.FileDrop, false);
        }

        private String fileExtension(String pstrTempFile)
        {
            return Path.GetExtension(pstrTempFile).ToLower();
        }

        #endregion 

        #region Mutator 

        private String currentSelectedSong(ListView lvTemp)
        {
            if (lvTemp.SelectedItems.Count > 0)
            {
                return lvTemp.SelectedItems[0].Text;
            }
            return string.Empty;
        }

        #endregion 

        #region Control Events

        private void lvMusicFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lvMusicFiles_DragDrop(object sender, DragEventArgs e)
        {
            String fileName = dragedFiles(e)[0];
            if ((fileExtension(fileName) == ".mp3"))
            {
                foreach (string file in dragedFiles(e))
                    lvMusicFiles.Items.Add(file);
            }
        }

        private void mnuPlay_Click(object sender, EventArgs e)
        {
            if (currentSelectedSong(lvMusicFiles).ToString() != string.Empty)
            {
                axWindowsMediaPlayer1.URL = currentSelectedSong(lvMusicFiles);
                axWindowsMediaPlayer1.Ctlcontrols.play();
                _blnSongPlaying = true;
            }
        }

        

        private void mnuStop_Click(object sender, EventArgs e)
        {
            if (_blnSongPlaying == true)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            _blnSongPlaying = false;
        }

        private void mnuPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        #endregion 

    }
}
