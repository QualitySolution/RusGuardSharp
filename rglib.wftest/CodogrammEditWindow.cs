using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rglib.wftest.Model;

namespace rglib.wftest {
    public partial class CodogrammEditWindow : Form {
        private readonly CodogrammData _codogrammData;

        public CodogrammEditWindow() : this(new CodogrammData()) {

        }

        public CodogrammEditWindow(CodogrammData codogrammData) {
            _codogrammData = codogrammData;
            InitializeComponent();
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e) {
        }

        public CodogrammData CodogrammData {
            get { return _codogrammData; }
        }

        private void OnValueChanged(object sender, EventArgs e) {
            UpdateBitsEnabled();
            ApplyBitsFrom(_codogrammData.CodogrammBody);
        }

        private void groupBox1_Enter(object sender, EventArgs e) {
        }

        private void CodogrammEditWindow_Load(object sender, EventArgs e) {
            codogrammLengthUpDown.Value = _codogrammData.LengthBits;
            codogramNumUpDown.Value = _codogrammData.Number;
            textBox1.Text = _codogrammData.Name;
            ApplyBitsFrom(_codogrammData.CodogrammBody);
        }

        void UpdateBitsEnabled() {
            int index = 0;

            for (index = Convert.ToInt32(codogrammLengthUpDown.Minimum);
                index <= Convert.ToInt32(codogrammLengthUpDown.Maximum);
                index++) {
                var target = groupBox1.Controls[string.Format("checkBox{0}", index)];
                target.Enabled = index <= Convert.ToInt32(codogrammLengthUpDown.Value);
            }
        }

        void ApplyBitsFrom(uint data) {
            uint loclData = data;
            for (int index = 0; index < Convert.ToInt32(codogrammLengthUpDown.Value); index++) {
                var target = groupBox1.Controls[string.Format("checkBox{0}", index + 1)];
                (target as CheckBox).Checked = ((loclData >> index) & 1) == 1;
            }
        }

        private uint GetUintFromBits() {
            uint localValue = 0;
            for (int index = 0; index < Convert.ToInt32(codogrammLengthUpDown.Value); index++) {
                var target = groupBox1.Controls[string.Format("checkBox{0}", index + 1)];
                localValue |= (uint) (((target as CheckBox).Checked ? 1 : 0) << index);
                //localValue = (uint) ((localValue << index) | ((target as CheckBox).Checked ? 1 : 0));
            }

            return localValue;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            _codogrammData.CodogrammBody = GetUintFromBits();
            _codogrammData.Name = textBox1.Text;
            _codogrammData.LengthBits = Convert.ToByte(codogrammLengthUpDown.Value);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}

