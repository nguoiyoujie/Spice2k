
using Dune2000.Editor.UI.Editors;
using Dune2000.Editor.Util;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Forms
{
  public partial class MainEditor : Form
  {
    public MainEditor()
    {
      InitializeComponent();
      ucEditorSelector1.EditorChanged += SwitchEditor;
      ucEditorController.EditorChanged += ucEditorSelector1.UpdateEditor;

      DoubleBuffered = true;

      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    private IEditorControl _current;

    private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!ucEditorSelector1.Closing(ucEditorController, SwitchEditor))
      {
        e.Cancel = true;
        return;
      }
    }

    private void SwitchEditor(IEditorControl editor)
    {
      this.SuspendDrawing();
      SuspendLayout();
      if (_current is Control c)
      {
        c.Visible = false;
        c.Enabled = false;
        pEditor.Controls.Remove(c);
        _current = null;
      }

      if (editor is Control e)
      {
        _current = editor;
        e.Visible = true;
        e.Enabled = true;
        e.Dock = DockStyle.Fill;
        pEditor.Controls.Add(e);
        ucEditorController.SetEditor(editor);
      }
      ResumeLayout();
      this.ResumeDrawing();
    }
  }
}
