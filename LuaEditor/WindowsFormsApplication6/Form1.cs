using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string FindValueStr(string key)
        {
            var off = OffsetOf(key);
            string str = richTextBox1.Text.Substring(off.Item1, off.Item2 - off.Item1);
            return str;
        }

        private decimal FindValueNumber(string key)
        {
            var off = OffsetOf(key);
            string str = richTextBox1.Text.Substring(off.Item1, off.Item2 - off.Item1);
            return Decimal.Parse(str);
        }

        private string[] FindValueStrArray(string key)
        {
            var off = OffsetOf(key);
            string str = richTextBox1.Text.Substring(off.Item1, off.Item2 - off.Item1);
            return str.Split(',');
        }

        private Tuple<int, int> OffsetOf(string key)
        {
            int start = richTextBox1.Text.IndexOf(key, 0) + key.Length;
            ++start;
            while (richTextBox1.Text[start] == ' ' || richTextBox1.Text[start] == '=')
                ++start;

            int end = start;
            if (richTextBox1.Text[start] == '{')
            {
                ++start;
                end = richTextBox1.Text.IndexOf("}", end);
            }

            else
            {
                end = richTextBox1.Text.IndexOf(",", end);
            }

            return new Tuple<int, int>(start, end);
        }

        private void ReplaceValue(string key, string value)
        {
            var off = OffsetOf(key);
            string removed = richTextBox1.Text.Remove(off.Item1, off.Item2 - off.Item1);
            richTextBox1.Text = removed.Insert(off.Item1, value);
            off = new Tuple<int, int>(off.Item1, off.Item1 + value.Length);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK,
            // load the lua that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void StretchButton_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects the button it includes Syntax Highlighting for the following tokens and makes them readonly
        //    if (StretchButton.Checked)
           }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //Close the Form
            this.Close();
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            // Show the color dialog box. If the user clicks OK, change the
            // rich text box control's background to the color the user chose.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = colorDialog1.Color;
        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            // Undo text
            richTextBox1.Undo();
        }

        private void weaponToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void objectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load File
            string armorObjectLoad = ("D:\\armortemplate.lua");
            richTextBox1.LoadFile(armorObjectLoad, RichTextBoxStreamType.PlainText);

            // Object Folder String Search

            // Faction String Search

            textBox1.Text = FindValueStr("faction =");

            // Special Resists String Search

            srBox.Text = FindValueStr("specialResists =");

            // Vulnerability String Search

            vulnBox.Text = FindValueStr("vulnerability =");

            // Max Condition String Search

            condBox.Value = FindValueNumber("maxCondition");

            // Rating String Search

            ratingBox.Text = FindValueStr("rating =");

            // Health Encumbrance String Search

            health.Value = FindValueNumber("healthEncumbrance");

            // Action Encumbrance String Search

            action.Value = FindValueNumber("actionEncumbrance");

            // Mind Encumbrance String Search

            mind.Value = FindValueNumber("mindEncumbrance");

            // Player Races String Search

            playerBox.Items.AddRange(FindValueStrArray("playerRaces"));

            // Kinetic String Search

            kineticBox.Value = FindValueNumber("kinetic");

            // Energy String Search

            energyBox.Value = FindValueNumber("energy");

            // Electricity String Search

            electricityBox.Value = FindValueNumber("electricity");

            // Stun String Search

            stunBox.Value = FindValueNumber("stun");

            // Blast String Search

            blastBox.Value = FindValueNumber("blast");

            // Heat String Search

            heatBox.Value = FindValueNumber("heat");

            // Cold String Search

            coldBox.Value = FindValueNumber("cold");

            // Acid String Search

            acidBox.Value = FindValueNumber("acid");

            // Lightsaber String Search

            lightsaberBox.Value = FindValueNumber("lightSaber");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save as lua dialog
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ReplaceValue("faction", textBox1.Text);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kineticBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("kinetic", kineticBox.Value.ToString());
        }

        private void energyBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("energy", energyBox.Value.ToString());
        }

        private void electricityBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("electricity", electricityBox.Value.ToString());
        }

        private void stunBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("stun", stunBox.Value.ToString());
        }

        private void blastBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("blast", blastBox.Value.ToString());
        }

        private void heatBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("heat", heatBox.Value.ToString());
        }

        private void coldBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("cold", coldBox.Value.ToString());
        }

        private void acidBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("acid", acidBox.Value.ToString());
        }

        private void lightsaberBox_ValueChanged_1(object sender, EventArgs e)
        {
            ReplaceValue("lightSaber", lightsaberBox.Value.ToString());
        }

        private void srBox_TextChanged(object sender, EventArgs e)
        {
            ReplaceValue("specialResists", srBox.Text);
        }

        private void vulnBox_TextChanged(object sender, EventArgs e)
        {
            ReplaceValue("vulnerability", vulnBox.Text);
        }

        private void condBox_ValueChanged(object sender, EventArgs e)
        {
            ReplaceValue("maxCondition", condBox.Value.ToString());
        }

        private void ratingBox_TextChanged(object sender, EventArgs e)
        {
            ReplaceValue("rating", ratingBox.Text);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void health_ValueChanged(object sender, EventArgs e)
        {
            ReplaceValue("healthEncumbrance", health.Value.ToString());
        }

        private void action_ValueChanged(object sender, EventArgs e)
        {
            ReplaceValue("actionEncumbrance", action.Value.ToString());
        }

        private void mind_ValueChanged(object sender, EventArgs e)
        {
            ReplaceValue("mindEncumbrance", mind.Value.ToString());
        }

        private void playerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playerBox.SelectedItem != null)
                playerText.Text = playerBox.SelectedItem.ToString();
        }

        private void playerText_TextChanged(object sender, EventArgs e)
        {
            if (playerBox.SelectedItem != null)
            {
                playerBox.Items[playerBox.SelectedIndex] = playerText.Text;
                string result = "";
                foreach (var item in playerBox.Items)
                {
                    result += item.ToString() + ",";
                }
                result = result.Substring(0, result.Length - 1);
                ReplaceValue("playerRaces", result);
            }
        }

        private void folderBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void StretchButton_CheckStateChanged(object sender, EventArgs e)
        {
        }
            }
}

