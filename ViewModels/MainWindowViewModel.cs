using Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private readonly IRegionManager? _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CreateMenuBars();
        }

        private List<MenuBar>? _menuBars;
        /// <summary>
        /// 需要绑定的菜单列表数据
        /// </summary>
        public List<MenuBar>? MenuBars 
        { 
            get { return _menuBars; }
            set
            {
                _menuBars = value;
            }
        }

        private DelegateCommand<MenuBar>? _navigateCommand;
        /// <summary>
        /// 需要绑定的导航命令
        /// </summary>
        public DelegateCommand<MenuBar>? NavigateCommand
        {
            get { return _navigateCommand ?? new DelegateCommand<MenuBar>(Navigation); }
        }

        /// <summary>
        /// 初始化菜单数据
        /// </summary>
        private void CreateMenuBars()
        {
            MenuBars = new List<MenuBar>();

            MenuBar menu1 = new MenuBar { MenuName = "首页", MenuPath = "HomeView" };
            MenuBar menu2 = new MenuBar {  MenuName = "操作", MenuPath = "OperationView" };
            MenuBar menu3 = new MenuBar {  MenuName = "设置", MenuPath = "SetView" };

            MenuBar menu2_1 = new MenuBar { MenuName = "卡匣", MenuPath = "CassetteView" };
            MenuBar menu2_2 = new MenuBar { MenuName = "Port管理", MenuPath = "PortView" };
            MenuBar menu2_3 = new MenuBar { MenuName = "单元", MenuPath = "UnitView" };

            MenuBar menu3_1 = new MenuBar { MenuName = "手臂控制", MenuPath = "RobotControlView" };
            MenuBar menu3_2 = new MenuBar { MenuName = "手臂Flow", MenuPath = "RobotFlowView" };
            MenuBar menu3_3 = new MenuBar { MenuName = "产品管理", MenuPath = "" };

            menu2.MenuItems?.Add(menu2_1);
            menu2.MenuItems?.Add(menu2_2);
            menu2.MenuItems?.Add(menu2_3);

            menu3.MenuItems?.Add(menu3_1);
            menu3.MenuItems?.Add(menu3_2);
            menu3.MenuItems?.Add(menu3_3);

            MenuBars.Add(menu1);
            MenuBars.Add(menu2);
            MenuBars.Add(menu3);
        }

        /// <summary>
        /// 导航命令处理方法
        /// </summary>
        /// <param name="bar"></param>
        private void Navigation(MenuBar bar)
        {
            if (bar != null)
            {
                MenuBar menu = bar as MenuBar;  
                if(menu.MenuPath != null)
                    _regionManager?.RequestNavigate("MainRegion",menu.MenuPath);
            }
        }

    }
}
