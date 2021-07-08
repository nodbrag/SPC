// 登录
import Login from '../pages/Login/Login.vue'
// 首页
import HomeIndex from '../pages/Home/index.vue'
//设备管理
import Equipment from '../pages/Equipment/index.vue'
import EquipmentList from '../pages/Equipment/EquipmentList/index.vue'
import EquipmentClass from '../pages/Equipment/EquipmentClass/index.vue'
// 产品页面
import Inject from '../pages/Inject/index.vue'
import InjectProductList from '../pages/Inject/ProductList/index.vue'
import InspectionParam from '../pages/Inject/InspectionParam/index.vue'

// 离散页面
import Discrete from '../pages/Discrete/index.vue'
import DiscreteList from '../pages/Discrete/DiscreteList/indev.vue'
import DiscreteInfo from '../pages/Discrete/Info/index.vue'
// 烧结
import Sintering from '../pages/Sintering/index.vue'
import SinteringDetail from '../pages/Sintering/Detail/indev.vue'
// 整形
import Plastic from '../pages/Plastic/index.vue'
import PlasticDetail from '../pages/Plastic/Detail/indev.vue'
// 尺寸检测
import Dimension from '../pages/Dimension/index.vue'
import DimensionList from '../pages/Dimension/List/index.vue'
import DimensionDetail from '../pages/Dimension/Detail/index.vue'
import DimensionSummary from '../pages/Dimension/Summary/index.vue'
// 外观检测
import Appearance from '../pages/Appearance/index.vue'
import AppearanceList from '../pages/Appearance/List/index.vue'
import AppearanceDetail from '../pages/Appearance/Detail/index.vue'
// spc分析
import SpcAnalysis from '../pages/SpcAnalysis/index.vue'
import TaskList from '../pages/SpcAnalysis/TaskList/index.vue'
import Analysis from '../pages/SpcAnalysis/Analysis/index.vue'
import CausalityAnalysis from '../pages/SpcAnalysis/CausalityAnalysis/index.vue'
import ComparativeAnalysis from '../pages/SpcAnalysis/ComparativeAnalysis/index.vue'
import EchartsClass from '../pages/SpcAnalysis/EchartsClass/index.vue'
// 工序管理
import Causal from '../pages/Causal/index.vue'
import WorkProcessList from '../pages/Causal/WorkProcessList/index.vue'
//参数管理

import parameter from '../pages/Parameter/index.vue'
import ParameterList from '../pages/Parameter/ParameterList/index.vue'
//用户管理
//import User from '../pages/User/Index.vue'
//import UserList from '../pages/User/UserList/index.vue'
//import UserType from '../pages/User/UserType/index.vue'
// 系统设置
import Setting from '../pages/Setting/index.vue'
import User from '../pages/Setting/User/Index.vue'
import Role from '../pages/Setting/Role/Index.vue'
import Menu from '../pages/Setting/Menu/Index.vue'

export default [
    {
      path: '/login',
      name: 'login',
      component: Login,
      menuShow: false,
      meta: {
        showNav: false
      }
    },
    {
      path: '/home/index',
      name: '首页',
      menuShow: true,
      leaf: false,
      component: HomeIndex,
      meta: {
        showNav: true
      }
    },
    { // 设备管理
      path: '/equipment',
      name: '设备管理',
      menuShow: true,
      leaf: false,
      iconCls: 'iconfont icon-home',
      component: Equipment,
      children:[
        {
          path:'/equipment/EquipmentList',
          component:EquipmentList,
          meta: {
            showNav: true
          }
        },
        {
          path:'/equipment/EquipmentClass',
          component:EquipmentClass,
          meta: {
            showNav: true
          }
        },
        {
          path:'/',
          redirect:'/equipment/EquipmentList'
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // 产品页面
      path: '/inject',
      name: 'inject',
      menuShow: false,
      component: Inject,
      children:[
        {
          path: '/inject/list',
          component: InjectProductList,
          meta: {
            showNav: true
          }
        },
        {
          path: '/inject/inspectionParam',
          component: InspectionParam,
          meta: {
            showNav: true
          }
        },
        {
          path: '/',
          redirect: '/inject/list',
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // 系统设置
      path: '/setting',
      name:'setting',
      menuShow: true,
      component:Setting,
      children:[
        {
          path:'/setting/user',
          component:User,
          meta: {
            showNav: true
          }
        },
        {
          path:'/setting/role',
          component:Role,
          meta: {
            showNav: true
          }
        },
        {
          path:'/setting/menu',
          component:Menu,
          meta: {
            showNav: true
          }
        },
        {
          path:'/',
          redirect:'/setting/user'
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // SPC管理
      path: '/spcAnalysis',
      name: 'SPC管理',
      menuShow: true,
      leaf: false,
      iconCls: 'iconfont icon-home',
      component: SpcAnalysis,
      children:[
        {
          path:'/spcAnalysis/TaskList',
          component:TaskList,
          meta: {
            showNav: true
          }
        },
        {
          path:'/spcAnalysis/Analysis',
          component:Analysis,
          meta: {
            showNav: true
          }
        },
        {
          path:'/spcAnalysis/CausalityAnalysis',
          component:CausalityAnalysis,
          meta: {
            showNav: true
          }
        },
        {
          path:'/spcAnalysis/ComparativeAnalysis',
          component:ComparativeAnalysis,
          meta: {
            showNav: true
          }
        },
        {
          path:'/spcAnalysis/EchartsClass',
          component:EchartsClass,
          meta: {
            showNav: true
          }
        },
        {
          path:'/',
          redirect:'/spcAnalysis/TaskList'
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // 参数管理
      path: '/parameter',
      name: 'SPC管理',
      menuShow: true,
      leaf: false,
      iconCls: 'iconfont icon-home',
      component: parameter,
      children:[
        {
          path:'/parameter/ParameterList',
          component:ParameterList,
          meta: {
            showNav: true
          }
        },
        {
          path:'/',
          redirect:'/parameter/ParameterList'
        }
      ],
      meta: {
        showNav: true
      }
    },

    { // 离散数据页面
      path: '/discrete',
      name: 'discrete',
      menuShow: false,
      component: Discrete,
      children:[
        {
          path:'/discrete/DiscreteList',
          component:DiscreteList,
          meta: {
            showNav: true
          }
        },
        {
          path:'/discrete/info',
          component:DiscreteInfo,
          meta: {
            showNav: true
          }
        },
        {
          path: '/',
          redirect: '/discrete/DiscreteList',
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // 烧结
      path: '/sintering',
      name: 'sintering',
      menuShow: false,
      component: Sintering,
      children:[
        {
          path:'/sintering/detail',
          component:SinteringDetail,
          meta: {
            showNav: true
          }
        },
        {
          path: '/',
          redirect: '/sintering/detail',
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // 整形
      path: '/plastic',
      name: 'plastic',
      menuShow: false,
      component: Plastic,
      children:[
        {
          path: '/plastic/detail',
          component: PlasticDetail,
          meta: {
            showNav: true
          }
        },
        {
          path: '/',
          redirect: '/plastic/detail',
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // 尺寸检测
      path: '/dimension',
      name: 'dimension',
      menuShow: false,
      component: Dimension,
      children:[
        {
          path:'/dimension/list',
          component:DimensionList,
          meta: {
            showNav: true
          }
        },
        {
          path:'/dimension/detail',
          component:DimensionDetail,
          meta: {
            showNav: true
          }
        },
        {
          path:'/dimension/summary',
          component:DimensionSummary,
          meta: {
            showNav: true
          }
        },
        {
          path:'/',
          redirect:'/dimension/list'
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // 外观检测
      path: '/appearance',
      name: 'appearance',
      menuShow: false,
      component: Appearance,
      children:[
        {
          path:'/appearance/list',
          component:AppearanceList,
          meta: {
            showNav: true
          }
        },
        {
          path:'/appearance/detail',
          component:AppearanceDetail,
          meta: {
            showNav: true
          }
        },
        {
          path:'/',
          redirect:'/appearance/list'
        }
      ],
      meta: {
        showNav: true
      }
    },
    { // spc分析
      path: '/spcanalysis',
      name: 'spcanalysis',
      menuShow: false,
      component: SpcAnalysis,
      meta: {
        showNav: true
      }
    },
    { // 因果库
      path: '/causal',
      name: 'causal',
      menuShow: false,
      component: Causal,
      children:[
        {
          path: '/causal/list',
          component: WorkProcessList,
          meta: {
            showNav: true
          }
        },
        {
          path: '/',
          redirect: '/causal/list',
        }
      ],
      meta: {
        showNav: true
      }
    },
    {
      path: '/',
      // redirect: '/home/index'
      redirect: '/login'
    }
  ]
