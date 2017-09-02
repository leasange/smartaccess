using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace Li.Controls
{
    public partial class VerTextBox :MaskedTextBoxAdv
    {
        private string _verTextFormat = null;
        private string _defaultText = "";
        private bool _isShowDefault = false;
        public bool IsShowDefault
        {
            get { return _isShowDefault; }
            set
            { 
                _isShowDefault = value;
                if (_isShowDefault)
                {
                    this.Text = _defaultText;
                }
            }
        }
        public string DefaultText
        {
            get { return _defaultText; }
        }
        public string VerTextFormat
        {
            get { return _verTextFormat; }
            set
            {
                _verTextFormat = value;
                if (string.IsNullOrWhiteSpace(_verTextFormat))
                {
                    this.Mask = "";
                }
                else
                {
                    var ttt = _verTextFormat.Split(new string[] { "[A]", "[a]", "[0]", "[N]", "[n]" }, StringSplitOptions.None);
                    int index = 0;
                    string mask = "";
                    string masked="09#L?&CaA.,:/$<>|/\\";
                    string def = "";
                    for (int i = 0; i < ttt.Length-1; i++)
                    {
                        if (ttt[i]!="")
                        {
                            foreach (var item in ttt[i])
                            {
                                if (masked.Contains(item))
                                {
                                    mask += "\\";
                                }
                                mask +=item;
                                def += item;
                            }
                            index += ttt[i].Length;
                        }
                        string sp = _verTextFormat.Substring(index, 3);
                        index += 3;
                        switch (sp)
                        {
                            case "[A]":
                                mask += ">L|";
                                def += "A";
                                break;
                            case "[a]":
                                mask += "<L|";
                                def += "a";
                                break;
                            case "[0]":
                                mask += "0";
                                def += "0";
                                break;
                            case "[N]":
                                mask += ">A|";
                                def += "N";
                                break;
                            case "[n]":
                                mask += "<A|";
                                def += "n";
                                break;
                            default:
                                break;
                        }
                    }
                    if (ttt[ttt.Length-1] != "")
                    {
                        foreach (var item in ttt[ttt.Length - 1])
                        {
                            mask += "\\" + item;
                            def += item;
                        }
                    }
                    if (this.Text == "")
                    {
                        this.Text = def;
                    }
                    _defaultText = def;
                    if (_isShowDefault)
                    {
                        this.Text = _defaultText;
                    }
                    this.Mask = mask;

                }
            }
        }
        public VerTextBox()
        {
            InitializeComponent();
            this.MaskInputRejected += VerTextBox_MaskInputRejected;
        }

        void VerTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}
