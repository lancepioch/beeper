using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Beeper_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Hashtable note = new Hashtable();
        public Hashtable length = new Hashtable();
        public int position = -1;
        public bool adebug = false;

        public void keyboard()
        {
            Form2 kboard = new Form2();
            kboard.Show();
        }

        public void debug(string debugged)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + debugged;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Space:
                    player = new Thread(new ThreadStart(_playAll));
                    player.Start();
                    return true;

                case Keys.Enter:
                    add(listBox1.Items.Count, 0);
                    debug("Note added");
                    return true;

                case Keys.Control|Keys.A:
                    MessageBox.Show("Beeper GUI and Idea by Lance", "Beeper GUI");
                    return true;

                /*case Keys.Control|Keys.D:
                    if (adebug == false)
                    {
                        adebug = true;
                        this.Height = 585;
                        debug("Debug ON");
                    }

                    else
                    {
                        adebug = false;
                        this.Height = 435;
                        debug("Debug OFF");
                    }
                    return true;*/

                case Keys.Control | Keys.K:
                    keyboard();
                    return true;

                case Keys.Up:
                    if (checkBox1.Checked == true)
                    {
                        try
                        {numericUpDown1.Value = numericUpDown1.Value + 1;}
                            catch {}
                    }
                    return true;

                case Keys.Down:
                    if (checkBox1.Checked == true)
                    {
                        try
                        { numericUpDown1.Value = numericUpDown1.Value - 1; }
                        catch { }
                    }
                    return true;


                case Keys.R:
                    radioButton20.Checked = true;
                    return true;
                case Keys.A:
                    radioButton17.Checked = true;
                    return true;
                case Keys.B:
                    radioButton21.Checked = true;
                    return true;
                case Keys.C:
                    radioButton1.Checked = true;
                    return true;
                case Keys.D:
                    radioButton3.Checked = true;
                    return true;
                case Keys.E:
                    radioButton5.Checked = true;
                    return true;
                case Keys.F:
                    radioButton6.Checked = true;
                    return true;
                case Keys.G:
                    radioButton19.Checked = true;
                    return true;

                case Keys.S:
                    if (radioButton17.Checked == true)
                        radioButton22.Checked = true;

                    if (radioButton1.Checked == true)
                        radioButton2.Checked = true;

                    if (radioButton3.Checked == true)
                        radioButton4.Checked = true;

                    if (radioButton6.Checked == true)
                        radioButton16.Checked = true;

                    if (radioButton19.Checked == true)
                        radioButton18.Checked = true;

                    return true;

                case Keys.Alt | Keys.W:
                    radioButton7.Checked = true;
                    return true;
                case Keys.Alt | Keys.D:
                    radioButton8.Checked = true;
                    return true;
                case Keys.Alt | Keys.H:
                    radioButton9.Checked = true;
                    return true;
                case Keys.Alt | Keys.Q:
                    radioButton10.Checked = true;
                    return true;
                case Keys.Alt | Keys.E:
                    radioButton11.Checked = true;
                    return true;
                case Keys.Alt | Keys.S:
                    radioButton12.Checked = true;
                    return true;
                case Keys.Alt | Keys.T:
                    radioButton13.Checked = true;
                    return true;

                case Keys.Delete:
                    if (listBox1.SelectedIndex >= 0){
                        int x = listBox1.SelectedIndex;
                        listBox1.Items.RemoveAt(x);
                        try{listBox1.SelectedIndex = x;}
                        catch{}
                    }
                    return true;
                
                case Keys.Back:
                    backspace();
                    return true;

                case Keys.Control|Keys.S:
                    save();
                    return true;

                case Keys.Control|Keys.Q:
                    this.Close();
                    return true;

                case Keys.Control|Keys.C:
                    listBox1.Items.Clear();
                    return true;

                case Keys.Control|Keys.O:
                    open();
                    return true;

                case Keys.OemQuotes:
                    breath_mark();
                    return true;
            }
            return false;
        }

        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern Boolean Beep(UInt32 frequency, UInt32 duration);

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        bool eight = false;
        bool one = false;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 8 & eight == false)
            {
                eight = true;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
                radioButton16.Enabled = false;
                radioButton17.Enabled = false;
                radioButton18.Enabled = false;
                radioButton19.Enabled = false;
                radioButton21.Enabled = false;
                radioButton22.Enabled = false;

                if (radioButton5.Checked == true){
                    radioButton5.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton6.Checked == true){
                    radioButton6.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton16.Checked == true){
                    radioButton16.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton17.Checked == true){
                    radioButton17.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton18.Checked == true){
                    radioButton18.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton19.Checked == true){
                    radioButton19.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton20.Checked == true){
                    radioButton20.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton21.Checked == true){
                    radioButton21.Checked = false;
                    radioButton1.Checked = true;}

                if (radioButton22.Checked == true){
                    radioButton22.Checked = false;
                    radioButton1.Checked = true;}
            }
            else
            {
                if (eight == true)
                {
                    eight = false;
                    radioButton5.Enabled = true;
                    radioButton6.Enabled = true;
                    radioButton16.Enabled = true;
                    radioButton17.Enabled = true;
                    radioButton18.Enabled = true;
                    radioButton19.Enabled = true;
                    radioButton21.Enabled = true;
                    radioButton22.Enabled = true;
                }
            }

            if (numericUpDown1.Value == 1 & one == false)
            {
                one = true;
                if (radioButton1.Checked | radioButton2.Checked)
                    radioButton3.Checked = true;

                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }

            else if (one & numericUpDown1.Value != 1)
            {
                one = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton20.Checked == true)
            {numericUpDown1.Enabled = false;}
            else{numericUpDown1.Enabled = true;}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add(listBox1.Items.Count, 0);
        }

        private void add(int where, int normal)
        {
            string finalnote;
            string note = "";
            string number = "";

            if (radioButton20.Checked == false)
                number = numericUpDown1.Value.ToString();
            else note = "r";

            string length = "";

            if (radioButton7.Checked == true) { length = "w"; }
            if (radioButton8.Checked == true) { length = "d"; }
            if (radioButton9.Checked == true) { length = "h"; }
            if (radioButton10.Checked == true) { length = "q"; }
            if (radioButton11.Checked == true) { length = "e"; }
            if (radioButton12.Checked == true) { length = "s"; }
            if (radioButton13.Checked == true) { length = "t"; }

            if (radioButton1.Checked == true) { note = "c"; }
            if (radioButton2.Checked == true) { note = "cs"; }
            if (radioButton3.Checked == true) { note = "d"; }
            if (radioButton4.Checked == true) { note = "ds"; }
            if (radioButton5.Checked == true) { note = "e"; }
            if (radioButton6.Checked == true) { note = "f"; }
            if (radioButton16.Checked == true) { note = "fs"; }
            if (radioButton19.Checked == true) { note = "g"; }
            if (radioButton18.Checked == true) { note = "gs"; }
            if (radioButton17.Checked == true) { note = "a"; }
            if (radioButton22.Checked == true) { note = "as"; }
            if (radioButton21.Checked == true) { note = "b"; }

            finalnote = note + number + length;
            listBox1.Items.Add(finalnote);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            object temp = listBox1.SelectedItem;
            backspace();

            listBox1.Items.Insert(where+normal, temp);

            listBox1.SelectedIndex = where+normal;
            position = listBox1.SelectedIndex;
        }

        public void backspace()
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                if (listBox1.Items.Count == 0)
                {
                    position = -1;
                }
            }
        }


        private void breath_mark()
        {
            listBox1.Items.Add("'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void open()
        {
            string beepmusic = "";
            openFileDialog1.Title = "Open...";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = @"C:\Documents and Settings";
            openFileDialog1.DefaultExt = "beep";
            openFileDialog1.Filter = "Beeper file (*.beep*)|*.beep*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string filename = openFileDialog1.FileName;
                beepmusic = File.ReadAllText(filename);

                char[] splitter = { ' ' };
                string[] arInfo = beepmusic.Split(splitter);
                

                for (int x = 0; x < arInfo.Length; x++)
                    listBox1.Items.Add(arInfo[x]);
                

                listBox1.SelectedIndex = 0;
                position = 0;
            }

        }

        private void save()
        {
            saveFileDialog1.Title = "Save as...";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = @"C:/";
            saveFileDialog1.DefaultExt = "beep";
            saveFileDialog1.Filter = "Beeper file (*.beep*)|*.beep*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                string beepinfo = "";
                for (int x = 0; x < listBox1.Items.Count; x++)
                {
                    if (x > 0) { beepinfo = beepinfo + " "; }
                    beepinfo = beepinfo + listBox1.Items[x].ToString();
                }

                File.WriteAllText(filename, beepinfo);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {checkBox1.Checked = false;}

            else
            {checkBox1.Checked = true;}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            open();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            breath_mark();
        }

        public bool playing = false;

        public void play(string n)
        {
            _play(n);
            
        }
        void _play(object arg)
        {
            string n = arg.ToString();
            if (n == "'")
            {
                // breath mark
                System.Threading.Thread.Sleep(50);
            }

            else if (n[0] == 'r')//wh
            {
                // rest note
                // if the first char of n is r it is a rest note
                // then i use the second character which is gonna be on of these
                System.Threading.Thread.Sleep(Convert.ToUInt16(length[n[1]]));
            }

            else if (n.Length > 2) //elif
            {
                if (n[1] == 's')
                {
                    string s = (n[0].ToString() + n[1].ToString() + n[2].ToString()).ToUpper();
                    uint freq = Convert.ToUInt32(note[s]);
                    uint dur = Convert.ToUInt32(length[n[3]]);
                    Beep(freq, dur);
                    //Beep(Convert.ToInt16(note[s].ToString()), Convert.ToInt16(length[n[3]].ToString()));
                }

                else
                {
                    string s = (n[0].ToString() + n[1].ToString()).ToUpper();
                    uint freq = Convert.ToUInt32(note[s]);
                    uint dur = Convert.ToUInt32(length[n[2]]);
                    Beep(freq, dur);
                    //Beep(Convert.ToInt16(note[s]), Convert.ToInt16(length[n[2]]));
                }
            }
        }
        Thread player;
        private void button8_Click(object sender, EventArgs e)
        {
            player = new Thread(new ThreadStart(_playAll));
            player.Start();
        }
        void _playAll()
        {
            try
            { position = listBox1.SelectedIndex; }

            catch
            { position = -1; }

            if (position >= 0)
            {


                // play button
                // pause symbol = ;
                // play symbol = 4
                // stop symbol = <
                // rest of them = http://fay.iniminimo.com/seamless/chartwebdings.gif
                if (playing == false)
                {
                    button8.Text = ";";
                    button8.Refresh();
                    playing = true;

                    int x = position;

                    if (x == listBox1.Items.Count - 1) {
                        listBox1.SelectedIndex = 0;
                        position = 0;
                        x = position;
                    }



                    while (position < listBox1.Items.Count && playing)
                    {
                        string n = listBox1.Items[position].ToString();
                        play(n);
                        position++;//u have to ++ it before testing...
                        if (position < listBox1.Items.Count)
                            listBox1.SelectedIndex = position;
                    }

                    if (playing)
                    {
                        position = 0;
                        listBox1.SelectedIndex = position;
                    }

                    button8.Text = "4";
                    button8.Refresh();
                    playing = false;
                }

                else if (playing)
                {
                    playing = false;
                    button8.Text = "4";
                    button8.Refresh();
                    if (player != null)
                    {
                        if (player.IsAlive)
                            player.Abort();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a starting point or make some notes", "Beeper GUI");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            playing = false;
            button8.Text = "4";
            button8.Refresh();

            if (player != null)
                if (player.IsAlive)
                    player.Abort();

            if (listBox1.Items.Count > 0)
            {
                position = 0;
                listBox1.SelectedIndex = position;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            note.Add("C0", 16.35); note.Add("CS0", 17.32); note.Add("D0", 18.35); note.Add("DS0", 19.45); note.Add("E0", 20.60); note.Add("F0", 21.83); note.Add("FS0", 23.12); note.Add("G0", 24.50); note.Add("GS0", 25.96); note.Add("A0", 27.50); note.Add("AS0", 29.14); note.Add("B0", 30.87); note.Add("C1", 32.70); note.Add("CS1", 34.65); note.Add("D1", 36.71); note.Add("DS1", 38.89); note.Add("E1", 41.20); note.Add("F1", 43.65); note.Add("FS1", 46.25); note.Add("G1", 49.00); note.Add("GS1", 51.91); note.Add("A1", 55.00); note.Add("AS1", 58.27); note.Add("B1", 61.74); note.Add("C2", 65.41); note.Add("CS2", 69.30); note.Add("D2", 73.42); note.Add("DS2", 77.78); note.Add("E2", 82.41); note.Add("F2", 87.31); note.Add("FS2", 92.50); note.Add("G2", 98.00); note.Add("GS2", 103.83); note.Add("A2", 110.00); note.Add("AS2", 116.54); note.Add("B2", 123.47); note.Add("C3", 130.81); note.Add("CS3", 138.59); note.Add("D3", 146.83); note.Add("DS3", 155.56); note.Add("E3", 164.81); note.Add("F3", 174.61); note.Add("FS3", 185.00); note.Add("G3", 196.00); note.Add("GS3", 207.65); note.Add("A3", 220.00); note.Add("AS3", 233.08); note.Add("B3", 246.94); note.Add("C4", 261.63); note.Add("CS4", 277.18); note.Add("D4", 293.66); note.Add("DS4", 311.13); note.Add("E4", 329.63); note.Add("F4", 349.23); note.Add("FS4", 369.99); note.Add("G4", 392.00); note.Add("GS4", 415.30); note.Add("A4", 440.00); note.Add("AS4", 466.16); note.Add("B4", 493.88); note.Add("C5", 523.25); note.Add("CS5", 554.37); note.Add("D5", 587.33); note.Add("DS5", 622.25); note.Add("E5", 659.26); note.Add("F5", 698.46); note.Add("FS5", 739.99); note.Add("G5", 783.99); note.Add("GS5", 830.61); note.Add("A5", 880.00); note.Add("AS5", 932.33); note.Add("B5", 987.77); note.Add("C6", 1046.50); note.Add("CS6", 1108.73); note.Add("D6", 1174.66); note.Add("DS6", 1244.51); note.Add("E6", 1318.51); note.Add("F6", 1396.91); note.Add("FS6", 1479.98); note.Add("G6", 1567.98); note.Add("GS6", 1661.22); note.Add("A6", 1760.00); note.Add("AS6", 1864.66); note.Add("B6", 1975.53); note.Add("C7", 2093.00); note.Add("CS7", 2217.46); note.Add("D7", 2349.32); note.Add("DS7", 2489.02); note.Add("E7", 2637.02); note.Add("F7", 2793.83); note.Add("FS7", 2959.96); note.Add("G7", 3135.96); note.Add("GS7", 3322.44); note.Add("A7", 3520.00); note.Add("AS7", 3729.31); note.Add("B7", 3951.07); note.Add("C8", 4186.01); note.Add("CS8", 4434.92); note.Add("D8", 4698.64); note.Add("DS8", 4978.03);
            length.Add('w',1000); length.Add('d',750); length.Add('h',500); length.Add('q',250); length.Add('e',120); length.Add('s', 60); length.Add('t',30);
            /*DictionaryEntry[] l = new DictionaryEntry[length.Count];
            length.CopyTo(l, 0);
            MessageBox.Show(l.GetValue(4).ToString());*/
            CheckForIllegalCrossThreadCalls = false;//for stuff
            /*string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
                MessageBox.Show(args[i]);*/
            listBox1.ContextMenuStrip = contextMenuStrip1;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            position = listBox1.SelectedIndex;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            add(listBox1.SelectedIndex, 1);
        }

        private void noteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                play(listBox1.Items[position].ToString());
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player = new Thread(new ThreadStart(_playAll));
            player.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playing = false;
            button8.Text = "4";
            button8.Refresh();

            if (player != null)
                if (player.IsAlive)
                    player.Abort();

            if (listBox1.Items.Count > 0)
            {
                position = 0;
                listBox1.SelectedIndex = position;
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                //if (listBox1.IndexFromPoint(e.Location) >= 0)
                    listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (listBox1.Items.Count > 0 & x >= 0)
                listBox1.Items.RemoveAt(x);
            try { listBox1.SelectedIndex = x; }
            catch{if (listBox1.Items.Count > 0) listBox1.SelectedIndex = listBox1.Items.Count - 1;}
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add(listBox1.Items.Count, 0);
        }

        private void hereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add(listBox1.SelectedIndex, 1);
        }

    }
}