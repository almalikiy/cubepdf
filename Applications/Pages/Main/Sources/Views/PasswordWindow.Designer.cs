﻿namespace Cube.Pdf.Pages
{
    partial class PasswordWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordWindow));
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShowPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.TitleButton = new System.Windows.Forms.PictureBox();
            this.ButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ExitButton = new Cube.Forms.Controls.Button();
            this.ExecButton = new Cube.Forms.Controls.Button();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordBindingSource)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleButton)).BeginInit();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // LayoutPanel
            //
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.PasswordTextBox, 0, 2);
            this.LayoutPanel.Controls.Add(this.ShowPasswordCheckBox, 0, 3);
            this.LayoutPanel.Controls.Add(this.PasswordLabel, 0, 1);
            this.LayoutPanel.Controls.Add(this.HeaderPanel, 0, 0);
            this.LayoutPanel.Controls.Add(this.ButtonsPanel, 0, 5);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 6;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.LayoutPanel.Size = new System.Drawing.Size(434, 221);
            this.LayoutPanel.TabIndex = 4;
            //
            // PasswordTextBox
            //
            this.PasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PasswordBindingSource, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 99);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(410, 23);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            //
            // PasswordBindingSource
            //
            this.PasswordBindingSource.DataSource = typeof(Cube.Pdf.Pages.PasswordViewModel);
            //
            // ShowPasswordCheckBox
            //
            this.ShowPasswordCheckBox.AutoSize = true;
            this.ShowPasswordCheckBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShowPasswordCheckBox.Location = new System.Drawing.Point(317, 127);
            this.ShowPasswordCheckBox.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.ShowPasswordCheckBox.Name = "ShowPasswordCheckBox";
            this.ShowPasswordCheckBox.Size = new System.Drawing.Size(105, 22);
            this.ShowPasswordCheckBox.TabIndex = 3;
            this.ShowPasswordCheckBox.Text = "パスワードを表示";
            this.ShowPasswordCheckBox.UseVisualStyleBackColor = true;
            //
            // PasswordLabel
            //
            this.PasswordLabel.AutoEllipsis = true;
            this.PasswordLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PasswordBindingSource, "Message", true));
            this.PasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 39);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(410, 54);
            this.PasswordLabel.TabIndex = 1001;
            this.PasswordLabel.Text = "パスワードで保護されています。編集するためには管理用パスワード入力してください。";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // HeaderPanel
            //
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.HeaderPanel.Controls.Add(this.TitleButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(434, 36);
            this.HeaderPanel.TabIndex = 999;
            //
            // TitleButton
            //
            this.TitleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TitleButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleButton.Image = global::Cube.Pdf.Pages.Properties.Resources.HeaderTitle;
            this.TitleButton.Location = new System.Drawing.Point(0, 0);
            this.TitleButton.Margin = new System.Windows.Forms.Padding(0);
            this.TitleButton.Name = "TitleButton";
            this.TitleButton.Size = new System.Drawing.Size(170, 36);
            this.TitleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TitleButton.TabIndex = 0;
            this.TitleButton.TabStop = false;
            //
            // ButtonsPanel
            //
            this.ButtonsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonsPanel.Controls.Add(this.ExitButton);
            this.ButtonsPanel.Controls.Add(this.ExecButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 161);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.ButtonsPanel.Size = new System.Drawing.Size(434, 60);
            this.ButtonsPanel.TabIndex = 6;
            //
            // ExitButton
            //
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(322, 12);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 35);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = false;
            //
            // ExecButton
            //
            this.ExecButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.ExecButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.PasswordBindingSource, "Ready", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ExecButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ExecButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.ExecButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecButton.ForeColor = System.Drawing.Color.White;
            this.ExecButton.Location = new System.Drawing.Point(188, 12);
            this.ExecButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExecButton.Name = "ExecButton";
            this.ExecButton.Size = new System.Drawing.Size(130, 35);
            this.ExecButton.TabIndex = 1;
            this.ExecButton.Text = "OK";
            this.ExecButton.UseVisualStyleBackColor = false;
            //
            // PasswordWindow
            //
            this.AcceptButton = this.ExecButton;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(434, 221);
            this.Controls.Add(this.LayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "パスワードを入力して下さい";
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordBindingSource)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TitleButton)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.PictureBox TitleButton;
        private System.Windows.Forms.FlowLayoutPanel ButtonsPanel;
        private Cube.Forms.Controls.Button ExitButton;
        private Cube.Forms.Controls.Button ExecButton;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.BindingSource PasswordBindingSource;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.CheckBox ShowPasswordCheckBox;
    }
}