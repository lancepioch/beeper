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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Hashtable note = new Hashtable();
        public Hashtable length = new Hashtable();

        public int oct = 4;

        public int L = 3;

        public int getL()
        {
            if (radioButton7.Checked) L = 0;
            if (radioButton8.Checked) L = 1;
            if (radioButton9.Checked) L = 2;
            if (radioButton10.Checked) L = 3;
            if (radioButton11.Checked) L = 4;
            if (radioButton12.Checked) L = 5;
            if (radioButton1.Checked) L = 6;
            return L;
        }

        public string[] block = { "| ------------------- ", " -------------------- | -------------------------------------  ", "  ------------------------------------- | -------------- ", " -------------- |\nOctave" };

        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern Boolean Beep(UInt32 frequency, UInt32 duration);

        public void beeped(string note) // example: ds, 4
        {
            string lg = "";
            if (L == 0) lg = "w";
            if (L == 1) lg = "d";
            if (L == 2) lg = "h";
            if (L == 3) lg = "q";
            if (L == 4) lg = "e";
            if (L == 5) lg = "s";
            if (L == 6) lg = "t";

            dobeep(note + lg);

            //MessageBox.Show("Note: " + note + lg);
        }

        public void dobeep(string n)
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


        private void button1_Click(object sender, EventArgs e)
        { this.Close(); }

        bool seven = false;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            oct = Convert.ToInt32(numericUpDown1.Value);
            label1.Text = block[0] + (oct-1).ToString() + block[1] + oct.ToString() + block[2] + (oct+1).ToString() + block[3];
            label1.Refresh();

            if (numericUpDown1.Value == 7 & seven == false)
            {   seven = true;
                button19.Enabled = false; }

            if (numericUpDown1.Value != 7 & seven)
            {   seven = false;
                button19.Enabled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        { beeped("c" + oct.ToString()); }

        private void Form2_Load(object sender, EventArgs e)
        {
            note.Add("C0", 16.35); note.Add("CS0", 17.32); note.Add("D0", 18.35); note.Add("DS0", 19.45); note.Add("E0", 20.60); note.Add("F0", 21.83); note.Add("FS0", 23.12); note.Add("G0", 24.50); note.Add("GS0", 25.96); note.Add("A0", 27.50); note.Add("AS0", 29.14); note.Add("B0", 30.87); note.Add("C1", 32.70); note.Add("CS1", 34.65); note.Add("D1", 36.71); note.Add("DS1", 38.89); note.Add("E1", 41.20); note.Add("F1", 43.65); note.Add("FS1", 46.25); note.Add("G1", 49.00); note.Add("GS1", 51.91); note.Add("A1", 55.00); note.Add("AS1", 58.27); note.Add("B1", 61.74); note.Add("C2", 65.41); note.Add("CS2", 69.30); note.Add("D2", 73.42); note.Add("DS2", 77.78); note.Add("E2", 82.41); note.Add("F2", 87.31); note.Add("FS2", 92.50); note.Add("G2", 98.00); note.Add("GS2", 103.83); note.Add("A2", 110.00); note.Add("AS2", 116.54); note.Add("B2", 123.47); note.Add("C3", 130.81); note.Add("CS3", 138.59); note.Add("D3", 146.83); note.Add("DS3", 155.56); note.Add("E3", 164.81); note.Add("F3", 174.61); note.Add("FS3", 185.00); note.Add("G3", 196.00); note.Add("GS3", 207.65); note.Add("A3", 220.00); note.Add("AS3", 233.08); note.Add("B3", 246.94); note.Add("C4", 261.63); note.Add("CS4", 277.18); note.Add("D4", 293.66); note.Add("DS4", 311.13); note.Add("E4", 329.63); note.Add("F4", 349.23); note.Add("FS4", 369.99); note.Add("G4", 392.00); note.Add("GS4", 415.30); note.Add("A4", 440.00); note.Add("AS4", 466.16); note.Add("B4", 493.88); note.Add("C5", 523.25); note.Add("CS5", 554.37); note.Add("D5", 587.33); note.Add("DS5", 622.25); note.Add("E5", 659.26); note.Add("F5", 698.46); note.Add("FS5", 739.99); note.Add("G5", 783.99); note.Add("GS5", 830.61); note.Add("A5", 880.00); note.Add("AS5", 932.33); note.Add("B5", 987.77); note.Add("C6", 1046.50); note.Add("CS6", 1108.73); note.Add("D6", 1174.66); note.Add("DS6", 1244.51); note.Add("E6", 1318.51); note.Add("F6", 1396.91); note.Add("FS6", 1479.98); note.Add("G6", 1567.98); note.Add("GS6", 1661.22); note.Add("A6", 1760.00); note.Add("AS6", 1864.66); note.Add("B6", 1975.53); note.Add("C7", 2093.00); note.Add("CS7", 2217.46); note.Add("D7", 2349.32); note.Add("DS7", 2489.02); note.Add("E7", 2637.02); note.Add("F7", 2793.83); note.Add("FS7", 2959.96); note.Add("G7", 3135.96); note.Add("GS7", 3322.44); note.Add("A7", 3520.00); note.Add("AS7", 3729.31); note.Add("B7", 3951.07); note.Add("C8", 4186.01); note.Add("CS8", 4434.92); note.Add("D8", 4698.64); note.Add("DS8", 4978.03);
            length.Add('w', 1000); length.Add('d', 750); length.Add('h', 500); length.Add('q', 250); length.Add('e', 120); length.Add('s', 60); length.Add('t', 30);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        { L = 0; }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        { L = 1; }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        { L = 2; }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        { L = 3; }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        { L = 4; }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        { L = 5; }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        { L = 6; }

        private void button4_Click(object sender, EventArgs e)
            { beeped("d" + oct.ToString()); }

        private void button6_Click(object sender, EventArgs e)
            { beeped("e" + oct.ToString()); }

        private void button7_Click(object sender, EventArgs e)
            { beeped("f" + oct.ToString()); }

        private void button9_Click(object sender, EventArgs e)
            { beeped("g" + oct.ToString()); }

        private void button11_Click(object sender, EventArgs e)
            { beeped("a" + oct.ToString()); }

        private void button13_Click(object sender, EventArgs e)
            { beeped("b" + oct.ToString()); }

        private void button3_Click(object sender, EventArgs e)
            { beeped("cs" + oct.ToString()); }

        private void button5_Click(object sender, EventArgs e)
            { beeped("ds" + oct.ToString()); }

        private void button8_Click(object sender, EventArgs e)
            { beeped("fs" + oct.ToString()); }

        private void button10_Click(object sender, EventArgs e)
            { beeped("gs" + oct.ToString()); }

        private void button12_Click(object sender, EventArgs e)
            { beeped("as" + oct.ToString()); }

        private void button20_Click(object sender, EventArgs e)
            { beeped("f" + (oct - 1).ToString()); }

        private void button23_Click(object sender, EventArgs e)
            { beeped("fs" + (oct - 1).ToString()); }

        private void button18_Click(object sender, EventArgs e)
            { beeped("g" + (oct - 1).ToString()); }

        private void button24_Click(object sender, EventArgs e)
            { beeped("gs" + (oct - 1).ToString()); }

        private void button17_Click(object sender, EventArgs e)
            { beeped("a" + (oct - 1).ToString()); }

        private void button25_Click(object sender, EventArgs e)
            { beeped("as" + (oct - 1).ToString()); }

        private void button16_Click(object sender, EventArgs e)
            { beeped("b" + (oct - 1).ToString()); }

        private void button14_Click(object sender, EventArgs e)
            { beeped("c" + (oct + 1).ToString()); }

        private void button21_Click(object sender, EventArgs e)
            { beeped("cs" + (oct + 1).ToString()); }

        private void button15_Click(object sender, EventArgs e)
            { beeped("d" + (oct + 1).ToString()); }

        private void button22_Click(object sender, EventArgs e)
            { beeped("ds" + (oct + 1).ToString()); }

        private void button19_Click(object sender, EventArgs e)
            { beeped("e" + (oct + 1).ToString()); }
    }
}
