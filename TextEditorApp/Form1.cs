namespace TextEditorApp;

public partial class Form1 : Form
{
    private string currentFile = "";

    public Form1()
    {
        InitializeComponent();
    }

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        richTextBox.Clear();
        currentFile = "";
        Text = "Text Editor";
    }

    private void OpenMenuItem_Click(object? sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            currentFile = openFileDialog.FileName;
            if (currentFile.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
            {
                richTextBox.LoadFile(currentFile, RichTextBoxStreamType.RichText);
            }
            else
            {
                richTextBox.Text = File.ReadAllText(currentFile);
            }
            Text = "Text Editor - " + Path.GetFileName(currentFile);
        }
    }

    private void SaveMenuItem_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentFile))
        {
            SaveAsMenuItem_Click(sender, e);
        }
        else
        {
            SaveFile();
        }
    }

    private void SaveAsMenuItem_Click(object? sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            currentFile = saveFileDialog.FileName;
            SaveFile();
            Text = "Text Editor - " + Path.GetFileName(currentFile);
        }
    }

    private void SaveFile()
    {
        if (currentFile.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
        {
            richTextBox.SaveFile(currentFile, RichTextBoxStreamType.RichText);
        }
        else
        {
            File.WriteAllText(currentFile, richTextBox.Text);
        }
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    private void UndoMenuItem_Click(object? sender, EventArgs e)
    {
        richTextBox.Undo();
    }

    private void CutMenuItem_Click(object? sender, EventArgs e)
    {
        richTextBox.Cut();
    }

    private void CopyMenuItem_Click(object? sender, EventArgs e)
    {
        richTextBox.Copy();
    }

    private void PasteMenuItem_Click(object? sender, EventArgs e)
    {
        richTextBox.Paste();
    }

    private void FontMenuItem_Click(object? sender, EventArgs e)
    {
        fontDialog.Font = richTextBox.SelectionFont ?? richTextBox.Font;
        if (fontDialog.ShowDialog() == DialogResult.OK)
        {
            richTextBox.SelectionFont = fontDialog.Font;
        }
    }

    private void ColorMenuItem_Click(object? sender, EventArgs e)
    {
        colorDialog.Color = richTextBox.SelectionColor;
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            richTextBox.SelectionColor = colorDialog.Color;
        }
    }
}
