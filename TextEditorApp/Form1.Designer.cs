namespace TextEditorApp;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        
        menuStrip = new MenuStrip();
        fileMenu = new ToolStripMenuItem();
        newMenuItem = new ToolStripMenuItem();
        openMenuItem = new ToolStripMenuItem();
        saveMenuItem = new ToolStripMenuItem();
        saveAsMenuItem = new ToolStripMenuItem();
        exitMenuItem = new ToolStripMenuItem();
        editMenu = new ToolStripMenuItem();
        undoMenuItem = new ToolStripMenuItem();
        cutMenuItem = new ToolStripMenuItem();
        copyMenuItem = new ToolStripMenuItem();
        pasteMenuItem = new ToolStripMenuItem();
        formatMenu = new ToolStripMenuItem();
        fontMenuItem = new ToolStripMenuItem();
        colorMenuItem = new ToolStripMenuItem();
        richTextBox = new RichTextBox();
        openFileDialog = new OpenFileDialog();
        saveFileDialog = new SaveFileDialog();
        fontDialog = new FontDialog();
        colorDialog = new ColorDialog();
        
        menuStrip.SuspendLayout();
        SuspendLayout();
        
        menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, formatMenu });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(800, 24);
        menuStrip.TabIndex = 0;
        
        fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newMenuItem, openMenuItem, saveMenuItem, saveAsMenuItem, new ToolStripSeparator(), exitMenuItem });
        fileMenu.Name = "fileMenu";
        fileMenu.Text = "&File";
        
        newMenuItem.Name = "newMenuItem";
        newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        newMenuItem.Text = "&New";
        newMenuItem.Click += NewMenuItem_Click;
        
        openMenuItem.Name = "openMenuItem";
        openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        openMenuItem.Text = "&Open";
        openMenuItem.Click += OpenMenuItem_Click;
        
        saveMenuItem.Name = "saveMenuItem";
        saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveMenuItem.Text = "&Save";
        saveMenuItem.Click += SaveMenuItem_Click;
        
        saveAsMenuItem.Name = "saveAsMenuItem";
        saveAsMenuItem.Text = "Save &As";
        saveAsMenuItem.Click += SaveAsMenuItem_Click;
        
        exitMenuItem.Name = "exitMenuItem";
        exitMenuItem.Text = "E&xit";
        exitMenuItem.Click += ExitMenuItem_Click;
        
        editMenu.DropDownItems.AddRange(new ToolStripItem[] { undoMenuItem, new ToolStripSeparator(), cutMenuItem, copyMenuItem, pasteMenuItem });
        editMenu.Name = "editMenu";
        editMenu.Text = "&Edit";
        
        undoMenuItem.Name = "undoMenuItem";
        undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
        undoMenuItem.Text = "&Undo";
        undoMenuItem.Click += UndoMenuItem_Click;
        
        cutMenuItem.Name = "cutMenuItem";
        cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
        cutMenuItem.Text = "Cu&t";
        cutMenuItem.Click += CutMenuItem_Click;
        
        copyMenuItem.Name = "copyMenuItem";
        copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
        copyMenuItem.Text = "&Copy";
        copyMenuItem.Click += CopyMenuItem_Click;
        
        pasteMenuItem.Name = "pasteMenuItem";
        pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
        pasteMenuItem.Text = "&Paste";
        pasteMenuItem.Click += PasteMenuItem_Click;
        
        formatMenu.DropDownItems.AddRange(new ToolStripItem[] { fontMenuItem, colorMenuItem });
        formatMenu.Name = "formatMenu";
        formatMenu.Text = "F&ormat";
        
        fontMenuItem.Name = "fontMenuItem";
        fontMenuItem.Text = "&Font...";
        fontMenuItem.Click += FontMenuItem_Click;
        
        colorMenuItem.Name = "colorMenuItem";
        colorMenuItem.Text = "&Color...";
        colorMenuItem.Click += ColorMenuItem_Click;
        
        richTextBox.Dock = DockStyle.Fill;
        richTextBox.Location = new Point(0, 24);
        richTextBox.Name = "richTextBox";
        richTextBox.Size = new Size(800, 426);
        richTextBox.TabIndex = 1;
        richTextBox.Text = "";
        
        openFileDialog.Filter = "Text Files|*.txt|Rich Text Files|*.rtf|All Files|*.*";
        saveFileDialog.Filter = "Text Files|*.txt|Rich Text Files|*.rtf|All Files|*.*";
        
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(richTextBox);
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        Name = "Form1";
        Text = "Text Editor";
        
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenu;
    private ToolStripMenuItem newMenuItem;
    private ToolStripMenuItem openMenuItem;
    private ToolStripMenuItem saveMenuItem;
    private ToolStripMenuItem saveAsMenuItem;
    private ToolStripMenuItem exitMenuItem;
    private ToolStripMenuItem editMenu;
    private ToolStripMenuItem undoMenuItem;
    private ToolStripMenuItem cutMenuItem;
    private ToolStripMenuItem copyMenuItem;
    private ToolStripMenuItem pasteMenuItem;
    private ToolStripMenuItem formatMenu;
    private ToolStripMenuItem fontMenuItem;
    private ToolStripMenuItem colorMenuItem;
    private RichTextBox richTextBox;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private FontDialog fontDialog;
    private ColorDialog colorDialog;
}
