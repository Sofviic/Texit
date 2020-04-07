using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texit {
	public partial class Texit : Form {

		const string FILTER = "texit files(*.texit)|*.texit|All files(*.*)|*.*";
		const string VERSION = "v0.1";

		bool filed = false;
		string currentFilename;
		string text;
		Font font;
		float fontSize;

		public Texit() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) { }

		private void fileToolStripMenuItem_Click(object sender, EventArgs e) { }

		private void newToolStripMenuItem_Click(object sender, EventArgs e) => new Thread(() => Application.Run(new Texit())).Start();

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog {
				Filter = FILTER
			};

			if(ofd.ShowDialog() == DialogResult.OK) {
				currentFilename = ofd.FileName;
				text = File.ReadAllText(currentFilename);
				filed = true;
				textBox1.Text = text;
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			if(filed) File.WriteAllText(currentFilename, text);
			else throw new Exception("No file opened.");
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog {
				Filter = FILTER
			};

			if(sfd.ShowDialog() == DialogResult.OK) {
				currentFilename = sfd.FileName;
				File.WriteAllText(currentFilename, text);
				filed = true;
			}
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e) { }

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("Texit " + VERSION + "\nby SOFVIIC", "Texit " + VERSION);
		}

		private void formatToolStripMenuItem_Click(object sender, EventArgs e) { }

		private void fontToolStripMenuItem_Click(object sender, EventArgs e) {
			FontDialog fd = new FontDialog();

			if(fd.ShowDialog() == DialogResult.OK) {
				font = fd.Font;
				fontSize = fd.Font.Size;
				textBox1.Font = font;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			//TODO: add visual replacments.
			text = textBox1.Text;
			
		}
	}
}
