using System;
using System.IO;
using System.Windows.Forms;

namespace RegistroEstudiantes
{
    public partial class Form1 : Form
    {

        private TextBox txtCarnet, txtNombre, txtApellido, txtCarrera, txtCurso;
        private RadioButton rbDiurno, rbVespertino, rbNocturno;
        private CheckBox chkBeca;
        private Button btnGuardar;
        private DataGridView dgv;

        public Form1()
        {
            this.Width = 650;
            this.Height = 500;
            this.Text = "Registro de Estudiantes";

            txtCarnet = new TextBox() { Location = new System.Drawing.Point(20, 20), Width = 150 };
            txtNombre = new TextBox() { Location = new System.Drawing.Point(20, 50), Width = 150 };
            txtApellido = new TextBox() { Location = new System.Drawing.Point(20, 80), Width = 150 };
            txtCarrera = new TextBox() { Location = new System.Drawing.Point(20, 110), Width = 150 };
            txtCurso = new TextBox() { Location = new System.Drawing.Point(20, 140), Width = 150 };

            rbDiurno = new RadioButton() { Text = "Diurno", Location = new System.Drawing.Point(200, 20), Checked = true };
            rbVespertino = new RadioButton() { Text = "Vespertino", Location = new System.Drawing.Point(200, 45) };
            rbNocturno = new RadioButton() { Text = "Nocturno", Location = new System.Drawing.Point(200, 70) };
            chkBeca = new CheckBox() { Text = "Beca", Location = new System.Drawing.Point(200, 100) };

            btnGuardar = new Button() { Text = "Guardar", Location = new System.Drawing.Point(200, 180) };
            btnGuardar.Click += BtnGuardar_Click;

            dgv = new DataGridView() { Location = new System.Drawing.Point(20, 220), Width = 590, Height = 200 };
            dgv.Columns.Add("Carnet", "Carnet");
            dgv.Columns.Add("Nombre", "Nombre");
            dgv.Columns.Add("Apellido", "Apellido");
            dgv.Columns.Add("Carrera", "Carrera");
            dgv.Columns.Add("Curso", "Curso");
            dgv.Columns.Add("Modalidad", "Modalidad");
            dgv.Columns.Add("Beca", "Beca");

            this.Controls.Add(txtCarnet);
            this.Controls.Add(txtNombre);
            this.Controls.Add(txtApellido);
            this.Controls.Add(txtCarrera);
            this.Controls.Add(txtCurso);
            this.Controls.Add(rbDiurno);
            this.Controls.Add(rbVespertino);
            this.Controls.Add(rbNocturno);
            this.Controls.Add(chkBeca);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(dgv);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            string modalidad = rbDiurno.Checked ? "Diurno" : rbVespertino.Checked ? "Vespertino" : "Nocturno";
            string beca = chkBeca.Checked ? "Sí" : "No";

            dgv.Rows.Add(txtCarnet.Text, txtNombre.Text, txtApellido.Text, txtCarrera.Text, txtCurso.Text, modalidad, beca);

            string linea = $"{txtCarnet.Text},{txtNombre.Text},{txtApellido.Text},{txtCarrera.Text},{txtCurso.Text},{modalidad},{beca}";
            File.AppendAllText("estudiantes.txt", linea + Environment.NewLine);
        }

    }
}
