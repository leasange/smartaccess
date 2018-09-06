using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Li.Controls
{
    public partial class AdvTreeEx : DevComponents.AdvTree.AdvTree
    {
        private bool mCheckBoxVisible = false;
        public bool CheckBoxVisible
        {
            get
            {
                return mCheckBoxVisible;
            }
            set
            {
                mCheckBoxVisible = value;
                foreach (DevComponents.AdvTree.Node node in this.Nodes)
                {
                    SetNodeCheckBox(node, value);
                }
            }
        }
        public AdvTreeEx()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 更新节点状态,如果节点的显示状态不对，请调用此函数
        /// </summary>
        public void UpdateNodesState()
        {
            foreach (DevComponents.AdvTree.Node node in this.Nodes)
            {
                SetNodeCheckBox(node, mCheckBoxVisible);
            }
        }

        private void SetNodeCheckBox(DevComponents.AdvTree.Node node, bool checkBoxVisible)
        {
            node.CheckBoxVisible = checkBoxVisible;
            if (checkBoxVisible) node.Checked = false;
            foreach (DevComponents.AdvTree.Node chNode in node.Nodes)
            {
                SetNodeCheckBox(chNode, checkBoxVisible);
            }
        }

        private void AdvTreeEx_AfterNodeInsert(object sender, DevComponents.AdvTree.TreeNodeCollectionEventArgs e)
        {
            SetNodeCheckBox(e.Node, mCheckBoxVisible);
        }
        private void SetChNodes(DevComponents.AdvTree.Node node, bool bChecked)
        {
            foreach (DevComponents.AdvTree.Cell cell in node.Cells)
            {
                if (cell.CheckBoxVisible && cell.Checked == !bChecked)
                {
                    return;
                }
            }

            foreach (DevComponents.AdvTree.Node chNode in node.Nodes)
            {
                foreach (DevComponents.AdvTree.Cell cell in chNode.Cells)
                {
                    if (cell.CheckBoxVisible)
                    {
                        cell.Checked = bChecked;
                    }
                }
                //                 if (chNode.CheckBoxVisible)
                //                 {
                //                     chNode.Checked =bChecked;
                //                 }
                SetChNodes(chNode, bChecked);
            }
        }
        private void SetPaNodes(DevComponents.AdvTree.Node node, bool bChecked)
        {
            foreach (DevComponents.AdvTree.Cell cell in node.Cells)
            {
                if (cell.CheckBoxVisible && cell.Checked == !bChecked)
                {
                    if (node.Parent != null)
                    {
                        node.Parent.CheckState = CheckState.Indeterminate;
                        SetPaNodes(node.Parent, bChecked);
                    }
                    return;
                }
            }
            if (node.Parent != null)
            {
                if (node.Parent.CheckBoxVisible)
                {
                    node.Parent.CheckState = CheckState.Indeterminate;
                }
                if (bChecked)
                {
                    bool bfind = false;
                    foreach (DevComponents.AdvTree.Node chNode in node.Parent.Nodes)
                    {
                        if (chNode.CheckBoxVisible && chNode.CheckState != CheckState.Checked)
                        {
                            bfind = true;
                        }
                    }
                    if (!bfind)
                    {
                        node.Parent.CheckState = CheckState.Checked;
                    }
                }
                else
                {
                    bool bfind = false;
                    foreach (DevComponents.AdvTree.Node chNode in node.Parent.Nodes)
                    {
                        if (chNode.CheckBoxVisible && chNode.CheckState != CheckState.Unchecked)
                        {
                            bfind = true;
                        }
                    }
                    if (!bfind)
                    {
                        node.Parent.CheckState = CheckState.Unchecked;
                    }
                }
                SetPaNodes(node.Parent, bChecked);
            }
        }
        private void AdvTreeEx_AfterCheck(object sender, DevComponents.AdvTree.AdvTreeCellEventArgs e)//选中即触发的事件
        {
            DevComponents.AdvTree.Node node = e.Cell.Parent;
            if (e.Action == DevComponents.AdvTree.eTreeAction.Mouse || e.Action == DevComponents.AdvTree.eTreeAction.Keyboard)
            {
                if (node.Parent == null)
                {
                    if (beforeCheckState == CheckState.Indeterminate)
                    {
                        //node.Checked = true;
                        node.CheckState = CheckState.Checked;
                    }
                    else if (beforeCheckState == CheckState.Checked)
                    {
                        //node.Checked = false;
                        node.CheckState = CheckState.Unchecked;
                    }
                }

                SetChNodes(node, node.Checked);
                SetPaNodes(node, node.Checked);

                
            }
        }
        private CheckState beforeCheckState = CheckState.Unchecked;
        private void AdvTreeEx_BeforeCheck(object sender, DevComponents.AdvTree.AdvTreeCellBeforeCheckEventArgs e)
        {
            DevComponents.AdvTree.Node node = e.Cell.Parent;
            if (node.Parent == null && (e.Action == DevComponents.AdvTree.eTreeAction.Mouse || e.Action == DevComponents.AdvTree.eTreeAction.Keyboard))
            {
                beforeCheckState = node.CheckState;
            }
        }

        private void AdvTreeEx_NodeDragFeedback(object sender, DevComponents.AdvTree.TreeDragFeedbackEventArgs e)
        {
            AdvTreeEx advTreeEx = sender as AdvTreeEx;
            if (advTreeEx == null) return;
            if (advTreeEx.SelectedNode == e.DragNode)//阻止本窗口拖动
            {
                e.AllowDrop = false;
            }
            else
            {
                e.AllowDrop = true;
            }
        }

        /// <summary>
        /// 获取指定类型节点
        /// </summary>
        /// <param name="types">获取节点类型参数列表</param>
        /// <returns>返回符合类型的节点列表</returns>
        public List<DevComponents.AdvTree.Node> GetNodeList(params Type[] types)
        {
            List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
            foreach (DevComponents.AdvTree.Node node in this.Nodes)
            {
                FindNodes(nodes, node, types);
            }
            return nodes;
        }
        /// <summary>
        /// 通过给定的根节点列表遍历子节点，包括根节点本身，获取Node列表
        /// </summary>
        /// <param name="rootNodes"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public List<DevComponents.AdvTree.Node> GetNodeList(List<DevComponents.AdvTree.Node> rootNodes, params Type[] types)
        {
            List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
            foreach (DevComponents.AdvTree.Node node in rootNodes)
            {
                FindNodes(nodes, node, types);
            }
            return nodes;
        }
        /// <summary>
        /// 通过给定的根节点列表遍历子节点，包括根节点本身，获取T类型的节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootNodes"></param>
        /// <returns></returns>
        public List<T> GetTypeList<T>(List<DevComponents.AdvTree.Node> rootNodes)
        {
            List<DevComponents.AdvTree.Node> nodes = GetNodeList(rootNodes,typeof(T));
            List<T> list = new List<T>();
            foreach (DevComponents.AdvTree.Node node in nodes)
            {
                list.Add((T)node.Tag);
            }
            return list;
        }
        /// <summary>
        /// 获取指定类型节点
        /// </summary>
        /// <param name="bChecked">获取选中或未选中节点</param>
        /// <param name="types">获取节点类型参数列表</param>
        /// <returns>返回符合类型的节点列表</returns>
        public List<DevComponents.AdvTree.Node> GetNodeList(bool bChecked, params Type[] types)
        {
            List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
            foreach (DevComponents.AdvTree.Node node in this.Nodes)
            {
                FindNodes(nodes, node, bChecked, types);
            }
            return nodes;
        }
        /// <summary>
        /// 获取指定选择状态的节点
        /// </summary>
        /// <param name="checkStates"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public List<DevComponents.AdvTree.Node> GetNodeList(List<CheckState> checkStates, params Type[] types)
        {
            List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
            foreach (DevComponents.AdvTree.Node node in this.Nodes)
            {
                FindNodes(nodes, node,checkStates, types);
            }
            return nodes;
        }
        public List<T> GetTypeList<T>(params CheckState[] checkStates)
        {
            List<DevComponents.AdvTree.Node> nodes = GetNodeList(checkStates.ToList(), typeof(T));
            List<T> list = new List<T>();
            foreach (DevComponents.AdvTree.Node node in nodes)
            {
                T obj = (T)node.Tag;
                list.Add(obj);
            }
            return list;
        }
        /// <summary>
        /// 根据类型T，获取节点Tag对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="checkStates"></param>
        /// <returns></returns>
        public List<T> GetTypeList<T>(List<CheckState> checkStates)
        {
            List<DevComponents.AdvTree.Node> nodes = GetNodeList(checkStates, typeof(T));
            List<T> list = new List<T>();
            foreach (DevComponents.AdvTree.Node node in nodes)
            {
                T obj = (T)node.Tag;
                list.Add(obj);
            }
            return list;
        }

        private void FindNodes(List<DevComponents.AdvTree.Node> nodes, DevComponents.AdvTree.Node node, List<CheckState> checkStates, Type[] types)
        {
            int index=checkStates.FindIndex(delegate(CheckState cs)
            {
                if (cs == node.CheckState)
                {
                    return true;
                } 
                else
                {
                    return false;
                }
            });
            if (node.CheckBoxVisible == true && node.Visible == true && index>=0)
            {
                if (types == null || types.Length == 0)
                {
                    nodes.Add(node);
                }
                else
                {
                    foreach (Type type in types)
                    {
                        object nodeTag = node.Tag;
                        if (nodeTag != null && nodeTag.GetType().FullName == type.FullName)
                        {
                            nodes.Add(node);
                            break;
                        }
                        else if (nodeTag == null && typeof(Nullable).FullName == type.FullName)
                        {
                            nodes.Add(node);
                            break;
                        }
                    }
                }
            }
            foreach (DevComponents.AdvTree.Node chNode in node.Nodes)
            {
                FindNodes(nodes, chNode, checkStates, types);
            }
        }
        /// <summary>
        /// 获取指定类型的字符串，组合方式： “节点名1，节点名2” 注意是汉字字符
        /// </summary>
        /// <param name="bChecked">获取选中或未选中节点</param>
        /// <param name="types">获取节点类型参数列表</param>
        /// <returns>返回符合类型的节点列表名称TEXT字符串</returns>
        public string GetNodeTexts(bool bChecked, params Type[] types)
        {
            List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
            foreach (DevComponents.AdvTree.Node node in this.Nodes)
            {
                FindNodes(nodes, node, bChecked, types);
            }
            StringBuilder sb = new StringBuilder();
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count - 1; i++)
                {
                    sb.Append(nodes[i].Text + "，");
                }
                sb.Append(nodes[nodes.Count - 1].Text);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取指定类型的字符串，组合方式： “节点名1，节点名2”  注意是汉子字符
        /// </summary>
        /// <param name="bChecked">获取选中或未选中节点</param>
        /// <param name="types">获取节点类型参数列表</param>
        /// <returns>返回符合类型的节点列表TAG字符串</returns>
        public string GetNodeTagTexts(bool bChecked, params Type[] types)
        {
            List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
            foreach (DevComponents.AdvTree.Node node in this.Nodes)
            {
                FindNodes(nodes, node, bChecked, types);
            }
            StringBuilder sb = new StringBuilder();
            if (nodes.Count > 0)
            {
                object obj = null;
                for (int i = 0; i < nodes.Count - 1; i++)
                {
                    obj = nodes[i].Tag;
                    if (obj == null)
                    {
                        obj = "未知";
                    }
                    sb.Append(obj.ToString() + "，");
                }
                obj = nodes[nodes.Count - 1].Tag;
                if (obj == null)
                {
                    obj = "未知";
                }
                sb.Append(obj.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// 设置所有节点选中状态
        /// </summary>
        /// <param name="bChecked">状态</param>
        public void SetAllCheckState(bool bChecked)
        {
            foreach (DevComponents.AdvTree.Node node in this.Nodes)
            {
                node.Checked = bChecked;
                SetChNodes(node, bChecked);
            }
        }
        //查询节点
        private void FindNodes(List<DevComponents.AdvTree.Node> nodes, DevComponents.AdvTree.Node node, bool bChecked, params Type[] types)
        {
            if (node.CheckBoxVisible == true && node.Visible == true && node.Checked == bChecked)
            {
                if (types == null || types.Length == 0)
                {
                    nodes.Add(node);
                }
                else
                {
                    foreach (Type type in types)
                    {
                        object nodeTag = node.Tag;
                        if (nodeTag!=null&&nodeTag.GetType().FullName == type.FullName)
                        {
                            nodes.Add(node);
                            break;
                        }
                        else if (nodeTag==null&&typeof(Nullable).FullName==type.FullName)
                        {
                            nodes.Add(node);
                            break;
                        }
                    }
                }
            }
            foreach (DevComponents.AdvTree.Node chNode in node.Nodes)
            {
                FindNodes(nodes, chNode, bChecked, types);
            }
        }
   
        //查询节点
        private void FindNodes(List<DevComponents.AdvTree.Node> nodes, DevComponents.AdvTree.Node node, params Type[] types)
        {
            if (node.Visible == true)
            {
                if (types == null || types.Length == 0)
                {
                    nodes.Add(node);
                }
                else
                {
                    foreach (Type type in types)
                    {
                        object nodeTag = node.Tag;
                        if (nodeTag!=null&&nodeTag.GetType().FullName == type.FullName)
                        {
                            nodes.Add(node);
                            break;
                        }
                        else if (nodeTag==null&&typeof(Nullable).FullName==type.FullName)
                        {
                            nodes.Add(node);
                            break;
                        }
                    }
                }
            }
            foreach (DevComponents.AdvTree.Node chNode in node.Nodes)
            {
                FindNodes(nodes, chNode, types);
            }
        }
    }
}
