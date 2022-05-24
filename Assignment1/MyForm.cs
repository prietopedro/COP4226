using System;
using System.Windows.Forms;
using System.Drawing;
namespace Assignment1
{
    class MyForm : Form
    {
        string name;
        public MyForm(string title, string name)
        {
            this.name = name;
            this.Text = title; // Title Bar of Form
            this.Size = new Size(990, 510);

            // Bottom Panel
            var bottomPanel = new Panel();
            bottomPanel.BackColor = System.Drawing.Color.LightGray;
            bottomPanel.Height = 30;
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.AccessibleName = "BottomPanel";

            // Bottom Panel Label - Command Line Argument Name 
            var bottomPanelLabel = new Label();
            bottomPanelLabel.Text = this.name;
            bottomPanelLabel.AccessibleName = "BottomPanelLabel";
            bottomPanelLabel.Dock = DockStyle.Top | DockStyle.Right;
            bottomPanel.Controls.Add(bottomPanelLabel);

            // Main Panel
            var mainPanel = new Panel();
            mainPanel.BackColor = System.Drawing.Color.White;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AccessibleName = "MainPanel";

            // TEXTBOX LABEL
            var commentLabel = new Label();
            commentLabel.Text = "Comment:";
            commentLabel.AccessibleName = "CommentLabel";
            commentLabel.Font = new Font(new System.Drawing.FontFamily("Arial"), (float)15, FontStyle.Italic | FontStyle.Bold);
            commentLabel.Width = 120;
            commentLabel.Top = 15;
            commentLabel.Left = 15;
            mainPanel.Controls.Add(commentLabel);

            // TEXTBOX
            var comment = new TextBox();
            comment.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            comment.Top = 15;
            comment.AccessibleName = "CommentTextBox";
            comment.Parent = commentLabel;
            comment.Left = commentLabel.Left + commentLabel.Width;
            comment.Width = 1;

            mainPanel.Controls.Add(comment);

            // TEXTBOX SUBMIT BUTTON
            var commentButton = new Button();
            commentButton.Left = comment.Left + comment.Width;
            commentButton.Text = "Submit";
            commentButton.AccessibleName = "CommentButton";
            commentButton.Anchor = AnchorStyles.Right;
            commentButton.Top = 220;
            commentButton.Click += delegate (object sender, EventArgs e) { HandleClick(sender, e, comment.Text); };
            mainPanel.Controls.Add(commentButton);

            this.Controls.Add(mainPanel);

            // Not sure if this is what was being asked by:
            // Add an appropriate control to the panel and list all the controls in the entire application. Create the list dynamically by using form properties and loops.
            ListBox listBox1 = new ListBox();
            listBox1.Dock = DockStyle.Left;
            listBox1.BeginUpdate();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                listBox1.Items.Add(this.Controls[i].AccessibleName);

                for (int j = 0; j < this.Controls[i].Controls.Count; j++)
                {
                    listBox1.Items.Add(this.Controls[i].Controls[j].AccessibleName);
                }
            }
            listBox1.AccessibleName = "ListBox";
            listBox1.Items.Add(bottomPanel.AccessibleName);
            listBox1.Items.Add(bottomPanelLabel.AccessibleName);
            listBox1.Items.Add(listBox1.AccessibleName);
            listBox1.EndUpdate();

            bottomPanel.Controls.Add(listBox1);
            this.Controls.Add(bottomPanel);
        }

        // HANDLE CLICK METHOD. It will show a dialog or message box with the text entered in the textbox
        private void HandleClick(object sender, EventArgs e, String text)
        {
            if (text == "") MessageBox.Show("Enter text in textbox");
            else MessageBox.Show(text);
        }
    }
}