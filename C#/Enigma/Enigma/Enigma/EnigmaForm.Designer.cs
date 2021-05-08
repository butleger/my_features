namespace Enigma
{
    partial class EnigmaForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstRotorPickerLabel = new System.Windows.Forms.Label();
            this.thirdRotorPickerLabel = new System.Windows.Forms.Label();
            this.secondRotorPickerLabel = new System.Windows.Forms.Label();
            this.thirdRotorPicker = new System.Windows.Forms.NumericUpDown();
            this.secondRotorPicker = new System.Windows.Forms.NumericUpDown();
            this.firstRotorPicker = new System.Windows.Forms.NumericUpDown();
            this.reflectorPickerLabel = new System.Windows.Forms.Label();
            this.reflectorPicker = new System.Windows.Forms.NumericUpDown();
            this.uncipheredText = new System.Windows.Forms.RichTextBox();
            this.cipheredText = new System.Windows.Forms.RichTextBox();
            this.uncipheredTextLabel = new System.Windows.Forms.Label();
            this.cipheredTextLabel = new System.Windows.Forms.Label();
            this.commutatorInput = new System.Windows.Forms.TextBox();
            this.commutatorsInputLabel = new System.Windows.Forms.Label();
            this.cipherButton = new System.Windows.Forms.Button();
            this.uncipherButton = new System.Windows.Forms.Button();
            this.firstRotorPositionInput = new System.Windows.Forms.NumericUpDown();
            this.secondRotorPositionInput = new System.Windows.Forms.NumericUpDown();
            this.thirdRotorPositionInput = new System.Windows.Forms.NumericUpDown();
            this.secondRotorPositionInputLabel = new System.Windows.Forms.Label();
            this.thirdRotorPositionInputLabel = new System.Windows.Forms.Label();
            this.firstRotorPositionInputLabel = new System.Windows.Forms.Label();
            this.thirdRotorPositionTranslator = new System.Windows.Forms.Label();
            this.firstRotorPositionTranslator = new System.Windows.Forms.Label();
            this.secondRotorPositionTranslator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thirdRotorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondRotorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRotorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflectorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRotorPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondRotorPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdRotorPositionInput)).BeginInit();
            this.SuspendLayout();
            // 
            // firstRotorPickerLabel
            // 
            this.firstRotorPickerLabel.AutoSize = true;
            this.firstRotorPickerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstRotorPickerLabel.Location = new System.Drawing.Point(577, 26);
            this.firstRotorPickerLabel.Name = "firstRotorPickerLabel";
            this.firstRotorPickerLabel.Size = new System.Drawing.Size(84, 20);
            this.firstRotorPickerLabel.TabIndex = 0;
            this.firstRotorPickerLabel.Text = "First Rotor";
            // 
            // thirdRotorPickerLabel
            // 
            this.thirdRotorPickerLabel.AutoSize = true;
            this.thirdRotorPickerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thirdRotorPickerLabel.Location = new System.Drawing.Point(303, 26);
            this.thirdRotorPickerLabel.Name = "thirdRotorPickerLabel";
            this.thirdRotorPickerLabel.Size = new System.Drawing.Size(88, 20);
            this.thirdRotorPickerLabel.TabIndex = 1;
            this.thirdRotorPickerLabel.Text = "Third Rotor";
            // 
            // secondRotorPickerLabel
            // 
            this.secondRotorPickerLabel.AutoSize = true;
            this.secondRotorPickerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondRotorPickerLabel.Location = new System.Drawing.Point(437, 26);
            this.secondRotorPickerLabel.Name = "secondRotorPickerLabel";
            this.secondRotorPickerLabel.Size = new System.Drawing.Size(108, 20);
            this.secondRotorPickerLabel.TabIndex = 2;
            this.secondRotorPickerLabel.Text = "Second Rotor";
            // 
            // thirdRotorPicker
            // 
            this.thirdRotorPicker.Location = new System.Drawing.Point(307, 49);
            this.thirdRotorPicker.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.thirdRotorPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thirdRotorPicker.Name = "thirdRotorPicker";
            this.thirdRotorPicker.Size = new System.Drawing.Size(84, 20);
            this.thirdRotorPicker.TabIndex = 3;
            this.thirdRotorPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // secondRotorPicker
            // 
            this.secondRotorPicker.Location = new System.Drawing.Point(441, 49);
            this.secondRotorPicker.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.secondRotorPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondRotorPicker.Name = "secondRotorPicker";
            this.secondRotorPicker.Size = new System.Drawing.Size(84, 20);
            this.secondRotorPicker.TabIndex = 4;
            this.secondRotorPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // firstRotorPicker
            // 
            this.firstRotorPicker.Location = new System.Drawing.Point(577, 49);
            this.firstRotorPicker.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.firstRotorPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstRotorPicker.Name = "firstRotorPicker";
            this.firstRotorPicker.Size = new System.Drawing.Size(84, 20);
            this.firstRotorPicker.TabIndex = 5;
            this.firstRotorPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // reflectorPickerLabel
            // 
            this.reflectorPickerLabel.AutoSize = true;
            this.reflectorPickerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reflectorPickerLabel.Location = new System.Drawing.Point(148, 26);
            this.reflectorPickerLabel.Name = "reflectorPickerLabel";
            this.reflectorPickerLabel.Size = new System.Drawing.Size(74, 20);
            this.reflectorPickerLabel.TabIndex = 6;
            this.reflectorPickerLabel.Text = "Reflector";
            // 
            // reflectorPicker
            // 
            this.reflectorPicker.Location = new System.Drawing.Point(152, 49);
            this.reflectorPicker.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.reflectorPicker.Name = "reflectorPicker";
            this.reflectorPicker.Size = new System.Drawing.Size(84, 20);
            this.reflectorPicker.TabIndex = 7;
            this.reflectorPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uncipheredText
            // 
            this.uncipheredText.Location = new System.Drawing.Point(152, 201);
            this.uncipheredText.Name = "uncipheredText";
            this.uncipheredText.Size = new System.Drawing.Size(215, 133);
            this.uncipheredText.TabIndex = 8;
            this.uncipheredText.Text = "";
            // 
            // cipheredText
            // 
            this.cipheredText.Location = new System.Drawing.Point(405, 201);
            this.cipheredText.Name = "cipheredText";
            this.cipheredText.Size = new System.Drawing.Size(215, 133);
            this.cipheredText.TabIndex = 9;
            this.cipheredText.Text = "";
            // 
            // uncipheredTextLabel
            // 
            this.uncipheredTextLabel.AutoSize = true;
            this.uncipheredTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uncipheredTextLabel.Location = new System.Drawing.Point(197, 178);
            this.uncipheredTextLabel.Name = "uncipheredTextLabel";
            this.uncipheredTextLabel.Size = new System.Drawing.Size(125, 20);
            this.uncipheredTextLabel.TabIndex = 10;
            this.uncipheredTextLabel.Text = "Unciphered Text";
            // 
            // cipheredTextLabel
            // 
            this.cipheredTextLabel.AutoSize = true;
            this.cipheredTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cipheredTextLabel.Location = new System.Drawing.Point(468, 178);
            this.cipheredTextLabel.Name = "cipheredTextLabel";
            this.cipheredTextLabel.Size = new System.Drawing.Size(107, 20);
            this.cipheredTextLabel.TabIndex = 11;
            this.cipheredTextLabel.Text = "Ciphered Text";
            // 
            // commutatorInput
            // 
            this.commutatorInput.Location = new System.Drawing.Point(257, 422);
            this.commutatorInput.Name = "commutatorInput";
            this.commutatorInput.Size = new System.Drawing.Size(262, 20);
            this.commutatorInput.TabIndex = 12;
            // 
            // commutatorsInputLabel
            // 
            this.commutatorsInputLabel.AutoSize = true;
            this.commutatorsInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commutatorsInputLabel.Location = new System.Drawing.Point(253, 399);
            this.commutatorsInputLabel.Name = "commutatorsInputLabel";
            this.commutatorsInputLabel.Size = new System.Drawing.Size(266, 20);
            this.commutatorsInputLabel.TabIndex = 13;
            this.commutatorsInputLabel.Text = "Commutator( format is AA AB AC ...)";
            // 
            // cipherButton
            // 
            this.cipherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cipherButton.Location = new System.Drawing.Point(152, 340);
            this.cipherButton.Name = "cipherButton";
            this.cipherButton.Size = new System.Drawing.Size(80, 34);
            this.cipherButton.TabIndex = 14;
            this.cipherButton.Text = "Cipher";
            this.cipherButton.UseVisualStyleBackColor = true;
            this.cipherButton.Click += new System.EventHandler(this.cipherButton_Click);
            // 
            // uncipherButton
            // 
            this.uncipherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uncipherButton.Location = new System.Drawing.Point(536, 340);
            this.uncipherButton.Name = "uncipherButton";
            this.uncipherButton.Size = new System.Drawing.Size(84, 34);
            this.uncipherButton.TabIndex = 15;
            this.uncipherButton.Text = "Uncipher";
            this.uncipherButton.UseVisualStyleBackColor = true;
            this.uncipherButton.Click += new System.EventHandler(this.uncipherButton_Click);
            // 
            // firstRotorPositionInput
            // 
            this.firstRotorPositionInput.Location = new System.Drawing.Point(578, 103);
            this.firstRotorPositionInput.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.firstRotorPositionInput.Name = "firstRotorPositionInput";
            this.firstRotorPositionInput.Size = new System.Drawing.Size(84, 20);
            this.firstRotorPositionInput.TabIndex = 21;
            this.firstRotorPositionInput.ValueChanged += new System.EventHandler(this.firstRotorPositionInput_ValueChanged);
            // 
            // secondRotorPositionInput
            // 
            this.secondRotorPositionInput.Location = new System.Drawing.Point(444, 103);
            this.secondRotorPositionInput.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.secondRotorPositionInput.Name = "secondRotorPositionInput";
            this.secondRotorPositionInput.Size = new System.Drawing.Size(84, 20);
            this.secondRotorPositionInput.TabIndex = 20;
            this.secondRotorPositionInput.ValueChanged += new System.EventHandler(this.secondRotorPositionInput_ValueChanged);
            // 
            // thirdRotorPositionInput
            // 
            this.thirdRotorPositionInput.Location = new System.Drawing.Point(307, 103);
            this.thirdRotorPositionInput.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.thirdRotorPositionInput.Name = "thirdRotorPositionInput";
            this.thirdRotorPositionInput.Size = new System.Drawing.Size(84, 20);
            this.thirdRotorPositionInput.TabIndex = 19;
            this.thirdRotorPositionInput.ValueChanged += new System.EventHandler(this.thirdRotorPositionInput_ValueChanged);
            // 
            // secondRotorPositionInputLabel
            // 
            this.secondRotorPositionInputLabel.AutoSize = true;
            this.secondRotorPositionInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondRotorPositionInputLabel.Location = new System.Drawing.Point(440, 80);
            this.secondRotorPositionInputLabel.Name = "secondRotorPositionInputLabel";
            this.secondRotorPositionInputLabel.Size = new System.Drawing.Size(65, 20);
            this.secondRotorPositionInputLabel.TabIndex = 18;
            this.secondRotorPositionInputLabel.Text = "Position";
            // 
            // thirdRotorPositionInputLabel
            // 
            this.thirdRotorPositionInputLabel.AutoSize = true;
            this.thirdRotorPositionInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thirdRotorPositionInputLabel.Location = new System.Drawing.Point(303, 80);
            this.thirdRotorPositionInputLabel.Name = "thirdRotorPositionInputLabel";
            this.thirdRotorPositionInputLabel.Size = new System.Drawing.Size(65, 20);
            this.thirdRotorPositionInputLabel.TabIndex = 17;
            this.thirdRotorPositionInputLabel.Text = "Position";
            // 
            // firstRotorPositionInputLabel
            // 
            this.firstRotorPositionInputLabel.AutoSize = true;
            this.firstRotorPositionInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstRotorPositionInputLabel.Location = new System.Drawing.Point(578, 80);
            this.firstRotorPositionInputLabel.Name = "firstRotorPositionInputLabel";
            this.firstRotorPositionInputLabel.Size = new System.Drawing.Size(65, 20);
            this.firstRotorPositionInputLabel.TabIndex = 16;
            this.firstRotorPositionInputLabel.Text = "Position";
            // 
            // thirdRotorPositionTranslator
            // 
            this.thirdRotorPositionTranslator.AutoSize = true;
            this.thirdRotorPositionTranslator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thirdRotorPositionTranslator.Location = new System.Drawing.Point(334, 126);
            this.thirdRotorPositionTranslator.Name = "thirdRotorPositionTranslator";
            this.thirdRotorPositionTranslator.Size = new System.Drawing.Size(20, 20);
            this.thirdRotorPositionTranslator.TabIndex = 22;
            this.thirdRotorPositionTranslator.Text = "A";
            // 
            // firstRotorPositionTranslator
            // 
            this.firstRotorPositionTranslator.AutoSize = true;
            this.firstRotorPositionTranslator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstRotorPositionTranslator.Location = new System.Drawing.Point(609, 126);
            this.firstRotorPositionTranslator.Name = "firstRotorPositionTranslator";
            this.firstRotorPositionTranslator.Size = new System.Drawing.Size(20, 20);
            this.firstRotorPositionTranslator.TabIndex = 23;
            this.firstRotorPositionTranslator.Text = "A";
            // 
            // secondRotorPositionTranslator
            // 
            this.secondRotorPositionTranslator.AutoSize = true;
            this.secondRotorPositionTranslator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondRotorPositionTranslator.Location = new System.Drawing.Point(477, 126);
            this.secondRotorPositionTranslator.Name = "secondRotorPositionTranslator";
            this.secondRotorPositionTranslator.Size = new System.Drawing.Size(20, 20);
            this.secondRotorPositionTranslator.TabIndex = 24;
            this.secondRotorPositionTranslator.Text = "A";
            // 
            // EnigmaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.secondRotorPositionTranslator);
            this.Controls.Add(this.firstRotorPositionTranslator);
            this.Controls.Add(this.thirdRotorPositionTranslator);
            this.Controls.Add(this.firstRotorPositionInput);
            this.Controls.Add(this.secondRotorPositionInput);
            this.Controls.Add(this.thirdRotorPositionInput);
            this.Controls.Add(this.secondRotorPositionInputLabel);
            this.Controls.Add(this.thirdRotorPositionInputLabel);
            this.Controls.Add(this.firstRotorPositionInputLabel);
            this.Controls.Add(this.uncipherButton);
            this.Controls.Add(this.cipherButton);
            this.Controls.Add(this.commutatorsInputLabel);
            this.Controls.Add(this.commutatorInput);
            this.Controls.Add(this.cipheredTextLabel);
            this.Controls.Add(this.uncipheredTextLabel);
            this.Controls.Add(this.cipheredText);
            this.Controls.Add(this.uncipheredText);
            this.Controls.Add(this.reflectorPicker);
            this.Controls.Add(this.reflectorPickerLabel);
            this.Controls.Add(this.firstRotorPicker);
            this.Controls.Add(this.secondRotorPicker);
            this.Controls.Add(this.thirdRotorPicker);
            this.Controls.Add(this.secondRotorPickerLabel);
            this.Controls.Add(this.thirdRotorPickerLabel);
            this.Controls.Add(this.firstRotorPickerLabel);
            this.Name = "EnigmaForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.thirdRotorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondRotorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRotorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflectorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRotorPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondRotorPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdRotorPositionInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstRotorPickerLabel;
        private System.Windows.Forms.Label thirdRotorPickerLabel;
        private System.Windows.Forms.Label secondRotorPickerLabel;
        private System.Windows.Forms.NumericUpDown thirdRotorPicker;
        private System.Windows.Forms.NumericUpDown secondRotorPicker;
        private System.Windows.Forms.NumericUpDown firstRotorPicker;
        private System.Windows.Forms.Label reflectorPickerLabel;
        private System.Windows.Forms.NumericUpDown reflectorPicker;
        private System.Windows.Forms.RichTextBox uncipheredText;
        private System.Windows.Forms.RichTextBox cipheredText;
        private System.Windows.Forms.Label uncipheredTextLabel;
        private System.Windows.Forms.Label cipheredTextLabel;
        private System.Windows.Forms.TextBox commutatorInput;
        private System.Windows.Forms.Label commutatorsInputLabel;
        private System.Windows.Forms.Button cipherButton;
        private System.Windows.Forms.Button uncipherButton;
        private System.Windows.Forms.NumericUpDown firstRotorPositionInput;
        private System.Windows.Forms.NumericUpDown secondRotorPositionInput;
        private System.Windows.Forms.NumericUpDown thirdRotorPositionInput;
        private System.Windows.Forms.Label secondRotorPositionInputLabel;
        private System.Windows.Forms.Label thirdRotorPositionInputLabel;
        private System.Windows.Forms.Label firstRotorPositionInputLabel;
        private System.Windows.Forms.Label thirdRotorPositionTranslator;
        private System.Windows.Forms.Label firstRotorPositionTranslator;
        private System.Windows.Forms.Label secondRotorPositionTranslator;
    }
}

