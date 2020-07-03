using Dune2000.Launcher.UI.UserControls;
using Dune2000.Launcher.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.Forms
{
  public partial class GameForm : Form
  {
    public readonly Engine Engine;
    private readonly Stack<Control> Screens = new Stack<Control>();
    public static readonly UIPipeline UIPipeline = new UIPipeline(100);
    private readonly List<Control> _animlock = new List<Control>();
    private readonly object _animlocker = new object();
    public bool ShowConfirmClose = true;

    public GameForm(Engine engine)
    {
      InitializeComponent();
      Engine = engine;
      Init();
      Focus(); // Form doesn't get the focus event at first load, for some reason. Needed to have the WndProc override work properly.
      KeyPreview = true;
    }

    public Control Current { get { return (Screens == null || Screens.Count == 0) ? null : Screens.Peek(); } }

    private void Init()
    {
      Engine.EncounteredError += Throw;

      MainMenuScreen mainMenu = new MainMenuScreen();
      Push(mainMenu);
    }

    public void FadeIn(TransitionStyle transition, Control control, Action next)
    {
      if (transition == TransitionStyle.NOFADE || ClientRectangle.IsEmpty)
      {
        next?.Invoke();
        return;
      }
      else
      {
        fadePanel.CaptureForeground(control ?? this);
        fadePanel.BringToFront();
        fadePanel.FadeFinished = () => next?.Invoke();
        switch (transition)
        {
          case TransitionStyle.FADE_BLACK:
            fadePanel.SetFade(Globals.MENU_FADE_FRAMES, FadeStyle.FADEIN_FROM_BLACK);
            break;

          case TransitionStyle.FADE_TWEEN:
            fadePanel.SetFade(Globals.MENU_FADE_FRAMES, FadeStyle.FADEIN_FROM_BACKGROUND);
            break;
        }
      }
    }

    public void FadeOut(TransitionStyle transition, Action next)
    {
      if (transition == TransitionStyle.NOFADE || ClientRectangle.IsEmpty)
      {
        next?.Invoke();
        return;
      }
      else
      {
        fadePanel.CaptureBackground(this);
        switch (transition)
        {
          case TransitionStyle.FADE_BLACK:
            fadePanel.BringToFront();
            fadePanel.FadeFinished = () => next?.Invoke();
            fadePanel.SetFade(Globals.MENU_FADE_FRAMES, FadeStyle.FADEOUT_TO_BLACK);
            break;

          case TransitionStyle.FADE_TWEEN:
            next?.Invoke();
            return;
        }
      }
    }

    public void Push(Control control, TransitionStyle transition = TransitionStyle.NOFADE)
    {
      this.SuspendDrawing();
      FadeOut(transition, () =>
      {
        this.SuspendDrawing();
        PushInner(control);
        FadeIn(transition, control,  null);
        this.ResumeDrawing();
      });
      this.ResumeDrawing();
    }

    public void Pop(TransitionStyle transition = TransitionStyle.NOFADE)
    {
      // If there is nothing, do nothing
      if (Screens.Count == 0) { return; }

      this.SuspendDrawing();
      FadeOut(transition, () =>
      {
        this.SuspendDrawing();
        PopInner();
        FadeIn(transition, Current, null);
        this.ResumeDrawing();
      });
      this.ResumeDrawing();
    }

    public void Remove(Control control, TransitionStyle transition = TransitionStyle.NOFADE)
    {
      // If there is nothing, do nothing
      if (!Screens.Contains(control)) { return; }

      // Peek the foremost control
      Control foremost = Screens.Peek();

      // if this is the topmost element, perform a Pop instead
      if (foremost == control)
      {
        Pop(transition);
        return;
      }

      this.SuspendDrawing();
      FadeOut(transition, () =>
      {
        this.SuspendDrawing();
        RemoveInner(control);
        FadeIn(transition, Current, null);
        this.ResumeDrawing();
      });
      this.ResumeDrawing();
    }

    private void PushInner(Control control)
    {
      // disable the current control
      if (Screens.Count > 0)
      {
        Control prev = Screens.Peek();
        if (prev != null)
        {
          prev.Enabled = false;
          if (control.Dock == DockStyle.Fill) { prev.Visible = false; }
          if (prev is ILinkedControl prevLinkedControl) { prevLinkedControl.Deactivate(Engine); }
        }
      }

      // link the control to our controllers
      ILinkedControl linkedControl = control as ILinkedControl;
      linkedControl?.Link(Engine);
      linkedControl?.Link(this);

      // Push in the new control
      Screens.Push(control);
      Controls.Add(control);
      control.BringToFront();
      control.Enabled = true;
      linkedControl?.HandleFormResize(Size);
      CenterControl(control);

      // Activate the control
      linkedControl?.Activate(Engine, null);
    }

    private void PopInner()
    {
      // Pop the foremost control
      Control current = Screens.Pop();

      // Deactivate the control
      ILinkedControl linkedControl = current as ILinkedControl;
      linkedControl?.Deactivate(Engine);

      current.Enabled = false;
      Controls.Remove(current);

      // re-enable the current control, if any
      if (Screens.Count > 0)
      {
        Control prev = Screens.Peek();
        if (prev != null)
        {
          prev.Enabled = true;
          prev.Visible = true;

          ILinkedControl prevLinkedControl = prev as ILinkedControl;
          prevLinkedControl?.Activate(Engine, current);
        }
      }  
      current.Dispose();
    }

    private void RemoveInner(Control control)
    {
      // Remove the control
      Stack<Control> transfer = new Stack<Control>();
      while (Screens.Count > 0)
      {
        Control t = Screens.Pop();
        if (t == control)
          break;
        else
          transfer.Push(t);
      }

      while (transfer.Count > 0)
      {
        Screens.Push(transfer.Pop());
      }

      Controls.Remove(control);
      control.Dispose();
    }

    public void Popup(Control control, bool modal)
    {
      PopupForm pform = new PopupForm(control)
      {
        TopMost = true
      };
      if (modal)
      {
        pform.ShowDialog();
      }
      else
      {
        pform.Show();
      }
    }

    public void Throw(string errorMessage, Exception ex)
    {
      ErrorScreen errorScreen = new ErrorScreen();
      errorScreen.SetError(Resource.Strings.ErrorEncountered, errorMessage);
      Popup(errorScreen, true);
    }

    private void GameForm_SizeChanged(object sender, EventArgs e)
    {
      // in case the current control is not set to fill the entire space, center its window
      if (Screens.Count > 0)
      {
        Control current = Screens.Peek();
        (current as ILinkedControl)?.HandleFormResize(Size);
        CenterControl(current);
      }
    }

    private void CenterControl(Control control)
    {
      if (control != null && control.Dock != DockStyle.Fill)
      {
        control.Location = new Point((Width - control.Size.Width) / 2, (Height - control.Size.Height) / 2);
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (Enabled)
      {
        if (Screens.Peek() is ILinkedControl linkedControl)
        {
          linkedControl.HandleKey(keyData);
          return true;
        };
      }

      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Tick(object sender, EventArgs e)
    {
      UIPipeline.Run();
    }

    private const int WM_KEYDOWN = 0x0100;
    private const int WM_KEYUP = 0x0101;
    private const int WM_LBUTTONDOWN = 0x0201;
    private const int WM_LBUTTONUP = 0x0202;
    private const int WM_LBUTTONDBLCLK = 0x0203;
    private const int WM_RBUTTONDOWN = 0x0204;
    private const int WM_RBUTTONUP = 0x0205;
    private const int WM_RBUTTONDBLCLK = 0x0206;

    protected override void WndProc(ref Message m)
    {
      if (_animlock.Count != 0)
      {
        if (m.Msg == WM_KEYDOWN
         //|| m.Msg == WM_KEYUP
         || m.Msg == WM_LBUTTONDOWN
         //|| m.Msg == WM_LBUTTONUP
         || m.Msg == WM_LBUTTONDBLCLK
         || m.Msg == WM_RBUTTONDOWN
         //|| m.Msg == WM_RBUTTONUP
         || m.Msg == WM_RBUTTONDBLCLK
           )
        {
          return;
        }
      }
      base.WndProc(ref m);
    }

    public void Lock(Control c)
    {
      lock(_animlocker)
        if (!_animlock.Contains(c))
          _animlock.Add(c);
    }

    public void Unlock(Control c)
    {
      lock(_animlocker)
        _animlock.Remove(c);
    }

    private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (ShowConfirmClose)
      {
        if (MessageBox.Show("Are you sure you want to close Dune 2000 launcher?", "Dune 2000 launcher", MessageBoxButtons.YesNo) != DialogResult.Yes)
        {
          e.Cancel = true;
        }
      }
    }
  }
}
