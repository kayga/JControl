/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Wpf.Client
*文件名称   ：BaseModule.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/26 星期四 15:47:03 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/26 星期四 15:47:03 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight;
using JControl.Wpf.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JControl.Wpf.Client
{
    public class BaseViewPlugin<TPage> : IModule where TPage : UserControl, new()
    {
        public BaseViewPlugin(int index,string iconfont,string name)
        {
            _index = index;
            _iconfont = iconfont;
            _name = name;
        }
        private int _index;

        public int Index
        {
            get { return _index; }
            private set { _index = value; }
        }

        private string _iconfont;

        public string IconFont
        {
            get { return _iconfont; }
            private set { _iconfont = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        private UserControl view;

        public UserControl UserInterface
        {
            get
            {
                if (view == null)
                {
                    view = new TPage();
                }
                return view;
            }
        }

        public void Deactivate()
        {
            var viewModel = view.DataContext as ViewModelBase;
            viewModel.Cleanup();
            view = null;
        }
    }
}
