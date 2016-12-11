using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Li.Controls.ImageEditors
{
    /// <summary>
    /// 编辑过程接口
    /// </summary>
    public interface IImageFilter
    {
        string Name { get; set; }
        /// <summary>
        /// 处理输入图片
        /// </summary>
        /// <param name="inBitmap">输入图片</param>
        /// <param name="disposeOrigin">是否销毁原始图片</param>
        /// <returns>处理后的图片</returns>
        Bitmap Proccess(Bitmap inBitmap, bool disposeOrigin);
    }

    public enum EditorState
    {
        None,//无
        Clip,//剪切中
    }
}
