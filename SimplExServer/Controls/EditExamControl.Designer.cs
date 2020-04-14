namespace SimplExServer.Controls
{
    partial class EditExamControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.secondsUD = new System.Windows.Forms.NumericUpDown();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.minuteUD = new System.Windows.Forms.NumericUpDown();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.repeatBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordCheck = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.firstNumberUD = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.hourUD = new System.Windows.Forms.NumericUpDown();
            this.restrictLabel = new System.Windows.Forms.Label();
            this.timeRestrictCheck = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.creatorPatronymicBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.creatorSurnameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.creatorNameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.disciplineBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.disciplineToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.aNameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.aSurnameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.aPatronymicToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.passwordToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.repeatToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.secondsUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNumberUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourUD)).BeginInit();
            this.SuspendLayout();
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondsLabel.Location = new System.Drawing.Point(417, 271);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(58, 15);
            this.secondsLabel.TabIndex = 61;
            this.secondsLabel.Text = "Секунды:";
            this.secondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // secondsUD
            // 
            this.secondsUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondsUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondsUD.Location = new System.Drawing.Point(478, 270);
            this.secondsUD.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secondsUD.Name = "secondsUD";
            this.secondsUD.Size = new System.Drawing.Size(75, 21);
            this.secondsUD.TabIndex = 60;
            this.secondsUD.ValueChanged += new System.EventHandler(this.PropsChanged);
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minutesLabel.Location = new System.Drawing.Point(278, 271);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(55, 15);
            this.minutesLabel.TabIndex = 59;
            this.minutesLabel.Text = "Минуты:";
            this.minutesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minuteUD
            // 
            this.minuteUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minuteUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minuteUD.Location = new System.Drawing.Point(339, 270);
            this.minuteUD.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minuteUD.Name = "minuteUD";
            this.minuteUD.Size = new System.Drawing.Size(75, 21);
            this.minuteUD.TabIndex = 58;
            this.minuteUD.ValueChanged += new System.EventHandler(this.PropsChanged);
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hoursLabel.Location = new System.Drawing.Point(155, 271);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(39, 15);
            this.hoursLabel.TabIndex = 57;
            this.hoursLabel.Text = "Часы:";
            this.hoursLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatLabel.Location = new System.Drawing.Point(12, 391);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(136, 19);
            this.repeatLabel.TabIndex = 55;
            this.repeatLabel.Text = "Повторите пароль:";
            this.repeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // repeatBox
            // 
            this.repeatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.repeatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatBox.Location = new System.Drawing.Point(154, 389);
            this.repeatBox.MaxLength = 20;
            this.repeatBox.Name = "repeatBox";
            this.repeatBox.PasswordChar = '•';
            this.repeatBox.ShortcutsEnabled = false;
            this.repeatBox.Size = new System.Drawing.Size(566, 21);
            this.repeatBox.TabIndex = 56;
            this.repeatBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLabel.Location = new System.Drawing.Point(85, 364);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(63, 19);
            this.passwordLabel.TabIndex = 53;
            this.passwordLabel.Text = "Пароль:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordBox.Location = new System.Drawing.Point(154, 362);
            this.passwordBox.MaxLength = 20;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '•';
            this.passwordBox.ShortcutsEnabled = false;
            this.passwordBox.Size = new System.Drawing.Size(566, 21);
            this.passwordBox.TabIndex = 54;
            this.passwordBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // passwordCheck
            // 
            this.passwordCheck.AutoSize = true;
            this.passwordCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passwordCheck.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordCheck.Location = new System.Drawing.Point(12, 341);
            this.passwordCheck.Name = "passwordCheck";
            this.passwordCheck.Size = new System.Drawing.Size(171, 23);
            this.passwordCheck.TabIndex = 52;
            this.passwordCheck.Text = "Использовать пароль";
            this.passwordCheck.UseVisualStyleBackColor = true;
            this.passwordCheck.CheckedChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(3, 319);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 19);
            this.label14.TabIndex = 51;
            this.label14.Text = "Защита:";
            // 
            // firstNumberUD
            // 
            this.firstNumberUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNumberUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstNumberUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNumberUD.Location = new System.Drawing.Point(154, 294);
            this.firstNumberUD.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.firstNumberUD.Name = "firstNumberUD";
            this.firstNumberUD.Size = new System.Drawing.Size(566, 21);
            this.firstNumberUD.TabIndex = 50;
            this.firstNumberUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstNumberUD.ValueChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(3, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 19);
            this.label13.TabIndex = 49;
            this.label13.Text = "№ первого вопроса:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hourUD
            // 
            this.hourUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hourUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hourUD.Location = new System.Drawing.Point(200, 270);
            this.hourUD.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.hourUD.Name = "hourUD";
            this.hourUD.Size = new System.Drawing.Size(75, 21);
            this.hourUD.TabIndex = 48;
            this.hourUD.ValueChanged += new System.EventHandler(this.PropsChanged);
            // 
            // restrictLabel
            // 
            this.restrictLabel.AutoSize = true;
            this.restrictLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.restrictLabel.Location = new System.Drawing.Point(43, 268);
            this.restrictLabel.Name = "restrictLabel";
            this.restrictLabel.Size = new System.Drawing.Size(106, 19);
            this.restrictLabel.TabIndex = 47;
            this.restrictLabel.Text = "Ограничение:";
            this.restrictLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeRestrictCheck
            // 
            this.timeRestrictCheck.AutoSize = true;
            this.timeRestrictCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeRestrictCheck.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeRestrictCheck.Location = new System.Drawing.Point(12, 243);
            this.timeRestrictCheck.Name = "timeRestrictCheck";
            this.timeRestrictCheck.Size = new System.Drawing.Size(203, 23);
            this.timeRestrictCheck.TabIndex = 46;
            this.timeRestrictCheck.Text = "Ограничение по времени";
            this.timeRestrictCheck.UseVisualStyleBackColor = true;
            this.timeRestrictCheck.CheckedChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 19);
            this.label11.TabIndex = 45;
            this.label11.Text = "Параметры выполнения:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 19);
            this.label10.TabIndex = 44;
            this.label10.Text = "Информация об авторе:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionBox.Location = new System.Drawing.Point(154, 82);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(566, 40);
            this.descriptionBox.TabIndex = 43;
            this.descriptionBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(67, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 19);
            this.label9.TabIndex = 42;
            this.label9.Text = "Описание:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // creatorPatronymicBox
            // 
            this.creatorPatronymicBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creatorPatronymicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creatorPatronymicBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creatorPatronymicBox.Location = new System.Drawing.Point(154, 198);
            this.creatorPatronymicBox.Name = "creatorPatronymicBox";
            this.creatorPatronymicBox.Size = new System.Drawing.Size(566, 21);
            this.creatorPatronymicBox.TabIndex = 41;
            this.creatorPatronymicBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(23, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 19);
            this.label8.TabIndex = 40;
            this.label8.Text = "Отчество Автора:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // creatorSurnameBox
            // 
            this.creatorSurnameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creatorSurnameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creatorSurnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creatorSurnameBox.Location = new System.Drawing.Point(154, 171);
            this.creatorSurnameBox.Name = "creatorSurnameBox";
            this.creatorSurnameBox.Size = new System.Drawing.Size(566, 21);
            this.creatorSurnameBox.TabIndex = 39;
            this.creatorSurnameBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(21, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 19);
            this.label7.TabIndex = 38;
            this.label7.Text = "Фамилия Автора:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // creatorNameBox
            // 
            this.creatorNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creatorNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creatorNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creatorNameBox.Location = new System.Drawing.Point(154, 144);
            this.creatorNameBox.Name = "creatorNameBox";
            this.creatorNameBox.Size = new System.Drawing.Size(566, 21);
            this.creatorNameBox.TabIndex = 37;
            this.creatorNameBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(56, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 36;
            this.label6.Text = "Имя Автора:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // disciplineBox
            // 
            this.disciplineBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disciplineBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disciplineBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disciplineBox.Location = new System.Drawing.Point(154, 55);
            this.disciplineBox.Name = "disciplineBox";
            this.disciplineBox.Size = new System.Drawing.Size(566, 21);
            this.disciplineBox.TabIndex = 35;
            this.disciplineBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(50, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Дисциплина:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(154, 28);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(566, 21);
            this.nameBox.TabIndex = 33;
            this.nameBox.TextChanged += new System.EventHandler(this.PropsChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(30, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "Название теста:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "Общие параметры:";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(578, 420);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(142, 23);
            this.saveButton.TabIndex = 62;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(3, 420);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(142, 23);
            this.cancelButton.TabIndex = 63;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // nameToolTip
            // 
            this.nameToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.nameToolTip.ToolTipTitle = "Неверное название теста";
            // 
            // disciplineToolTip
            // 
            this.disciplineToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.disciplineToolTip.ToolTipTitle = "Неверная дисциплина";
            // 
            // aNameToolTip
            // 
            this.aNameToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.aNameToolTip.ToolTipTitle = "Неверное имя автора";
            // 
            // aSurnameToolTip
            // 
            this.aSurnameToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.aSurnameToolTip.ToolTipTitle = "Неверная фамилия автора";
            // 
            // aPatronymicToolTip
            // 
            this.aPatronymicToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.aPatronymicToolTip.ToolTipTitle = "Неверное отчество автора";
            // 
            // passwordToolTip
            // 
            this.passwordToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.passwordToolTip.ToolTipTitle = "Неверный пароль";
            // 
            // repeatToolTip
            // 
            this.repeatToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.repeatToolTip.ToolTipTitle = "Неверное подтверждение пароля";
            // 
            // EditExamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.secondsLabel);
            this.Controls.Add(this.secondsUD);
            this.Controls.Add(this.minutesLabel);
            this.Controls.Add(this.minuteUD);
            this.Controls.Add(this.hoursLabel);
            this.Controls.Add(this.repeatLabel);
            this.Controls.Add(this.repeatBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.passwordCheck);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.firstNumberUD);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.hourUD);
            this.Controls.Add(this.restrictLabel);
            this.Controls.Add(this.timeRestrictCheck);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.creatorPatronymicBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.creatorSurnameBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.creatorNameBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.disciplineBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "EditExamControl";
            this.Size = new System.Drawing.Size(725, 449);
            ((System.ComponentModel.ISupportInitialize)(this.secondsUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNumberUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.NumericUpDown secondsUD;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.NumericUpDown minuteUD;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.TextBox repeatBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.CheckBox passwordCheck;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown firstNumberUD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown hourUD;
        private System.Windows.Forms.Label restrictLabel;
        private System.Windows.Forms.CheckBox timeRestrictCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox creatorPatronymicBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox creatorSurnameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox creatorNameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox disciplineBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip nameToolTip;
        private System.Windows.Forms.ToolTip disciplineToolTip;
        private System.Windows.Forms.ToolTip aNameToolTip;
        private System.Windows.Forms.ToolTip aSurnameToolTip;
        private System.Windows.Forms.ToolTip aPatronymicToolTip;
        private System.Windows.Forms.ToolTip passwordToolTip;
        private System.Windows.Forms.ToolTip repeatToolTip;
    }
}
