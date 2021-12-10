using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace P6_1_1204049
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //membuat method updateDB dengan parameter cmd
        private void UpdateDB(string cmd)
        {
            //exception handler
            try
            {
                //connection untuk koneksi ke basisdata P6_1204049
                SqlConnection myConnection= new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = P6_1204049; Integrated Security = True");
                
                //membuka koneksi, menggunakan object myConnection
                myConnection.Open();

                //membuat objek dengan nama myCommand, inisialisasi dari class sqlCommand
                SqlCommand myCommand = new SqlCommand();

                //menetapkan koneksi basisdata yang digunakan yaitu object myConnection
                myCommand.Connection = myConnection;

                //mengatur query yang digunakan, diambil dari parameter cmd
                myCommand.CommandText = cmd;

                //eksekusi myCommand yang diambil dari parameter cmd
                myCommand.ExecuteNonQuery();

                //menampilkan pesan jika eksekusi berhasil
                MessageBox.Show("Basisdata berhasil diperbarui", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //penanganan apabila terjadi error pada saat try, exception diset dalam variabel ex
            catch (Exception ex)
            {
                //menampilkan pesan kesalahan
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //perintah SQL untuk menyimpan data inputan user ke basisdata
            string myCmd = "INSERT INTO msprodi VALUES ('"
                + txtIdProdi.Text + "','"
                + txtNamaProdi.Text + "','"
                + txtSingkatan.Text + "','"
                + txtKaProdi.Text + "','"
                + txtSekProdi.Text + "')";

            //memanggil method UpdateDB dengan set parameter myCmd
            UpdateDB(myCmd);
        }

       private void clear()
        {
            //mengosongkan isian dalam TextBox
            txtIdProdi.Text = "";
            txtNamaProdi.Text = "";
            txtSingkatan.Text = "";
            txtKaProdi.Text = "";
            txtSekProdi.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
