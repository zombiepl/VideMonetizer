using System;
using System.Windows.Forms;
using System.IO;

namespace VideoMonetizer
{
    public partial class Form1 : Form
    {
        private ListViewItem newList;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.AllowDrop = true;
            label3.Text= axWindowsMediaPlayer1.AllowDrop.ToString();
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
     //  public ListViewItem newList = new ListViewItem("film");

        private void button1_Click(object sender, EventArgs e)//przenieś
        {
            
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying || axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                newList = new ListViewItem(axWindowsMediaPlayer1.currentMedia.name);
                newList.SubItems.Add(axWindowsMediaPlayer2.currentMedia.name);
                newList.SubItems.Add(axWindowsMediaPlayer1.Ctlcontrols.currentPositionString);
                newList.SubItems.Add(axWindowsMediaPlayer2.Ctlcontrols.currentPositionString);
                listView1.Items.Add(newList);
                                                    

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
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Toci files|*.tci";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                foreach (ListViewItem item in listView1.Items)
                {
                    writer.WriteLine(item.SubItems[0].Text +";"+item.SubItems[1].Text + ";" + item.SubItems[2].Text+ ";" + item.SubItems[3].Text+ "#");
                }
                writer.Dispose();
                writer.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)//exit
        {
            Close();
        }
    }
}
