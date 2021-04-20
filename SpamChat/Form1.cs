using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpamChat
{
    public partial class SpamChat : Form
    {
        KonversiWaktu waktu = new KonversiWaktu();
        double interval;
        public SpamChat()
        {
            InitializeComponent();
        }

        private void Tombol_Mulai_Click(object sender, EventArgs e)
        {
            if(ChatBox.Text == "")
            {
                Waktu.Enabled = false;
                MessageBox.Show("Pesan tidak boleh kosong!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(interval == 0)
                {
                    MessageBox.Show("Silahkan atur waktunya terlebih dahulu!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Waktu.Interval = Convert.ToInt32(interval);
                    Waktu.Enabled = true;
                }
            }
        }

        private void Tombol_Stop_Click(object sender, EventArgs e)
        {
            Waktu.Enabled = false;
            interval = 0;

            ChatBox.Text = "";
            ChatInterval.Text = "";
        }

        private void Tombol_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dibuat oleh Muhammad Surya Jayadiprana. Tolong dipergunakan dengan bijak", "Tentang", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Waktu_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            SendKeys.Send(ChatBox.Text);
            SendKeys.Send("{ENTER}");
        }

        private void SpamChat_Load(object sender, EventArgs e)
        {
            Waktu.Enabled = false;
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void Tombol_Interval_Click(object sender, EventArgs e)
        {
            if(ChatInterval.Text == "")
            {
                MessageBox.Show("Waktu tidak boleh kosong!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                interval = Convert.ToInt32(ChatInterval.Text);
                MessageBox.Show("Kamu mengeset waktu " + waktu.MilikeDetik(interval) + " detik. Artinya, kamu dapat mengirim pesan / " + waktu.MilikeDetik(interval) + " detik", "Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
