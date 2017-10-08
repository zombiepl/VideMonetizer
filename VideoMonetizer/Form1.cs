using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Toci.VideoMonetizer.Bll;
using Toci.VideoMonetizer.Bll.DataEntities;
using Toci.VideoMonetizer.Bll.Interfaces;
using Toci.VideoMonetizer.Bll.Interfaces.DataEntities;
using VideoMonetizer.Logic;

namespace VideoMonetizer
{
    public partial class Form1 : Form
    {
        private List<IVideoReferenceMatchEntity> _videoReferenceMatchEntities = new List<IVideoReferenceMatchEntity>();
      //  private VideoReferenceMatchEntity _videoReferenceMatchEntity;
        private ListViewItem _listviewitem;
        private List<ListViewItem> _listViewItems = new List<ListViewItem>();
        private VideoReferenceMatchEntity vrme; //def. zmiennej vrme typu ten obiekt

        //UiElementsTranslation listviewitem = new UiElementsTranslation();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  axWindowsMediaPlayer1.AllowDrop = true;
          //  label3.Text= axWindowsMediaPlayer1.AllowDrop.ToString();
            openFileDialog1.FileName = null;
            openFileDialog2.FileName = null;
            
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
        }

        private void openMainMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
             
              axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
                label3.Text = openFileDialog1.FileName;
                openFileDialog1.RestoreDirectory = true;
                toolStripStatusLabel1.Text = "otworzono film główny";
            }
        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openRefferencedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                axWindowsMediaPlayer2.URL = openFileDialog1.FileName;
                label4.Text = openFileDialog1.FileName;
                toolStripStatusLabel1.Text = "otworzono film referencyjny";

            }
            

        }


        private void button1_Click(object sender, EventArgs e)//przenieś
        {

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying || axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                _listviewitem = new ListViewItem(axWindowsMediaPlayer1.currentMedia.name);
                _listviewitem.SubItems.Add(axWindowsMediaPlayer2.currentMedia.name);
                _listviewitem.SubItems.Add(axWindowsMediaPlayer1.Ctlcontrols.currentPositionString);
                _listviewitem.SubItems.Add(axWindowsMediaPlayer2.Ctlcontrols.currentPositionString);
                listView1.Items.Add(_listviewitem);


                _listViewItems.Add(_listviewitem);
                //======================== fill vrme object
                
                /*
                vrme = new VideoReferenceMatchEntity();
                vrme.TimeBaseMovie = axWindowsMediaPlayer1.currentMedia.name;
                vrme.BaseMovie = axWindowsMediaPlayer2.currentMedia.name;
                vrme.ReferencedMovie = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                vrme.TimeReferenced = axWindowsMediaPlayer2.Ctlcontrols.currentPositionString;*/

            }
            else
            {
                MessageBox.Show("Main Movie is nor played or paused");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying || axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {

            }
            else
            {
                MessageBox.Show("Main Movie is nor played or paused");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    
                    toolStripStatusLabel1.Text = listView1.Items[i].Text;

                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
         
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    
                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition = Convert.ToDouble(listView1.Items[i].Text);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)//delete ref
        {


            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                     listView1.Items[i].Remove();
                }
            }
        }

        
        private void button2_Click_1(object sender, EventArgs e)//savefile
        {
            //Storage storage = new Storage(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
           Storage storage = new Storage();
           //storage.Save(_videoReferenceMatchEntity); 

            IUiElementsTranslation uiTranslation = new UiElementsTranslation();

            foreach (var item in _listViewItems)
            {
                _videoReferenceMatchEntities = uiTranslation.GetVideoReferenes(item);
            }


            storage.Save(_videoReferenceMatchEntities);
        }

        private void button5_Click(object sender, EventArgs e)//exit
        {
            Close();
        }
    }
}
